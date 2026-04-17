using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using OfficeOpenXml;
using System.Globalization;
using System.Text;

namespace RealEstateDecisionSupportSystemApp;

public partial class Form1 : Form
{
	private List<HouseData> loadedData = new();

	private MLContext mlContext;
	private ITransformer trainedModel;
	private PredictionEngine<ModelInput, HousePrediction> predictionEngine;
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

		lblPredictedPrice.Text = "-";
		lblDifference.Text = "-";

		btnLearn.Enabled = false;
		btnDecision.Text = "Нет решения";
		btnDecision.BackColor = SystemColors.ControlDark;

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
			lblModelState.Text = "Данные загружены";
			lblModelState.ForeColor = Color.DarkOrange;

			btnLearn.Enabled = true;

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

			var preparedData = PrepareModelData(loadedData);
			fullDataView = mlContext.Data.LoadFromEnumerable(preparedData);

			var split = mlContext.Data.TrainTestSplit(fullDataView, testFraction: 0.2);

			var pipeline =
				mlContext.Transforms.Concatenate(
					"Features",
					nameof(ModelInput.SqFt),
					nameof(ModelInput.Bedrooms),
					nameof(ModelInput.Bathrooms),
					nameof(ModelInput.IsBrick),
					nameof(ModelInput.IsNorth),
					nameof(ModelInput.IsWest))
				.Append(
					mlContext.Regression.Trainers.Ols(
						labelColumnName: nameof(ModelInput.Price),
						featureColumnName: "Features"));

			// 1) Честная оценка на test
			var evalModel = pipeline.Fit(split.TrainSet);

			var testPredictions = evalModel.Transform(split.TestSet);
			var metrics = mlContext.Regression.Evaluate(
				testPredictions,
				labelColumnName: nameof(ModelInput.Price),
				scoreColumnName: "Score");

			// 2) Рабочая модель для UI — обучаем на всех данных
			trainedModel = pipeline.Fit(fullDataView);

			predictionEngine =
				mlContext.Model.CreatePredictionEngine<ModelInput, HousePrediction>(trainedModel);

			var coeffs = GetLinearRegressionCoefficients(trainedModel);

			modelBias = coeffs.Bias;
			modelCoefficients = coeffs.Coefficients;

			lblR2.Text = $"R² = {metrics.RSquared:F3}";
			lblMAE.Text = $"MAE = {metrics.MeanAbsoluteError:F0}";
			lblMSE.Text = $"MSE = {metrics.MeanSquaredError:F0}";
			lblFormula.Text = BuildFormulaText(coeffs.Bias, coeffs.Coefficients);

			FillCoefficientsTable(coeffs.Coefficients);
			BuildFeatureImportanceChart(coeffs.Coefficients);
			LoadValidationTable();

			lblModelState.Text = "Модель обучена";
			lblModelState.ForeColor = Color.DarkGreen;

