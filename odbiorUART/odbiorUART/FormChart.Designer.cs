namespace odbiorUART
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartWyniki = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxChoose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStopTime = new System.Windows.Forms.TextBox();
            this.textBoxPathPreview = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.textBoxMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartWyniki)).BeginInit();
            this.SuspendLayout();
            // 
            // chartWyniki
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWyniki.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWyniki.Legends.Add(legend1);
            this.chartWyniki.Location = new System.Drawing.Point(12, 113);
            this.chartWyniki.Name = "chartWyniki";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWyniki.Series.Add(series1);
            this.chartWyniki.Size = new System.Drawing.Size(793, 409);
            this.chartWyniki.TabIndex = 3;
            this.chartWyniki.Text = "chart1";
            // 
            // comboBoxChoose
            // 
            this.comboBoxChoose.FormattingEnabled = true;
            this.comboBoxChoose.Location = new System.Drawing.Point(12, 77);
            this.comboBoxChoose.Name = "comboBoxChoose";
            this.comboBoxChoose.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChoose.TabIndex = 4;
            this.comboBoxChoose.SelectedIndexChanged += new System.EventHandler(this.comboBoxChoose_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wybór podglądu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Czas początkowy pomiaru (HH:MM:SS)";
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Location = new System.Drawing.Point(190, 77);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(190, 20);
            this.textBoxStartTime.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
            // 
            // textBoxStopTime
            // 
            this.textBoxStopTime.Location = new System.Drawing.Point(437, 78);
            this.textBoxStopTime.Name = "textBoxStopTime";
            this.textBoxStopTime.Size = new System.Drawing.Size(190, 20);
            this.textBoxStopTime.TabIndex = 9;
            // 
            // textBoxPathPreview
            // 
            this.textBoxPathPreview.Location = new System.Drawing.Point(12, 25);
            this.textBoxPathPreview.Name = "textBoxPathPreview";
            this.textBoxPathPreview.Size = new System.Drawing.Size(231, 20);
            this.textBoxPathPreview.TabIndex = 10;
            this.textBoxPathPreview.Click += new System.EventHandler(this.textBoxPathPreview_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ścieżka do pliku:";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(271, 23);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 12;
            this.buttonOpen.Text = "Wyświetl";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // textBoxMin
            // 
            this.textBoxMin.Location = new System.Drawing.Point(731, 38);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(74, 20);
            this.textBoxMin.TabIndex = 13;
            // 
            // textBoxMax
            // 
            this.textBoxMax.Location = new System.Drawing.Point(731, 78);
            this.textBoxMax.Name = "textBoxMax";
            this.textBoxMax.Size = new System.Drawing.Size(74, 20);
            this.textBoxMax.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(731, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "min osi Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(731, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "max osi Y";
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Location = new System.Drawing.Point(645, 77);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(67, 20);
            this.textBoxMaxX.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "max osi X";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 534);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMaxX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMax);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPathPreview);
            this.Controls.Add(this.textBoxStopTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxChoose);
            this.Controls.Add(this.chartWyniki);
            this.Name = "FormChart";
            this.Text = "FormChart";
            ((System.ComponentModel.ISupportInitialize)(this.chartWyniki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWyniki;
        private System.Windows.Forms.ComboBox comboBoxChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStopTime;
        private System.Windows.Forms.TextBox textBoxPathPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.TextBox textBoxMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMaxX;
        private System.Windows.Forms.Label label7;
    }
}