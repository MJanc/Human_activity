using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Management;
using System.Globalization;


namespace odbiorUART
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPort;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


 
        static int counterMessages = 0;
        static int [] tabSamples = new int [500];
        static int [] tabHRV = new int[500];
        static int [] tabBreath = new int[500];
        static string[] time = new string[500];
        static string BPM, BPM2, HRV, Breath;
        static long UARTcounter = 0;
        static string lineToSave;
        static int resetAfterXTimes = 10;
        static int resetBreathAfterXTimes = 50;
        static int resetSamplesAfterXTimes = 1;
        static int counterResetChart = 0;
        static int counterResetChartSamples = 0;
        static int counterResetChartBreath = 0;
        static string selectedCOM;
        static string filename;
        DateTime localDate;

   
  

        /// ////////////////////////////////




        public Form1()
        {
            InitializeComponent();

            this.Text = "Pomiar tętna v. 1.0";

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxWyborCOM.Items.Add(port);
            }
            comboBoxWyborCOM.DropDownStyle = ComboBoxStyle.DropDownList;
            _serialPort = new SerialPort();

            textBoxHRV.ReadOnly = true;
            textBoxHRV.BackColor = System.Drawing.SystemColors.Window;
            textBoxBPM.ReadOnly = true;
            textBoxBPM.BackColor = System.Drawing.SystemColors.Window;

            chartWyniki.Titles.Add("Pomiar sygnału");
            chartHRV.Titles.Add("HRV");
            chartBreath.Titles.Add("Sygnał filtrowany");




        }

        private void chartWyniki_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {


                if (counterResetChartSamples >= resetSamplesAfterXTimes)
                {
                    foreach (var series in this.chartWyniki.Series)
                    {
                        series.Points.Clear();

                    }
                }
                if (counterResetChartBreath >= resetBreathAfterXTimes)
                {
                    foreach (var series in this.chartBreath.Series)
                    {
                        series.Points.Clear();

                    }
                }
                if (counterResetChart >= resetAfterXTimes)
                {
                    foreach (var series in this.chartHRV.Series)
                    {
                        series.Points.Clear();

                    }
                }


                for (int c = 0; c <= 499; c++)
                {
                    this.chartWyniki.Series["Series1"].Points.AddXY(time[c], Convert.ToString(tabSamples[c]));
                    this.chartBreath.Series["Series1"].Points.AddXY(time[c], Convert.ToString(tabBreath[c]));

                    this.chartHRV.Series["Series1"].Points.AddXY(time[c], Convert.ToString(tabHRV[c]));
                    this.textBoxBPM.Clear();
                    this.textBoxBPM.AppendText(BPM);
                    this.textBoxHRV.Clear();
                    this.textBoxHRV.AppendText(HRV);
                }

                if (counterResetChart >= resetAfterXTimes) counterResetChart = 0;
                if (counterResetChartSamples >= resetSamplesAfterXTimes) counterResetChartSamples = 0;
                if (counterResetChartBreath >= resetBreathAfterXTimes) counterResetChartBreath = 0;
                counterResetChart++;
                counterResetChartSamples++;
                counterResetChartBreath++;
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if(_serialPort.IsOpen)
                _serialPort.Close();
        }

        private void comboBoxWyborCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxWyborCOM.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxWyborCOM.Items.Add(port);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            localDate = DateTime.Now;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TXT|*.txt";
            saveFileDialog1.Title = "Zapisz pomiar";
            saveFileDialog1.FileName = "Wynik " + Convert.ToString(localDate).Substring(0,10) + " " + 
                                                Convert.ToString(localDate).Substring(11, 2) + "-" +
                                                Convert.ToString(localDate).Substring(14, 2) + "-" +
                                                Convert.ToString(localDate).Substring(17, 2);
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                filename = saveFileDialog1.FileName;
                textBoxPath.Text = filename;
                if (System.IO.File.Exists(@filename))
                    System.IO.File.Delete(@filename);
                localDate = DateTime.Now;
                var culture = new CultureInfo("de-DE");
                System.IO.File.AppendAllText(@filename, "///" + localDate.ToString(culture) + "///\r\n");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormChart form = new FormChart();
            form.Show();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            selectedCOM = comboBoxWyborCOM.Text;

            if (selectedCOM == "")
                MessageBox.Show("Nie wybrałeś portu COM.", "Brak wybranego portu COM");
 
            else
                {

                    {


           
                        _serialPort.PortName = selectedCOM;
                        _serialPort.BaudRate = 115200;
                        _serialPort.Parity = Parity.None;
                        _serialPort.DataBits = 8;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.Handshake = Handshake.None;
                        _serialPort.ReadBufferSize = 80;//6
                        _serialPort.NewLine = ";";

                        _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);


                        for (int count = 0; count < 500; count++)
                        {
                            time[count] = "00:00:00";
                        }

                        _serialPort.Open();
                        chartWyniki.ChartAreas[0].AxisY.Minimum = 0;
                        chartWyniki.ChartAreas[0].AxisY.Maximum = 3300;
                        chartWyniki.ChartAreas[0].AxisX.Title = "czas";
                        chartWyniki.ChartAreas[0].AxisY.Title = "U [mV]";
                    
                        



                    chartHRV.ChartAreas[0].AxisY.Minimum = 300;
                        chartHRV.ChartAreas[0].AxisY.Maximum = 1200;
                        chartHRV.ChartAreas[0].AxisX.Title = "czas";
                        chartHRV.ChartAreas[0].AxisY.Title = "okres [ms]";

                    //chartBreath.ChartAreas[0].AxisY.Minimum = 0;
                    //chartBreath.ChartAreas[0].AxisY.Maximum = 3300;
                    chartBreath.ChartAreas[0].AxisX.Title = "czas";
                    chartBreath.ChartAreas[0].AxisY.Title = "U [mV]";
                }

            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            int resolve,resolve3, resolve2;
            string newIndata, newIndata2, indata;

            char znak;
            indata = sp.ReadLine();
            if (indata == "" || indata == "0" || indata.Length != 32)
                resolve = 0;
            else
            {
                newIndata = indata.Substring(0, 4);
                newIndata2 = indata.Substring(5, 12);
                BPM = indata.Substring(18, 4);
                HRV = indata.Substring(23, 4);
                Breath = indata.Substring(indata.Length - 4, 4);

                if (!(int.TryParse(newIndata, out resolve))) resolve = 0;
                tabSamples[counterMessages] = resolve;

                    time[counterMessages] = newIndata2.Substring(0,8);

                if (!(int.TryParse(HRV, out resolve3))) resolve3 = 0;
                tabHRV[counterMessages] = resolve3;

                if (!(int.TryParse(Breath, out resolve2))) resolve2 = 0;
                tabBreath[counterMessages] = resolve2;


            }
  
            if (++counterMessages >= 500)
            {
                counterMessages = 0;
                
                if (!(this.backgroundWorker1.IsBusy))
                    this.backgroundWorker1.RunWorkerAsync();
            }
            UARTcounter++;

            lineToSave = indata + "\r\n";

            if(!String.IsNullOrEmpty(filename) && !String.IsNullOrEmpty(textBoxPath.Text))
                System.IO.File.AppendAllText(@filename, lineToSave);

        }
    }
}
