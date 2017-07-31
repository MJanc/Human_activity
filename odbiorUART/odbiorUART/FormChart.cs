using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odbiorUART
{
    public partial class FormChart : Form
    {
        static string filepath;
        static string time;
        static int chartY;
        static double chartYdouble;
        static int tryToParse;
        static int sampleNumber;

        static double[] x; 
        static double[] Xre; 
        static double[] Xim; 
        static double[] score;
        static int lineCounter;
        static int DFTprobes;
        static int DFTCountTo;

        TimeSpan startTime;
        TimeSpan stopTime;
        TimeSpan currentTime;






        void calculateDFT(int N)
        {
            int k, n;


                for (k = 0; k < N / 2; k++)
                {
                    Xre[k] = 0;
                    for (n = 0; n < N; n++)
                    {
                        Xre[k] += x[n] * System.Math.Cos(2 * n * k * System.Math.PI / N);
                    }

                    Xim[k] = 0;
                    for (n = 0; n < N; n++)
                    {
                        Xim[k] -= x[n] * System.Math.Sin(2 * n * k * System.Math.PI / N);
                    }

                    score[k] = System.Math.Sqrt(Xre[k] * Xre[k] + Xim[k] * Xim[k]);
                    score[k] = 2 * score[k] / N;
                }
        }



        public FormChart()
        {
            InitializeComponent();
            this.Text = "Pomiar tętna v. 1.0 - podgląd pliku";
            comboBoxChoose.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChoose.Items.Add("Próbki");
            comboBoxChoose.Items.Add("BPM");
            comboBoxChoose.Items.Add("HRV");
            comboBoxChoose.Items.Add("Oddech");
            comboBoxChoose.Items.Add("FFT przebiegu sygnału");
            textBoxStartTime.Text = "00:00:00";
            textBoxStopTime.Text = "23:59:59";
            textBoxMaxX.Visible = false;
            label7.Visible = false;
 
        }

        private void comboBoxChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineCounter = 0;
            switch (comboBoxChoose.SelectedIndex)
            {
                case 0:
                    label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
                    label7.Visible = false;
                    textBoxMaxX.Visible = false;
                    textBoxStopTime.Text = "23:59:59";
                    break;
                case 1:
                    label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
                    textBoxStopTime.Text = "23:59:59";
                    label7.Visible = false;
                    textBoxMaxX.Visible = false;

                    break;
                case 2:
                    label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
                    label7.Visible = false;
                    textBoxStopTime.Text = "23:59:59";
                    textBoxMaxX.Visible = false;

                    break;
                case 3:
                    label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
                    label7.Visible = false;
                    textBoxStopTime.Text = "23:59:59";
                    textBoxMaxX.Visible = false;

                    break;
                case 4:
                    label3.Text = "Liczba próbek";
                    label7.Visible = true;
                    textBoxStopTime.Text = "1024";
                    textBoxMaxX.Visible = true;
                    break;
                default:
                    label3.Text = "Czas końcowy pomiaru (HH:MM:SS)";
                    textBoxStopTime.Text = "23:59:59";
                    label7.Visible = false;
                    textBoxMaxX.Visible = false;
                    break;
            }
        }

        private void textBoxPathPreview_TextChanged(object sender, EventArgs e)
        {
            lineCounter = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Odczytaj pomiar";
            openFileDialog1.Filter = "TXT (*.txt)|*.txt";
            openFileDialog1.ShowDialog();

            filepath = openFileDialog1.FileName;
            if (openFileDialog1.FileName != "")
            {
                textBoxPathPreview.Text = filepath;
            }



        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {



            if (String.IsNullOrEmpty(filepath) || String.IsNullOrEmpty(textBoxPathPreview.Text))
            {
                MessageBox.Show("Pusta lokalizacja pliku do wczytania.", "Brak lokalizacji");
            }
            else
            {
                switch (comboBoxChoose.SelectedIndex)
                {
                    case 0:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("Pomiar");
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "U [mV]";
                        break;
                    case 1:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("BPM");
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "uderzenia na minutę [-]";
                        break;
                    case 2:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("HRV");
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "okres [ms]";
                        break;
                    case 3:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("Sygnał odfiltrowany");
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "U [mV]";
                        break;
                    case 4:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("FFT");
                        chartWyniki.ChartAreas[0].AxisX.Title = "częstotliwość [Hz]";
                        chartWyniki.ChartAreas[0].AxisY.Title = "wielkość widma";
                        break;
                    default:
                        chartWyniki.Titles.Clear();
                        chartWyniki.Titles.Add("Pomiar");
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "U [mV]";
                        break;
                }





                foreach (var series in chartWyniki.Series)
                {
                    series.Points.Clear();

                }


                if (comboBoxChoose.SelectedIndex == 4 && Int32.TryParse(textBoxStopTime.Text, out sampleNumber))
                {

                    x = new double[sampleNumber];
                    Xre = new double[sampleNumber];
                    Xim = new double[sampleNumber];
                    score = new double[sampleNumber];

                }


                if (textBoxStartTime.Text.Length == 8
                            && Int32.TryParse(textBoxStartTime.Text.Substring(0, 2), out tryToParse)
                            && Int32.TryParse(textBoxStartTime.Text.Substring(3, 2), out tryToParse)
                            && Int32.TryParse(textBoxStartTime.Text.Substring(6, 2), out tryToParse)

                    && ((textBoxStopTime.Text.Length == 8
                            && Int32.TryParse(textBoxStopTime.Text.Substring(0, 2), out tryToParse)
                            && Int32.TryParse(textBoxStopTime.Text.Substring(3, 2), out tryToParse)
                            && Int32.TryParse(textBoxStopTime.Text.Substring(6, 2), out tryToParse))
                    || comboBoxChoose.SelectedIndex == 4 ))
                {

                    var lines = System.IO.File.ReadLines(@filepath);
                    lineCounter = 0;
                    foreach (var line in lines)
                    {
                        if (line.Length == 32)
                        {

                                time = line.Substring(5, 8);

                                startTime = new TimeSpan(Convert.ToInt32(textBoxStartTime.Text.Substring(0, 2)),
                                Convert.ToInt32(textBoxStartTime.Text.Substring(3, 2)),
                                Convert.ToInt32(textBoxStartTime.Text.Substring(6, 2)));

                                currentTime = new TimeSpan(Convert.ToInt32(time.Substring(0, 2)),
                                Convert.ToInt32(time.Substring(3, 2)),
                                Convert.ToInt32(time.Substring(6, 2)));

                            if (comboBoxChoose.SelectedIndex != 4)
                            {
                                stopTime = new TimeSpan(Convert.ToInt32(textBoxStopTime.Text.Substring(0, 2)),
                                Convert.ToInt32(textBoxStopTime.Text.Substring(3, 2)),
                                Convert.ToInt32(textBoxStopTime.Text.Substring(6, 2)));
                            }


                            switch (comboBoxChoose.SelectedIndex)
                            {
                                case 0:
                                    chartY = Convert.ToInt32(line.Substring(0, 4));
                                    break;
                                case 1:
                                    chartY = Convert.ToInt32(line.Substring(18, 4));
                                    break;
                                case 2:
                                    chartY = Convert.ToInt32(line.Substring(23, 4));
                                    break;
                                case 3:
                                    chartY = Convert.ToInt32(line.Substring(line.Length - 4, 4));
                                    break;
                                case 4:
                                    if(Int32.TryParse(textBoxStopTime.Text, out sampleNumber) && sampleNumber > lineCounter)
                                        x[lineCounter] = Convert.ToInt32(line.Substring(0, 4));
                                    break;
                                default:
                                    chartY = Convert.ToInt32(line.Substring(0, 4));
                                    break;
                            }


                            if (comboBoxChoose.SelectedIndex != 4)
                            {
                                if (TimeSpan.Compare(currentTime, startTime) > 0 && TimeSpan.Compare(currentTime, stopTime) < 0)
                                    chartWyniki.Series["Series1"].Points.AddXY(time, chartY);
                            }


                            if(TimeSpan.Compare(currentTime, startTime) > 0 && lineCounter < sampleNumber) lineCounter++;
                        }
                        
                    }
                    if (comboBoxChoose.SelectedIndex == 4 && Int32.TryParse(textBoxStopTime.Text, out sampleNumber))
                    {
                        if (sampleNumber > lineCounter) MessageBox.Show("Liczba próbek wybrana do analizy przekroczyła liczbę próbek pomiaru", "Niewłaściwa liczba próbek");
                        else
                        {
                            calculateDFT(lineCounter);
                            if ((String.IsNullOrEmpty(textBoxMaxX.Text) || textBoxMaxX.Text == "0") && !(int.TryParse(textBoxMaxX.Text, out DFTprobes)))
                            {
                                for (int s = 0; s < lineCounter; s++)
                                    chartWyniki.Series["Series1"].Points.AddXY(((s + 1) * 200.0 / sampleNumber), score[s]);
                            }
                            else if (int.TryParse(textBoxMaxX.Text, out DFTprobes) && DFTprobes < sampleNumber)
                            {
                                DFTCountTo = Convert.ToInt32(((DFTprobes) * sampleNumber / 200.0));
                                for (int s = 0; s < DFTCountTo; s++)
                                    chartWyniki.Series["Series1"].Points.AddXY(((s + 1) * 200.0 / sampleNumber), score[s]);
                            }
                        }
                    }




                }
                else MessageBox.Show("Błędnie podany czas.","Błąd czasu");
                switch (comboBoxChoose.SelectedIndex)
                {
                    case 0:
                        chartWyniki.ChartAreas[0].AxisY.Minimum = 0;
                        chartWyniki.ChartAreas[0].AxisY.Maximum = 3300;
                        break;
                    case 1:
                        chartWyniki.ChartAreas[0].AxisY.Minimum = 40;
                        chartWyniki.ChartAreas[0].AxisY.Maximum = 200;
                        break;
                    case 2:
                        chartWyniki.ChartAreas[0].AxisY.Minimum = 300;
                        chartWyniki.ChartAreas[0].AxisY.Maximum = 1200;
                        break;
                    default:
                        chartWyniki.ChartAreas[0].AxisY.Minimum = 0;
                        chartWyniki.ChartAreas[0].AxisY.Maximum = 3300;
                        break;
                }
                if (!String.IsNullOrEmpty(textBoxMin.Text))
                {
                    chartWyniki.ChartAreas[0].AxisY.Minimum = Convert.ToInt32(textBoxMin.Text);
                }
                if (!String.IsNullOrEmpty(textBoxMax.Text))
                {
                    chartWyniki.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(textBoxMax.Text);
                }

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
