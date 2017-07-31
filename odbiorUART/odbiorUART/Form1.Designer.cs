namespace odbiorUART
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda wsparcia projektanta - nie należy modyfikować
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonStart = new System.Windows.Forms.Button();
            this.comboBoxWyborCOM = new System.Windows.Forms.ComboBox();
            this.chartWyniki = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxBPM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHRV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chartHRV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chartBreath = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartWyniki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHRV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBreath)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 132);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(105, 64);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Rozpocznij transmisję";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxWyborCOM
            // 
            this.comboBoxWyborCOM.FormattingEnabled = true;
            this.comboBoxWyborCOM.Location = new System.Drawing.Point(15, 28);
            this.comboBoxWyborCOM.Name = "comboBoxWyborCOM";
            this.comboBoxWyborCOM.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWyborCOM.TabIndex = 1;
            this.comboBoxWyborCOM.Click += new System.EventHandler(this.comboBoxWyborCOM_SelectedIndexChanged);
            // 
            // chartWyniki
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWyniki.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWyniki.Legends.Add(legend1);
            this.chartWyniki.Location = new System.Drawing.Point(265, 69);
            this.chartWyniki.Name = "chartWyniki";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWyniki.Series.Add(series1);
            this.chartWyniki.Size = new System.Drawing.Size(632, 201);
            this.chartWyniki.TabIndex = 2;
            this.chartWyniki.Text = "chart1";
            this.chartWyniki.Click += new System.EventHandler(this.chartWyniki_Click);
            // 
            // textBoxBPM
            // 
            this.textBoxBPM.Location = new System.Drawing.Point(244, 29);
            this.textBoxBPM.Name = "textBoxBPM";
            this.textBoxBPM.Size = new System.Drawing.Size(61, 20);
            this.textBoxBPM.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "BPM";
            // 
            // textBoxHRV
            // 
            this.textBoxHRV.Location = new System.Drawing.Point(398, 29);
            this.textBoxHRV.Name = "textBoxHRV";
            this.textBoxHRV.Size = new System.Drawing.Size(72, 20);
            this.textBoxHRV.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "HRV [ms]";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chartHRV
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHRV.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartHRV.Legends.Add(legend2);
            this.chartHRV.Location = new System.Drawing.Point(265, 276);
            this.chartHRV.Name = "chartHRV";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartHRV.Series.Add(series2);
            this.chartHRV.Size = new System.Drawing.Size(632, 201);
            this.chartHRV.TabIndex = 10;
            this.chartHRV.Text = "chart1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(144, 132);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(105, 64);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Zatrzymaj transmisję";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(12, 96);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(237, 20);
            this.textBoxPath.TabIndex = 12;
            this.textBoxPath.Click += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Ścieżka zapisu pomiarów:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Podgląd wyników z pliku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartBreath
            // 
            chartArea3.Name = "ChartArea1";
            this.chartBreath.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartBreath.Legends.Add(legend3);
            this.chartBreath.Location = new System.Drawing.Point(265, 483);
            this.chartBreath.Name = "chartBreath";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartBreath.Series.Add(series3);
            this.chartBreath.Size = new System.Drawing.Size(632, 201);
            this.chartBreath.TabIndex = 15;
            this.chartBreath.Text = "chartBreath";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 695);
            this.Controls.Add(this.chartBreath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.chartHRV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHRV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBPM);
            this.Controls.Add(this.chartWyniki);
            this.Controls.Add(this.comboBoxWyborCOM);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartWyniki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHRV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBreath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ComboBox comboBoxWyborCOM;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWyniki;
        private System.Windows.Forms.TextBox textBoxBPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHRV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHRV;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBreath;
    }
}