			MessageBox.Show("Линейная регрессия OLS успешно обучена.");
		}
		catch (Exception ex)
		{
			MessageBox.Show("Ошибка обучения:\n" + ex.Message);
		}
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
			if (string.IsNullOrWhiteSpace(cmbNeighborhood.Text))
			{
				MessageBox.Show("Выберите район.");
				return;
			}

			var modelInput = BuildModelInputFromUi();

			var result = predictionEngine.Predict(modelInput);

			lblPredictedPrice.Text = $"{result.PredictedPrice:N0} €";

			ShowInfluenceFactors(modelInput);

			float actualPrice = (float)nudActualPrice.Value;
			if (actualPrice > 0)
			{
				float diff = result.PredictedPrice - actualPrice;
				lblDifference.Text = $"{diff:N0} €";

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

	private void BtnClear_Click(object sender, EventArgs e)
	{
		nudSqFt.Value = 0;
		nudBedrooms.Value = 0;
		nudBathrooms.Value = 0;
		nudActualPrice.Value = 0;
		chkBrick.Checked = false;

		if (cmbNeighborhood.Items.Count > 0)
			cmbNeighborhood.SelectedIndex = 0;

		lblPredictedPrice.Text = "-";
		lblDifference.Text = "-";

		lblImpactSqFt.Text = "-";
		lblImpactBedrooms.Text = "-";
		lblImpactBathrooms.Text = "-";
		lblImpactBrick.Text = "-";
		lblImpactNeighborhood.Text = "-";

		btnDecision.Text = "Нет решения";
		btnDecision.BackColor = SystemColors.ControlDark;
	}

	private void BtnSample_Click(object sender, EventArgs e)
	{
		nudSqFt.Value = 2000;
		nudBedrooms.Value = 3;
		nudBathrooms.Value = 2;
		nudActualPrice.Value = 150000;
		chkBrick.Checked = true;

		if (cmbNeighborhood.Items.Count > 0)
		{
			int index = cmbNeighborhood.Items.IndexOf("West");
			cmbNeighborhood.SelectedIndex = index >= 0 ? index : 0;
		}
	}

	private void FillNeighborhoodComboBox()
	{
		var neighborhoods = loadedData
			.Where(x => !string.IsNullOrWhiteSpace(x.Neighborhood))
			.Select(x => x.Neighborhood.Trim())
			.Distinct(StringComparer.OrdinalIgnoreCase)
			.OrderBy(x => x)
			.ToList();

		cmbNeighborhood.DataSource = null;
		cmbNeighborhood.Items.Clear();

		cmbNeighborhood.DataSource = neighborhoods;

		if (cmbNeighborhood.Items.Count > 0)
			cmbNeighborhood.SelectedIndex = 0;
	}

	private ModelInput BuildModelInputFromUi()
	{
		string neighborhood = cmbNeighborhood.Text?.Trim() ?? "";

		return new ModelInput
		{
			Price = 0f,
			SqFt = (float)nudSqFt.Value,
			Bedrooms = (float)nudBedrooms.Value,
			Bathrooms = (float)nudBathrooms.Value,
			IsBrick = chkBrick.Checked ? 1f : 0f,
			IsNorth = string.Equals(neighborhood, "North", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
			IsWest = string.Equals(neighborhood, "West", StringComparison.OrdinalIgnoreCase) ? 1f : 0f
		};
	}

	private List<ModelInput> PrepareModelData(List<HouseData> source)
	{
		return source.Select(x =>
		{
			string neighborhood = x.Neighborhood?.Trim() ?? "";

			return new ModelInput
			{
				Price = x.Price,
				SqFt = x.SqFt,
				Bedrooms = x.Bedrooms,
				Bathrooms = x.Bathrooms,
				IsBrick = string.Equals(x.Brick, "Yes", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
				IsNorth = string.Equals(neighborhood, "North", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
				IsWest = string.Equals(neighborhood, "West", StringComparison.OrdinalIgnoreCase) ? 1f : 0f
			};
		}).ToList();
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

	private (float Bias, List<ModelCoefficientInfo> Coefficients) GetLinearRegressionCoefficients(
	ITransformer model)
	{
		var chain = model as TransformerChain<RegressionPredictionTransformer<OlsModelParameters>>;
		if (chain == null)
			throw new Exception("Не удалось привести модель к OLS-регрессии.");

		var olsModel = chain.LastTransformer.Model;

		float bias = olsModel.Bias;
		float[] weights = olsModel.Weights.ToArray();

		string[] featureNames =
		{
		"Площадь",
		"Спальни",
		"Ванные",
		"Кирпичный дом",
		"Район North",
		"Район West"
	};

		var result = new List<ModelCoefficientInfo>();

		for (int i = 0; i < weights.Length; i++)
		{
			result.Add(new ModelCoefficientInfo
			{
				FeatureName = i < featureNames.Length ? featureNames[i] : $"Feature_{i}",
				Weight = weights[i]
			});
		}

		return (bias, result);
	}

	private string BuildFormulaText(float bias, List<ModelCoefficientInfo> coefficients)
	{
		var map = coefficients.ToDictionary(x => x.FeatureName, x => x.Weight);

		float sqft = map.GetValueOrDefault("Площадь");
		float bedrooms = map.GetValueOrDefault("Спальни");
		float bathrooms = map.GetValueOrDefault("Ванные");
		float brick = map.GetValueOrDefault("Кирпичный дом");
		float north = map.GetValueOrDefault("Район North");
		float west = map.GetValueOrDefault("Район West");

		var sb = new StringBuilder();
		sb.AppendLine($"Price = {bias:F3}");
		sb.AppendLine($"{FormatSignedFormula(sqft)} * SqFt");
		sb.AppendLine($"{FormatSignedFormula(bedrooms)} * Bedrooms");
		sb.AppendLine($"{FormatSignedFormula(bathrooms)} * Bathrooms");
		sb.AppendLine($"{FormatSignedFormula(brick)} * IsBrick");
		sb.AppendLine($"{FormatSignedFormula(north)} * IsNorth");
		sb.AppendLine($"{FormatSignedFormula(west)} * IsWest");
		sb.AppendLine();
		sb.AppendLine("Где:");
		sb.AppendLine("IsBrick = 1 для кирпичного дома, иначе 0");
		sb.AppendLine("IsNorth = 1 для района North, иначе 0");
		sb.AppendLine("IsWest = 1 для района West, иначе 0");
		sb.AppendLine("East — базовая категория, её вклад равен 0");

		return sb.ToString();
	}

	private string FormatSignedFormula(float value)
	{
		string sign = value >= 0 ? "+" : "-";
		return $"{sign} {Math.Abs(value):F3}";
	}

	private void FillCoefficientsTable(List<ModelCoefficientInfo> coefficients)
	{
		var tableData = coefficients
			.Select(c => new
			{
				Признак = c.FeatureName,
				Коэффициент = Math.Round(c.Weight, 3),
				Влияние = GetImpact(c.Weight),
				Направление =
					c.Weight > 0 ? "Увеличивает цену" :
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

	private string GetImpact(float weight)
	{
		float abs = Math.Abs(weight);

		if (abs >= 20000) return "Очень сильное";
		if (abs >= 5000) return "Сильное";
		if (abs >= 1000) return "Среднее";
		return "Слабое";
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

	private void ShowInfluenceFactors(ModelInput house)
	{
		float sqftCoef = GetCoefficientValueExact("Площадь");
		float bedroomsCoef = GetCoefficientValueExact("Спальни");
		float bathroomsCoef = GetCoefficientValueExact("Ванные");
		float brickCoef = GetCoefficientValueExact("Кирпичный дом");

		float sqftImpact = house.SqFt * sqftCoef;
		float bedroomsImpact = house.Bedrooms * bedroomsCoef;
		float bathroomsImpact = house.Bathrooms * bathroomsCoef;
		float brickImpact = house.IsBrick * brickCoef;
		float neighborhoodImpact = GetNeighborhoodImpact(house);

		lblImpactSqFt.Text = FormatMoney(sqftImpact);
		lblImpactBedrooms.Text = FormatMoney(bedroomsImpact);
		lblImpactBathrooms.Text = FormatMoney(bathroomsImpact);
		lblImpactBrick.Text = FormatMoney(brickImpact);
		lblImpactNeighborhood.Text = $"{GetNeighborhoodDisplayName(house)}: {FormatMoney(neighborhoodImpact)}";
	}

	private float GetNeighborhoodImpact(ModelInput house)
	{
		float impact = 0f;

		if (house.IsNorth > 0.5f)
			impact += GetCoefficientValueExact("Район North");

		if (house.IsWest > 0.5f)
			impact += GetCoefficientValueExact("Район West");

		return impact;
	}

	private string GetNeighborhoodDisplayName(ModelInput house)
	{
		if (house.IsNorth > 0.5f) return "North";
		if (house.IsWest > 0.5f) return "West";
		return "East";
	}

	private string FormatMoney(float value)
	{
		string sign = value >= 0 ? "+" : "-";
		return $"{sign}{Math.Abs(value):N0} €";
	}

	private ModelInput ConvertToModelInput(HouseData row)
	{
		string neighborhood = row.Neighborhood?.Trim() ?? "";

		return new ModelInput
		{
			Price = 0f,
			SqFt = row.SqFt,
			Bedrooms = row.Bedrooms,
			Bathrooms = row.Bathrooms,
			IsBrick = string.Equals(row.Brick, "Yes", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
			IsNorth = string.Equals(neighborhood, "North", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
			IsWest = string.Equals(neighborhood, "West", StringComparison.OrdinalIgnoreCase) ? 1f : 0f
		};
	}

	private void LoadValidationTable()
	{
		if (trainedModel == null || mlContext == null || loadedData == null || loadedData.Count == 0)
			return;

		var prepared = loadedData
			.Select((row, index) => new ValidationInput
			{
				Index = index + 1,
				RealPrice = row.Price,

				SqFt = row.SqFt,
				Bedrooms = row.Bedrooms,
				Bathrooms = row.Bathrooms,
				IsBrick = string.Equals(row.Brick, "Yes", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
				IsNorth = string.Equals(row.Neighborhood, "North", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,
				IsWest = string.Equals(row.Neighborhood, "West", StringComparison.OrdinalIgnoreCase) ? 1f : 0f,

				Brick = row.Brick,
				Neighborhood = row.Neighborhood
			})
			.ToList();

		var dataView = mlContext.Data.LoadFromEnumerable(prepared);
		var transformed = trainedModel.Transform(dataView);

		var predictions = mlContext.Data
			.CreateEnumerable<ValidationPrediction>(transformed, reuseRowObject: false)
			.ToList();

		var results = predictions
			.Select(x => new ValidationRow
			{
				Index = x.Index,
				RealPrice = x.RealPrice,
				PredictedPrice = x.Score,
				Error = x.RealPrice - x.Score,
				AbsoluteError = Math.Abs(x.RealPrice - x.Score),

				SqFt = x.SqFt,
				Bedrooms = x.Bedrooms,
				Bathrooms = x.Bathrooms,
				Brick = x.Brick,
				Neighborhood = x.Neighborhood
			})
			.ToList();

		dataGridViewValidation.AutoGenerateColumns = true;
		dataGridViewValidation.DataSource = null;
		dataGridViewValidation.DataSource = results;

		dataGridViewValidation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridViewValidation.ReadOnly = true;
		dataGridViewValidation.AllowUserToAddRows = false;
		dataGridViewValidation.AllowUserToDeleteRows = false;
		dataGridViewValidation.AllowUserToResizeRows = false;
		dataGridViewValidation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

		float mae = results.Average(x => x.AbsoluteError);
		float mse = results.Average(x => x.Error * x.Error);
		float maxError = results.Max(x => x.AbsoluteError);

		lblValidationMAE.Text = $"MAE = {mae:N0}";
		lblValidationMSE.Text = $"MSE = {mse:N0}";
		lblValidationMaxError.Text = $"Max Error = {maxError:N0}";
	}
}