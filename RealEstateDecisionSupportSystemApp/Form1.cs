using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using OfficeOpenXml;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RealEstateDecisionSupportSystemApp;

public partial class Form1 : Form
{
	private List<HouseData> loadedData = new();
	private MLContext mlContext;
	private ITransformer trainedModel;
	private PredictionEngine<HouseData, HousePrediction> predictionEngine;
	private IDataView fullDataView;
	private CartesianChart chartFeatures;
	private float modelBias;
	private List<ModelCoefficientInfo> modelCoefficients = new();

	public Form1()
	{
		InitializeComponent();
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		ExcelPackage.License.SetNonCommercialPersonal("Student Project");

		lblModelState.Text = "Модель не обучена";
		lblModelState.ForeColor = Color.DarkRed;
		lblStatus.Text = "";
		lblR2.Text = "";
		lblMAE.Text = "";
		lblMSE.Text = "";
		lblFormula.Text = "";

		btnLearn.Enabled = false;

		CreateFeatureChartHost();
	}

	private void BtnLoad_Click(object sender, EventArgs e)
	{
		using OpenFileDialog ofd = new();
		ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
		ofd.Title = "Выберите Excel-файл";

		if (ofd.ShowDialog() != DialogResult.OK)
			return;

		try
		{
			loadedData = LoadHouseDataFromExcel(ofd.FileName);

			if (loadedData.Count == 0)
			{
				MessageBox.Show(
					"Файл найден, но строки с данными не были загружены.",
					"Предупреждение",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				return;
			}

			dataGridView1.AutoGenerateColumns = true;
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = loadedData;

			FillNeighborhoodComboBox();

			lblStatus.Text = $"Загружено объектов: {loadedData.Count}";
			btnLearn.Enabled = true;

			lblModelState.Text = "Данные загружены";
			lblModelState.ForeColor = Color.DarkOrange;

			MessageBox.Show(
				$"Успешно загружено {loadedData.Count} объектов.",
				"Готово",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}
		catch (Exception ex)
		{
			MessageBox.Show(
				"Ошибка при загрузке Excel:\n" + ex.Message,
				"Ошибка",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}

	private void FillNeighborhoodComboBox()
	{
		var neighborhoods = loadedData
			.Where(x => !string.IsNullOrWhiteSpace(x.Neighborhood))
			.Select(x => x.Neighborhood.Trim())
			.Distinct()
			.OrderBy(x => x)
			.ToList();

		cmbNeighborhood.DataSource = null;
		cmbNeighborhood.Items.Clear();

		cmbNeighborhood.DataSource = neighborhoods;

		if (cmbNeighborhood.Items.Count > 0)
			cmbNeighborhood.SelectedIndex = 0;
	}

	private void BtnLearn_Click(object sender, EventArgs e)
	{
		if (loadedData == null || loadedData.Count == 0)
		{
			MessageBox.Show("Сначала загрузите данные.");
			return;
		}

		try
		{
			mlContext = new MLContext(seed: 1);

			fullDataView = mlContext.Data.LoadFromEnumerable(loadedData);

			var split = mlContext.Data.TrainTestSplit(fullDataView, testFraction: 0.2);

			var pipeline =
				mlContext.Transforms.Categorical.OneHotEncoding(
					outputColumnName: "BrickEncoded",
					inputColumnName: nameof(HouseData.Brick))
				.Append(
					mlContext.Transforms.Categorical.OneHotEncoding(
						outputColumnName: "NeighborhoodEncoded",
						inputColumnName: nameof(HouseData.Neighborhood)))
				.Append(
					mlContext.Transforms.Concatenate(
						"Features",
						nameof(HouseData.SqFt),
						nameof(HouseData.Bedrooms),
						nameof(HouseData.Bathrooms),
						"BrickEncoded",
						"NeighborhoodEncoded"))
				.Append(
					mlContext.Regression.Trainers.Sdca(
						labelColumnName: nameof(HouseData.Price),
						featureColumnName: "Features"));

			trainedModel = pipeline.Fit(split.TrainSet);

			var predictions = trainedModel.Transform(split.TestSet);
			var metrics = mlContext.Regression.Evaluate(
				predictions,
				labelColumnName: nameof(HouseData.Price),
				scoreColumnName: "Score");

			predictionEngine =
				mlContext.Model.CreatePredictionEngine<HouseData, HousePrediction>(trainedModel);

			var coeffs = GetLinearRegressionCoefficients(trainedModel, fullDataView);

			lblR2.Text = $"R² = {metrics.RSquared:F3}";
			lblMAE.Text = $"MAE = {metrics.MeanAbsoluteError:F0}";
			lblMSE.Text = $"MSE = {metrics.MeanSquaredError:F0}";
			lblFormula.Text = BuildFormulaText(coeffs.Bias, coeffs.Coefficients);
			FillCoefficientsTable(coeffs.Coefficients);
			BuildFeatureImportanceChart(coeffs.Coefficients);

			lblModelState.Text = "Модель обучена";
			lblModelState.ForeColor = Color.DarkGreen;

			modelBias = coeffs.Bias;
			modelCoefficients = coeffs.Coefficients;

			MessageBox.Show("Модель успешно обучена.");
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка обучения:\n" + ex.Message);
		}
	}

	private float GetCoefficientValue(string featureNamePart)
	{
		var coeff = modelCoefficients.FirstOrDefault(c =>
			c.FeatureName.Contains(featureNamePart, StringComparison.OrdinalIgnoreCase));

		return coeff?.Weight ?? 0f;
	}

	private void ShowInfluenceFactors(HouseData house)
	{
		float sqftCoef = GetCoefficientValueExact("Площадь");
		float bedroomsCoef = GetCoefficientValueExact("Спальни");
		float bathroomsCoef = GetCoefficientValueExact("Ванные");

		float sqftImpact = house.SqFt * sqftCoef;
		float bedroomsImpact = house.Bedrooms * bedroomsCoef;
		float bathroomsImpact = house.Bathrooms * bathroomsCoef;

		float brickImpact = GetBrickImpact(house.Brick);
		float neighborhoodImpact = GetNeighborhoodImpact(house.Neighborhood);

		lblImpactSqFt.Text = FormatMoney(sqftImpact);
		lblImpactBedrooms.Text = FormatMoney(bedroomsImpact);
		lblImpactBathrooms.Text = FormatMoney(bathroomsImpact);
		lblImpactBrick.Text = FormatMoney(brickImpact);
		lblImpactNeighborhood.Text = $"{house.Neighborhood}: {FormatMoney(neighborhoodImpact)}";

		// Если у тебя есть отдельный label для базовой части модели:
		// lblImpactBase.Text = FormatMoney(modelBias);
	}

	private string FormatMoney(float value)
	{
		string sign = value >= 0 ? "+" : "-";
		return $"{sign}{Math.Abs(value):N0} €";
	}

	private void BtnPredict_Click(object sender, EventArgs e)
	{
		if (predictionEngine == null)
		{
			MessageBox.Show("Сначала обучите модель.");
			return;
		}

		try
		{
			var house = new HouseData
			{
				SqFt = ParseInputFloat(nudSqFt.Value.ToString(), "Площадь"),
				Bedrooms = ParseInputFloat(nudBedrooms.Value.ToString(), "Спальни"),
				Bathrooms = ParseInputFloat(nudBathrooms.Value.ToString(), "Ванные"),
				Brick = chkBrick.Checked ? "Yes" : "No",
				Neighborhood = cmbNeighborhood.Text,
				Price = 0
			};

			if (string.IsNullOrWhiteSpace(house.Neighborhood))
			{
				MessageBox.Show("Выберите район.");
				return;
			}

			var result = predictionEngine.Predict(house);

			lblPredictedPrice.Text = $"{result.PredictedPrice:F0} €";

			ShowInfluenceFactors(house);

			if (TryParseFloatSafe(nudActualPrice.Value.ToString(), out float actualPrice) && actualPrice > 0)
			{
				float diff = result.PredictedPrice - actualPrice;

				lblDifference.Text = $"{diff:F0} €";

				if (diff > 10000)
				{
					btnDecision.Text = "Покупать";
					btnDecision.BackColor = Color.DarkGreen;
				}
				else if (diff < -10000)
				{
					btnDecision.Text = "Не покупать";
					btnDecision.BackColor = Color.DarkRed;
				}
				else
				{
					btnDecision.Text = "Доп. анализ";
					btnDecision.BackColor = Color.DarkOrange;
				}
			}
			else
			{
				lblDifference.Text = "-";
				btnDecision.Text = "Нет цены";
				btnDecision.BackColor = SystemColors.ControlDark;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка прогноза:\n" + ex.Message);
		}
	}

	private List<HouseData> LoadHouseDataFromExcel(string filePath)
	{
		var houses = new List<HouseData>();

		using var package = new ExcelPackage(new FileInfo(filePath));
		var ws = package.Workbook.Worksheets[0];

		if (ws.Dimension == null)
			throw new Exception("Лист Excel пустой.");

		int rows = ws.Dimension.Rows;
		int cols = ws.Dimension.Columns;

		int headerRow = -1;
		int startCol = -1;

		for (int row = 1; row <= Math.Min(rows, 15); row++)
		{
			for (int col = 1; col <= cols; col++)
			{
				string cellText = ws.Cells[row, col].Text.Trim();

				if (cellText.Equals("Price", StringComparison.OrdinalIgnoreCase))
				{
					headerRow = row;
					startCol = col;
					break;
				}
			}

			if (headerRow != -1)
				break;
		}

		if (headerRow == -1 || startCol == -1)
			throw new Exception("Не удалось найти строку заголовков. В файле не найден столбец Price.");

		string[] expectedHeaders = { "Price", "SqFt", "Bedrooms", "Bathrooms", "Brick", "Neighborhood" };

		for (int i = 0; i < expectedHeaders.Length; i++)
		{
			string actual = ws.Cells[headerRow, startCol + i].Text.Trim();

			if (!actual.Equals(expectedHeaders[i], StringComparison.OrdinalIgnoreCase))
			{
				throw new Exception(
					$"Ожидался столбец '{expectedHeaders[i]}' в позиции {startCol + i}, но найдено '{actual}'.");
			}
		}

		for (int row = headerRow + 1; row <= rows; row++)
		{
			string priceText = ws.Cells[row, startCol + 0].Text.Trim();
			string sqFtText = ws.Cells[row, startCol + 1].Text.Trim();
			string bedroomsText = ws.Cells[row, startCol + 2].Text.Trim();
			string bathroomsText = ws.Cells[row, startCol + 3].Text.Trim();
			string brickText = ws.Cells[row, startCol + 4].Text.Trim();
			string neighborhoodText = ws.Cells[row, startCol + 5].Text.Trim();

			if (string.IsNullOrWhiteSpace(priceText) &&
				string.IsNullOrWhiteSpace(sqFtText) &&
				string.IsNullOrWhiteSpace(bedroomsText) &&
				string.IsNullOrWhiteSpace(bathroomsText) &&
				string.IsNullOrWhiteSpace(brickText) &&
				string.IsNullOrWhiteSpace(neighborhoodText))
			{
				continue;
			}

			if (!TryParseFloatSafe(priceText, out float price)) continue;
			if (!TryParseFloatSafe(sqFtText, out float sqFt)) continue;
			if (!TryParseFloatSafe(bedroomsText, out float bedrooms)) continue;
			if (!TryParseFloatSafe(bathroomsText, out float bathrooms)) continue;

			houses.Add(new HouseData
			{
				Price = price,
				SqFt = sqFt,
				Bedrooms = bedrooms,
				Bathrooms = bathrooms,
				Brick = brickText,
				Neighborhood = neighborhoodText
			});
		}

		return houses;
	}

	private bool TryParseFloatSafe(string text, out float value)
	{
		text = (text ?? "").Trim();

		if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
			return true;

		if (float.TryParse(text, NumberStyles.Any, new CultureInfo("ru-RU"), out value))
			return true;

		text = text.Replace(" ", "").Replace(",", ".");
		return float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
	}

	private float ParseInputFloat(string text, string fieldName)
	{
		if (!TryParseFloatSafe(text, out float value))
			throw new Exception($"Некорректное значение поля: {fieldName}");

		return value;
	}

	private (float Bias, List<ModelCoefficientInfo> Coefficients) GetLinearRegressionCoefficients(
	ITransformer model,
	IDataView trainingData)
	{
		IDataView transformedData = model.Transform(trainingData);

		var chain = model as TransformerChain<RegressionPredictionTransformer<LinearRegressionModelParameters>>;
		if (chain == null)
			throw new Exception("Не удалось привести модель к TransformerChain линейной регрессии.");

		var regressionTransformer = chain.LastTransformer;
		var linearModel = regressionTransformer.Model;

		float bias = linearModel.Bias;
		float[] weightValues = linearModel.Weights.ToArray();

		var featureColumn = transformedData.Schema["Features"];
		VBuffer<ReadOnlyMemory<char>> slotNamesBuffer = default;
		featureColumn.GetSlotNames(ref slotNamesBuffer);

		var slotNameValues = slotNamesBuffer.DenseValues().ToArray();

		var result = new List<ModelCoefficientInfo>();

		for (int i = 0; i < weightValues.Length; i++)
		{
			string featureName =
				(i < slotNameValues.Length && !slotNameValues[i].IsEmpty)
				? slotNameValues[i].ToString()
				: $"Feature_{i}";

			result.Add(new ModelCoefficientInfo
			{
				FeatureName = BeautifyFeatureName(featureName),
				Weight = weightValues[i]
			});
		}

		return (bias, result);
	}

	private string BeautifyFeatureName(string rawName)
	{
		if (string.Equals(rawName, "SqFt", StringComparison.OrdinalIgnoreCase))
			return "Площадь";

		if (string.Equals(rawName, "Bedrooms", StringComparison.OrdinalIgnoreCase))
			return "Спальни";

		if (string.Equals(rawName, "Bathrooms", StringComparison.OrdinalIgnoreCase))
			return "Ванные";

		if (rawName.Contains("Brick", StringComparison.OrdinalIgnoreCase) &&
			rawName.Contains("Yes", StringComparison.OrdinalIgnoreCase))
			return "Кирпичный дом = Yes";

		if (rawName.Contains("Brick", StringComparison.OrdinalIgnoreCase) &&
			rawName.Contains("No", StringComparison.OrdinalIgnoreCase))
			return "Кирпичный дом = No";

		if (rawName.Contains("North", StringComparison.OrdinalIgnoreCase))
			return "Район North";

		if (rawName.Contains("West", StringComparison.OrdinalIgnoreCase))
			return "Район West";

		if (rawName.Contains("East", StringComparison.OrdinalIgnoreCase))
			return "Район East";

		return rawName;
	}

	private string BuildFormulaText(float bias, List<ModelCoefficientInfo> coefficients)
	{
		var sb = new StringBuilder();

		sb.AppendLine($"Price = {bias:F3}");

		foreach (var c in coefficients)
		{
			string sign = c.Weight >= 0 ? "+" : "-";
			sb.AppendLine($"{sign} {Math.Abs(c.Weight):F3} * {c.FeatureName}");
		}

		return sb.ToString();
	}

	private string GetImpact(float weight)
	{
		float abs = Math.Abs(weight);

		if (abs >= 20000) return "Очень сильное";
		if (abs >= 5000) return "Сильное";
		if (abs >= 1000) return "Среднее";
		return "Слабое";
	}

	private void FillCoefficientsTable(List<ModelCoefficientInfo> coefficients)
	{
		var tableData = coefficients
			.Select(c => new
			{
				Признак = c.FeatureName,
				Коэффициент = Math.Round(c.Weight, 3),
				Влияние = GetImpact(c.Weight),
				Направление = c.Weight > 0 ? "Увеличивает цену" :
							   c.Weight < 0 ? "Уменьшает цену" :
							   "Не влияет"
			})
			.ToList();

		dataGridViewCoeffs.AutoGenerateColumns = true;
		dataGridViewCoeffs.DataSource = null;
		dataGridViewCoeffs.DataSource = tableData;

		dataGridViewCoeffs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridViewCoeffs.ReadOnly = true;
		dataGridViewCoeffs.AllowUserToAddRows = false;
		dataGridViewCoeffs.AllowUserToDeleteRows = false;
		dataGridViewCoeffs.AllowUserToResizeRows = false;
		dataGridViewCoeffs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
	}

	private void DataGridViewCoeffs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (dataGridViewCoeffs.Columns[e.ColumnIndex].Name == "Коэффициент" && e.Value != null)
		{
			if (float.TryParse(e.Value.ToString(), out float val))
			{
				if (val > 0)
					e.CellStyle.ForeColor = Color.DarkGreen;
				else if (val < 0)
					e.CellStyle.ForeColor = Color.DarkRed;
			}
		}
	}

	private void BuildFeatureImportanceChart(List<ModelCoefficientInfo> coefficients)
	{
		if (chartFeatures == null)
			return;

		var sorted = coefficients
			.OrderByDescending(c => Math.Abs(c.Weight))
			.ToList();

		chartFeatures.Series = new ISeries[]
		{
		new RowSeries<double>
		{
			Name = "Важность признаков",
			Values = sorted.Select(c => (double)Math.Abs(c.Weight)).ToArray()
		}
		};

		chartFeatures.YAxes = new Axis[]
		{
		new Axis
		{
			Labels = sorted.Select(c => c.FeatureName).ToArray(),
			LabelsRotation = 0,
			TextSize = 14,
			MinStep = 1,
			Padding = new LiveChartsCore.Drawing.Padding(0)
		}
		};

		chartFeatures.XAxes = new Axis[]
		{
		new Axis
		{
			Name = "Сила влияния",
			TextSize = 14
		}
		};

		chartFeatures.LegendPosition = LegendPosition.Hidden;
		chartFeatures.Update();
		chartFeatures.Refresh();
	}

	private void CreateFeatureChartHost()
	{
		chartFeatures = new CartesianChart
		{
			Dock = DockStyle.Fill,
			Visible = true
		};

		tabPage2.Controls.Clear();
		tabPage2.Controls.Add(chartFeatures);
		chartFeatures.BringToFront();

		tabPage2.ResumeLayout();
		tabPage2.PerformLayout();
	}

	private float GetCoefficientValueExact(string featureName)
	{
		var coeff = modelCoefficients.FirstOrDefault(c =>
			string.Equals(c.FeatureName, featureName, StringComparison.OrdinalIgnoreCase));

		return coeff?.Weight ?? 0f;
	}

	private float GetNeighborhoodImpact(string neighborhood)
	{
		if (string.IsNullOrWhiteSpace(neighborhood))
			return 0f;

		string featureName = $"Район {neighborhood.Trim()}";

		var coeff = modelCoefficients.FirstOrDefault(c =>
			string.Equals(c.FeatureName, featureName, StringComparison.OrdinalIgnoreCase));

		// Если коэффициент не найден, значит это базовая категория one-hot encoding
		return coeff?.Weight ?? 0f;
	}

	private float GetBrickImpact(string brick)
	{
		string featureName = string.Equals(brick, "Yes", StringComparison.OrdinalIgnoreCase)
			? "Кирпичный дом = Yes"
			: "Кирпичный дом = No";

		var coeff = modelCoefficients.FirstOrDefault(c =>
			string.Equals(c.FeatureName, featureName, StringComparison.OrdinalIgnoreCase));

		return coeff?.Weight ?? 0f;
	}
}