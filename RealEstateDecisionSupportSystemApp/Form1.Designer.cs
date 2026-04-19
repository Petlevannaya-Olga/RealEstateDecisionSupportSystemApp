namespace RealEstateDecisionSupportSystemApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
			LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
			LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
			btnLearn = new Button();
			btnLoad = new Button();
			tableLayoutPanel1 = new TableLayoutPanel();
			panel1 = new Panel();
			panel2 = new Panel();
			label7 = new Label();
			btnCalculate = new Button();
			btnReset = new Button();
			nudActualPrice = new NumericUpDown();
			label5 = new Label();
			cmbNeighborhood = new ComboBox();
			chkBrick = new CheckBox();
			nudBathrooms = new NumericUpDown();
			nudBedrooms = new NumericUpDown();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			nudSqFt = new NumericUpDown();
			label1 = new Label();
			tableLayoutPanel2 = new TableLayoutPanel();
			tabControl1 = new TabControl();
			tabPage4 = new TabPage();
			dataGridView1 = new DataGridView();
			tabPage1 = new TabPage();
			tableLayoutPanel4 = new TableLayoutPanel();
			dataGridViewCoeffs = new DataGridView();
			panel8 = new Panel();
			lblMSE = new Label();
			lblMAE = new Label();
			lblR2 = new Label();
			label32 = new Label();
			lblFormula = new Label();
			panel7 = new Panel();
			label31 = new Label();
			label30 = new Label();
			label29 = new Label();
			tabPage2 = new TabPage();
			tabPage3 = new TabPage();
			dataGridViewHistory = new DataGridView();
			tabPage5 = new TabPage();
			tableLayoutPanel5 = new TableLayoutPanel();
			dataGridViewValidation = new DataGridView();
			panel9 = new Panel();
			lblValidationMinError = new Label();
			lblValidationMaxError = new Label();
			lblValidationMSE = new Label();
			lblValidationMAE = new Label();
			tableLayoutPanel3 = new TableLayoutPanel();
			panel3 = new Panel();
			btnDecision = new Button();
			label6 = new Label();
			label10 = new Label();
			lblDifference = new Label();
			label13 = new Label();
			lblPredictedPrice = new Label();
			label9 = new Label();
			panel4 = new Panel();
			label8 = new Label();
			panel5 = new Panel();
			lblImpactNeighborhood = new Label();
			lblImpactBrick = new Label();
			lblImpactBathrooms = new Label();
			lblImpactBedrooms = new Label();
			lblImpactSqFt = new Label();
			label18 = new Label();
			label17 = new Label();
			label16 = new Label();
			label15 = new Label();
			label14 = new Label();
			panel6 = new Panel();
			label11 = new Label();
			lblModelState = new Label();
			ofd = new OpenFileDialog();
			lblStatus = new Label();
			tabPage6 = new TabPage();
			cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudActualPrice).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudBathrooms).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudBedrooms).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSqFt).BeginInit();
			tableLayoutPanel2.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			tabPage1.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewCoeffs).BeginInit();
			panel8.SuspendLayout();
			panel7.SuspendLayout();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
			tabPage5.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewValidation).BeginInit();
			panel9.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			panel6.SuspendLayout();
			tabPage6.SuspendLayout();
			SuspendLayout();
			// 
			// btnLearn
			// 
			btnLearn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnLearn.Location = new Point(879, 12);
			btnLearn.Name = "btnLearn";
			btnLearn.Size = new Size(177, 29);
			btnLearn.TabIndex = 1;
			btnLearn.Text = "Обучить модель";
			btnLearn.UseVisualStyleBackColor = true;
			btnLearn.Click += BtnLearn_Click;
			// 
			// btnLoad
			// 
			btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnLoad.Location = new Point(694, 12);
			btnLoad.Name = "btnLoad";
			btnLoad.Size = new Size(177, 29);
			btnLoad.TabIndex = 1;
			btnLoad.Text = "Загрузить данные";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += BtnLoad_Click;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tableLayoutPanel1.BackColor = SystemColors.GradientInactiveCaption;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
			tableLayoutPanel1.Location = new Point(2, 46);
			tableLayoutPanel1.Margin = new Padding(0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(1063, 755);
			tableLayoutPanel1.TabIndex = 2;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.Window;
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(btnCalculate);
			panel1.Controls.Add(btnReset);
			panel1.Controls.Add(nudActualPrice);
			panel1.Controls.Add(label5);
			panel1.Controls.Add(cmbNeighborhood);
			panel1.Controls.Add(chkBrick);
			panel1.Controls.Add(nudBathrooms);
			panel1.Controls.Add(nudBedrooms);
			panel1.Controls.Add(label4);
			panel1.Controls.Add(label3);
			panel1.Controls.Add(label2);
			panel1.Controls.Add(nudSqFt);
			panel1.Controls.Add(label1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(384, 749);
			panel1.TabIndex = 0;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel2.BackColor = Color.MidnightBlue;
			panel2.Controls.Add(label7);
			panel2.Location = new Point(1, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(383, 54);
			panel2.TabIndex = 7;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label7.ForeColor = SystemColors.Window;
			label7.Location = new Point(9, 10);
			label7.Name = "label7";
			label7.Size = new Size(125, 28);
			label7.TabIndex = 0;
			label7.Text = "Параметры";
			// 
			// btnCalculate
			// 
			btnCalculate.BackColor = Color.MidnightBlue;
			btnCalculate.FlatStyle = FlatStyle.Popup;
			btnCalculate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			btnCalculate.ForeColor = SystemColors.Window;
			btnCalculate.Location = new Point(183, 414);
			btnCalculate.Name = "btnCalculate";
			btnCalculate.Size = new Size(195, 29);
			btnCalculate.TabIndex = 6;
			btnCalculate.Text = "Рассчитать прогноз";
			btnCalculate.UseVisualStyleBackColor = false;
			btnCalculate.Click += BtnPredict_Click;
			// 
			// btnReset
			// 
			btnReset.Location = new Point(10, 414);
			btnReset.Name = "btnReset";
			btnReset.Size = new Size(167, 29);
			btnReset.TabIndex = 6;
			btnReset.Text = "Очистить";
			btnReset.UseVisualStyleBackColor = true;
			btnReset.Click += BtnReset_Click;
			// 
			// nudActualPrice
			// 
			nudActualPrice.Location = new Point(10, 369);
			nudActualPrice.Maximum = new decimal(new int[] { 1316134912, 2328, 0, 0 });
			nudActualPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudActualPrice.Name = "nudActualPrice";
			nudActualPrice.Size = new Size(368, 27);
			nudActualPrice.TabIndex = 5;
			nudActualPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(10, 347);
			label5.Name = "label5";
			label5.Size = new Size(134, 20);
			label5.TabIndex = 4;
			label5.Text = "Фактическая цена";
			// 
			// cmbNeighborhood
			// 
			cmbNeighborhood.FormattingEnabled = true;
			cmbNeighborhood.Location = new Point(10, 306);
			cmbNeighborhood.Name = "cmbNeighborhood";
			cmbNeighborhood.Size = new Size(368, 28);
			cmbNeighborhood.TabIndex = 3;
			// 
			// chkBrick
			// 
			chkBrick.AutoSize = true;
			chkBrick.Location = new Point(10, 247);
			chkBrick.Name = "chkBrick";
			chkBrick.Size = new Size(145, 24);
			chkBrick.TabIndex = 2;
			chkBrick.Text = "Кирпичный дом";
			chkBrick.UseVisualStyleBackColor = true;
			// 
			// nudBathrooms
			// 
			nudBathrooms.Location = new Point(10, 204);
			nudBathrooms.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudBathrooms.Name = "nudBathrooms";
			nudBathrooms.Size = new Size(368, 27);
			nudBathrooms.TabIndex = 1;
			nudBathrooms.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// nudBedrooms
			// 
			nudBedrooms.Location = new Point(10, 142);
			nudBedrooms.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudBedrooms.Name = "nudBedrooms";
			nudBedrooms.Size = new Size(368, 27);
			nudBedrooms.TabIndex = 1;
			nudBedrooms.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(10, 283);
			label4.Name = "label4";
			label4.Size = new Size(52, 20);
			label4.TabIndex = 0;
			label4.Text = "Район";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(10, 181);
			label3.Name = "label3";
			label3.Size = new Size(200, 20);
			label3.TabIndex = 0;
			label3.Text = "Количество ванных комнат";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(10, 119);
			label2.Name = "label2";
			label2.Size = new Size(143, 20);
			label2.TabIndex = 0;
			label2.Text = "Количество спален";
			// 
			// nudSqFt
			// 
			nudSqFt.Location = new Point(10, 80);
			nudSqFt.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			nudSqFt.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudSqFt.Name = "nudSqFt";
			nudSqFt.Size = new Size(368, 27);
			nudSqFt.TabIndex = 1;
			nudSqFt.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 57);
			label1.Name = "label1";
			label1.Size = new Size(73, 20);
			label1.TabIndex = 0;
			label1.Text = "Площадь";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(tabControl1, 0, 1);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(390, 0);
			tableLayoutPanel2.Margin = new Padding(0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(673, 755);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage6);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Controls.Add(tabPage5);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(3, 303);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(667, 449);
			tabControl1.TabIndex = 0;
			// 
			// tabPage4
			// 
			tabPage4.Controls.Add(dataGridView1);
			tabPage4.Location = new Point(4, 29);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new Size(659, 416);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Исходные данные";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(0, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(659, 416);
			dataGridView1.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(tableLayoutPanel4);
			tabPage1.Location = new Point(4, 29);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(659, 416);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Модель";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 1;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel4.Controls.Add(dataGridViewCoeffs, 0, 1);
			tableLayoutPanel4.Controls.Add(panel8, 0, 0);
			tableLayoutPanel4.Dock = DockStyle.Fill;
			tableLayoutPanel4.Location = new Point(3, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 2;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
			tableLayoutPanel4.RowStyles.Add(new RowStyle());
			tableLayoutPanel4.Size = new Size(653, 410);
			tableLayoutPanel4.TabIndex = 7;
			// 
			// dataGridViewCoeffs
			// 
			dataGridViewCoeffs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCoeffs.Dock = DockStyle.Fill;
			dataGridViewCoeffs.Location = new Point(3, 253);
			dataGridViewCoeffs.Name = "dataGridViewCoeffs";
			dataGridViewCoeffs.RowHeadersWidth = 51;
			dataGridViewCoeffs.Size = new Size(647, 204);
			dataGridViewCoeffs.TabIndex = 7;
			dataGridViewCoeffs.CellFormatting += DataGridViewCoeffs_CellFormatting;
			// 
			// panel8
			// 
			panel8.Controls.Add(lblMSE);
			panel8.Controls.Add(lblMAE);
			panel8.Controls.Add(lblR2);
			panel8.Controls.Add(label32);
			panel8.Controls.Add(lblFormula);
			panel8.Controls.Add(panel7);
			panel8.Controls.Add(label29);
			panel8.Dock = DockStyle.Fill;
			panel8.Location = new Point(3, 3);
			panel8.Name = "panel8";
			panel8.Size = new Size(647, 244);
			panel8.TabIndex = 0;
			// 
			// lblMSE
			// 
			lblMSE.AutoSize = true;
			lblMSE.Location = new Point(201, 51);
			lblMSE.Name = "lblMSE";
			lblMSE.Size = new Size(55, 20);
			lblMSE.TabIndex = 3;
			lblMSE.Text = "lblMSE";
			// 
			// lblMAE
			// 
			lblMAE.AutoSize = true;
			lblMAE.Location = new Point(201, 29);
			lblMAE.Name = "lblMAE";
			lblMAE.Size = new Size(57, 20);
			lblMAE.TabIndex = 2;
			lblMAE.Text = "lblMAE";
			// 
			// lblR2
			// 
			lblR2.AutoSize = true;
			lblR2.Location = new Point(201, 7);
			lblR2.Name = "lblR2";
			lblR2.Size = new Size(43, 20);
			lblR2.TabIndex = 1;
			lblR2.Text = "lblR2";
			// 
			// label32
			// 
			label32.AutoSize = true;
			label32.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label32.Location = new Point(371, 5);
			label32.Name = "label32";
			label32.Size = new Size(204, 20);
			label32.TabIndex = 6;
			label32.Text = "Теория принятия решений";
			// 
			// lblFormula
			// 
			lblFormula.AutoSize = true;
			lblFormula.Location = new Point(7, 7);
			lblFormula.Name = "lblFormula";
			lblFormula.Size = new Size(72, 20);
			lblFormula.TabIndex = 0;
			lblFormula.Text = "Формула";
			// 
			// panel7
			// 
			panel7.BorderStyle = BorderStyle.FixedSingle;
			panel7.Controls.Add(label31);
			panel7.Controls.Add(label30);
			panel7.Location = new Point(371, 30);
			panel7.Name = "panel7";
			panel7.Size = new Size(268, 68);
			panel7.TabIndex = 5;
			// 
			// label31
			// 
			label31.AutoSize = true;
			label31.Location = new Point(14, 40);
			label31.Name = "label31";
			label31.Size = new Size(226, 20);
			label31.TabIndex = 1;
			label31.Text = "U > 0 купить; U < 0 не покупать";
			// 
			// label30
			// 
			label30.AutoSize = true;
			label30.Location = new Point(14, 8);
			label30.Name = "label30";
			label30.Size = new Size(209, 20);
			label30.TabIndex = 0;
			label30.Text = "U = PreditetPrice - ActualPrice";
			// 
			// label29
			// 
			label29.AutoSize = true;
			label29.Location = new Point(371, 101);
			label29.Name = "label29";
			label29.Size = new Size(167, 20);
			label29.TabIndex = 4;
			label29.Text = "Объектов в обучении: ";
			// 
			// tabPage2
			// 
			tabPage2.Location = new Point(4, 29);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(659, 416);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "График влияния признаков";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			tabPage3.Controls.Add(dataGridViewHistory);
			tabPage3.Location = new Point(4, 29);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(659, 416);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "История";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// dataGridViewHistory
			// 
			dataGridViewHistory.AllowUserToAddRows = false;
			dataGridViewHistory.AllowUserToDeleteRows = false;
			dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewHistory.Dock = DockStyle.Fill;
			dataGridViewHistory.Location = new Point(0, 0);
			dataGridViewHistory.Name = "dataGridViewHistory";
			dataGridViewHistory.RowHeadersWidth = 51;
			dataGridViewHistory.Size = new Size(659, 416);
			dataGridViewHistory.TabIndex = 0;
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(tableLayoutPanel5);
			tabPage5.Location = new Point(4, 29);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new Size(659, 416);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "Проверка модели";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Controls.Add(dataGridViewValidation, 0, 1);
			tableLayoutPanel5.Controls.Add(panel9, 0, 0);
			tableLayoutPanel5.Dock = DockStyle.Fill;
			tableLayoutPanel5.Location = new Point(0, 0);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 2;
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new Size(659, 416);
			tableLayoutPanel5.TabIndex = 0;
			// 
			// dataGridViewValidation
			// 
			dataGridViewValidation.AllowUserToAddRows = false;
			dataGridViewValidation.AllowUserToDeleteRows = false;
			dataGridViewValidation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewValidation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewValidation.Dock = DockStyle.Fill;
			dataGridViewValidation.Location = new Point(3, 103);
			dataGridViewValidation.Name = "dataGridViewValidation";
			dataGridViewValidation.ReadOnly = true;
			dataGridViewValidation.RowHeadersWidth = 51;
			dataGridViewValidation.Size = new Size(653, 310);
			dataGridViewValidation.TabIndex = 0;
			dataGridViewValidation.DataBindingComplete += DataGridViewValidation_DataBindingComplete;
			// 
			// panel9
			// 
			panel9.Controls.Add(lblValidationMinError);
			panel9.Controls.Add(lblValidationMaxError);
			panel9.Controls.Add(lblValidationMSE);
			panel9.Controls.Add(lblValidationMAE);
			panel9.Dock = DockStyle.Fill;
			panel9.Location = new Point(3, 3);
			panel9.Name = "panel9";
			panel9.Size = new Size(653, 94);
			panel9.TabIndex = 1;
			// 
			// lblValidationMinError
			// 
			lblValidationMinError.AutoSize = true;
			lblValidationMinError.Location = new Point(9, 67);
			lblValidationMinError.Name = "lblValidationMinError";
			lblValidationMinError.Size = new Size(153, 20);
			lblValidationMinError.TabIndex = 2;
			lblValidationMinError.Text = "lblValidationMaxError";
			// 
			// lblValidationMaxError
			// 
			lblValidationMaxError.AutoSize = true;
			lblValidationMaxError.Location = new Point(9, 47);
			lblValidationMaxError.Name = "lblValidationMaxError";
			lblValidationMaxError.Size = new Size(153, 20);
			lblValidationMaxError.TabIndex = 2;
			lblValidationMaxError.Text = "lblValidationMaxError";
			// 
			// lblValidationMSE
			// 
			lblValidationMSE.AutoSize = true;
			lblValidationMSE.Location = new Point(9, 27);
			lblValidationMSE.Name = "lblValidationMSE";
			lblValidationMSE.Size = new Size(58, 20);
			lblValidationMSE.TabIndex = 2;
			lblValidationMSE.Text = "label12";
			// 
			// lblValidationMAE
			// 
			lblValidationMAE.AutoSize = true;
			lblValidationMAE.Location = new Point(9, 7);
			lblValidationMAE.Name = "lblValidationMAE";
			lblValidationMAE.Size = new Size(58, 20);
			lblValidationMAE.TabIndex = 1;
			lblValidationMAE.Text = "label12";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(panel3, 0, 0);
			tableLayoutPanel3.Controls.Add(panel5, 1, 0);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(0, 0);
			tableLayoutPanel3.Margin = new Padding(0);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Size = new Size(673, 300);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// panel3
			// 
			panel3.BackColor = SystemColors.Window;
			panel3.Controls.Add(btnDecision);
			panel3.Controls.Add(label6);
			panel3.Controls.Add(label10);
			panel3.Controls.Add(lblDifference);
			panel3.Controls.Add(label13);
			panel3.Controls.Add(lblPredictedPrice);
			panel3.Controls.Add(label9);
			panel3.Controls.Add(panel4);
			panel3.Dock = DockStyle.Fill;
			panel3.Location = new Point(3, 3);
			panel3.Name = "panel3";
			panel3.Size = new Size(330, 294);
			panel3.TabIndex = 0;
			// 
			// btnDecision
			// 
			btnDecision.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnDecision.BackColor = Color.DarkGreen;
			btnDecision.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
			btnDecision.ForeColor = SystemColors.Window;
			btnDecision.Location = new Point(0, 181);
			btnDecision.Name = "btnDecision";
			btnDecision.Size = new Size(330, 113);
			btnDecision.TabIndex = 9;
			btnDecision.Text = "Покупать";
			btnDecision.UseVisualStyleBackColor = false;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(9, 149);
			label6.Name = "label6";
			label6.Size = new Size(70, 20);
			label6.TabIndex = 8;
			label6.Text = "Разница:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(9, 113);
			label10.Name = "label10";
			label10.Size = new Size(120, 20);
			label10.TabIndex = 8;
			label10.Text = "Рыночная цена:";
			// 
			// lblDifference
			// 
			lblDifference.AutoSize = true;
			lblDifference.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblDifference.Location = new Point(144, 149);
			lblDifference.Name = "lblDifference";
			lblDifference.Size = new Size(80, 20);
			lblDifference.TabIndex = 8;
			lblDifference.Text = "150 000 $";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label13.Location = new Point(144, 113);
			label13.Name = "label13";
			label13.Size = new Size(80, 20);
			label13.TabIndex = 8;
			label13.Text = "150 000 $";
			// 
			// lblPredictedPrice
			// 
			lblPredictedPrice.AutoSize = true;
			lblPredictedPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblPredictedPrice.Location = new Point(144, 76);
			lblPredictedPrice.Name = "lblPredictedPrice";
			lblPredictedPrice.Size = new Size(80, 20);
			lblPredictedPrice.TabIndex = 8;
			lblPredictedPrice.Text = "168 000 $";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(9, 76);
			label9.Name = "label9";
			label9.Size = new Size(129, 20);
			label9.TabIndex = 8;
			label9.Text = "Оценочная цена:";
			// 
			// panel4
			// 
			panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel4.BackColor = Color.MidnightBlue;
			panel4.Controls.Add(label8);
			panel4.Location = new Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new Size(330, 54);
			panel4.TabIndex = 7;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label8.ForeColor = SystemColors.Window;
			label8.Location = new Point(9, 10);
			label8.Name = "label8";
			label8.Size = new Size(199, 28);
			label8.TabIndex = 0;
			label8.Text = "Результаты оценки";
			// 
			// panel5
			// 
			panel5.BackColor = SystemColors.Window;
			panel5.Controls.Add(lblImpactNeighborhood);
			panel5.Controls.Add(lblImpactBrick);
			panel5.Controls.Add(lblImpactBathrooms);
			panel5.Controls.Add(lblImpactBedrooms);
			panel5.Controls.Add(lblImpactSqFt);
			panel5.Controls.Add(label18);
			panel5.Controls.Add(label17);
			panel5.Controls.Add(label16);
			panel5.Controls.Add(label15);
			panel5.Controls.Add(label14);
			panel5.Controls.Add(panel6);
			panel5.Dock = DockStyle.Fill;
			panel5.Location = new Point(339, 3);
			panel5.Name = "panel5";
			panel5.Size = new Size(331, 294);
			panel5.TabIndex = 1;
			// 
			// lblImpactNeighborhood
			// 
			lblImpactNeighborhood.AutoSize = true;
			lblImpactNeighborhood.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblImpactNeighborhood.ForeColor = Color.DarkGreen;
			lblImpactNeighborhood.Location = new Point(176, 206);
			lblImpactNeighborhood.Name = "lblImpactNeighborhood";
			lblImpactNeighborhood.Size = new Size(73, 20);
			lblImpactNeighborhood.TabIndex = 12;
			lblImpactNeighborhood.Text = "+7 000 $";
			// 
			// lblImpactBrick
			// 
			lblImpactBrick.AutoSize = true;
			lblImpactBrick.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblImpactBrick.ForeColor = Color.DarkGreen;
			lblImpactBrick.Location = new Point(176, 173);
			lblImpactBrick.Name = "lblImpactBrick";
			lblImpactBrick.Size = new Size(73, 20);
			lblImpactBrick.TabIndex = 12;
			lblImpactBrick.Text = "+7 000 $";
			// 
			// lblImpactBathrooms
			// 
			lblImpactBathrooms.AutoSize = true;
			lblImpactBathrooms.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblImpactBathrooms.ForeColor = Color.DarkGreen;
			lblImpactBathrooms.Location = new Point(176, 140);
			lblImpactBathrooms.Name = "lblImpactBathrooms";
			lblImpactBathrooms.Size = new Size(73, 20);
			lblImpactBathrooms.TabIndex = 12;
			lblImpactBathrooms.Text = "+7 000 $";
			// 
			// lblImpactBedrooms
			// 
			lblImpactBedrooms.AutoSize = true;
			lblImpactBedrooms.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblImpactBedrooms.ForeColor = Color.DarkGreen;
			lblImpactBedrooms.Location = new Point(176, 107);
			lblImpactBedrooms.Name = "lblImpactBedrooms";
			lblImpactBedrooms.Size = new Size(73, 20);
			lblImpactBedrooms.TabIndex = 12;
			lblImpactBedrooms.Text = "+7 000 $";
			// 
			// lblImpactSqFt
			// 
			lblImpactSqFt.AutoSize = true;
			lblImpactSqFt.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblImpactSqFt.ForeColor = Color.DarkGreen;
			lblImpactSqFt.Location = new Point(176, 74);
			lblImpactSqFt.Name = "lblImpactSqFt";
			lblImpactSqFt.Size = new Size(73, 20);
			lblImpactSqFt.TabIndex = 12;
			lblImpactSqFt.Text = "+7 000 $";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(22, 206);
			label18.Name = "label18";
			label18.Size = new Size(55, 20);
			label18.TabIndex = 11;
			label18.Text = "Район:";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(22, 173);
			label17.Name = "label17";
			label17.Size = new Size(126, 20);
			label17.TabIndex = 10;
			label17.Text = "Кирпичный дом:";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(22, 140);
			label16.Name = "label16";
			label16.Size = new Size(66, 20);
			label16.TabIndex = 9;
			label16.Text = "Ванные:";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(22, 107);
			label15.Name = "label15";
			label15.Size = new Size(72, 20);
			label15.TabIndex = 8;
			label15.Text = "Спальни:";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(22, 74);
			label14.Name = "label14";
			label14.Size = new Size(76, 20);
			label14.TabIndex = 8;
			label14.Text = "Площадь:";
			// 
			// panel6
			// 
			panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			panel6.BackColor = Color.MidnightBlue;
			panel6.Controls.Add(label11);
			panel6.Location = new Point(0, 0);
			panel6.Name = "panel6";
			panel6.Size = new Size(331, 54);
			panel6.TabIndex = 7;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label11.ForeColor = SystemColors.Window;
			label11.Location = new Point(9, 10);
			label11.Name = "label11";
			label11.Size = new Size(190, 28);
			label11.TabIndex = 0;
			label11.Text = "Факторы влияния";
			// 
			// lblModelState
			// 
			lblModelState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			lblModelState.AutoSize = true;
			lblModelState.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
			lblModelState.ForeColor = Color.DarkGreen;
			lblModelState.Location = new Point(536, 16);
			lblModelState.Name = "lblModelState";
			lblModelState.Size = new Size(130, 20);
			lblModelState.TabIndex = 3;
			lblModelState.Text = "Модель обучена";
			// 
			// ofd
			// 
			ofd.FileName = "openFileDialog1";
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Location = new Point(188, 16);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(66, 20);
			lblStatus.TabIndex = 4;
			lblStatus.Text = "lblStatus";
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(cartesianChart1);
			tabPage6.Location = new Point(4, 29);
			tabPage6.Name = "tabPage6";
			tabPage6.Size = new Size(659, 416);
			tabPage6.TabIndex = 5;
			tabPage6.Text = "Реальная цена vs Предсказанная";
			tabPage6.UseVisualStyleBackColor = true;
			// 
			// cartesianChart1
			// 
			cartesianChart1.AutoUpdateEnabled = true;
			cartesianChart1.ChartTheme = null;
			cartesianChart1.Dock = DockStyle.Fill;
			skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
			skDefaultLegend1.Content = null;
			skDefaultLegend1.IsValid = true;
			skDefaultLegend1.Opacity = 1F;
			padding1.Bottom = 0F;
			padding1.Left = 0F;
			padding1.Right = 0F;
			padding1.Top = 0F;
			skDefaultLegend1.Padding = padding1;
			skDefaultLegend1.RemoveOnCompleted = false;
			skDefaultLegend1.RotateTransform = 0F;
			skDefaultLegend1.X = 0F;
			skDefaultLegend1.Y = 0F;
			cartesianChart1.Legend = skDefaultLegend1;
			cartesianChart1.Location = new Point(0, 0);
			cartesianChart1.MatchAxesScreenDataRatio = false;
			cartesianChart1.Name = "cartesianChart1";
			cartesianChart1.Size = new Size(659, 416);
			cartesianChart1.TabIndex = 0;
			skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
			skDefaultTooltip1.Content = null;
			skDefaultTooltip1.IsValid = true;
			skDefaultTooltip1.Opacity = 1F;
			padding2.Bottom = 0F;
			padding2.Left = 0F;
			padding2.Right = 0F;
			padding2.Top = 0F;
			skDefaultTooltip1.Padding = padding2;
			skDefaultTooltip1.RemoveOnCompleted = false;
			skDefaultTooltip1.RotateTransform = 0F;
			skDefaultTooltip1.Wedge = 10;
			skDefaultTooltip1.X = 0F;
			skDefaultTooltip1.Y = 0F;
			cartesianChart1.Tooltip = skDefaultTooltip1;
			cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
			cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1068, 803);
			Controls.Add(lblStatus);
			Controls.Add(lblModelState);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(btnLoad);
			Controls.Add(btnLearn);
			Name = "Form1";
			Text = "Анализ стоимости недвижимости";
			tableLayoutPanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudActualPrice).EndInit();
			((System.ComponentModel.ISupportInitialize)nudBathrooms).EndInit();
			((System.ComponentModel.ISupportInitialize)nudBedrooms).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSqFt).EndInit();
			tableLayoutPanel2.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			tabPage1.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewCoeffs).EndInit();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
			tabPage5.ResumeLayout(false);
			tableLayoutPanel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewValidation).EndInit();
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			tabPage6.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnLearn;
		private Button btnLoad;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		private NumericUpDown nudBathrooms;
		private NumericUpDown nudBedrooms;
		private Label label3;
		private Label label2;
		private NumericUpDown nudSqFt;
		private Label label1;
		private Button btnCalculate;
		private Button btnReset;
		private NumericUpDown nudActualPrice;
		private Label label5;
		private ComboBox cmbNeighborhood;
		private CheckBox chkBrick;
		private Label label4;
		private TableLayoutPanel tableLayoutPanel2;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TabPage tabPage3;
		private Panel panel2;
		private Label label7;
		private Label lblModelState;
		private TableLayoutPanel tableLayoutPanel3;
		private Panel panel3;
		private Panel panel4;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label13;
		private Label lblPredictedPrice;
		private Button btnDecision;
		private Panel panel5;
		private Label label14;
		private Panel panel6;
		private Label label11;
		private Label lblImpactNeighborhood;
		private Label lblImpactBrick;
		private Label lblImpactBathrooms;
		private Label lblImpactBedrooms;
		private Label lblImpactSqFt;
		private Label label18;
		private Label label17;
		private Label label16;
		private Label label15;
		private Label lblFormula;
		private Label lblR2;
		private Label label32;
		private Panel panel7;
		private Label label31;
		private Label label30;
		private Label label29;
		private Label lblMSE;
		private Label lblMAE;
		private TabPage tabPage4;
		private DataGridView dataGridView1;
		private OpenFileDialog ofd;
		private Label lblStatus;
		private DataGridView dataGridViewHistory;
		private DataGridView dataGridViewCoeffs;
		private TableLayoutPanel tableLayoutPanel4;
		private Panel panel8;
		private Label label6;
		private Label lblDifference;
		private TabPage tabPage5;
		private DataGridView dataGridViewValidation;
		private TableLayoutPanel tableLayoutPanel5;
		private Panel panel9;
		private Label lblValidationMaxError;
		private Label lblValidationMSE;
		private Label lblValidationMAE;
		private Label lblValidationMinError;
		private TabPage tabPage6;
		private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
	}
}
