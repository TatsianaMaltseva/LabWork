using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Anal
{
    public partial class Form1 : Form
    {
        class Data1Graph
        {
            public double values { get; set; }
            public double date { get; set; }
        }
        class Data2Graph
        {
            public double values { get; set; }
            public double date { get; set; }
        }

        List<Data1Graph> datas1;
        List<Data2Graph> datas2;

        public Form1()
        {
            InitializeComponent();
            datas1 = new List<Data1Graph>() // Массив с U от d
            {
                new Data1Graph(){ values = 77.9, date = 0.1 },
                new Data1Graph(){ values = 195.6, date = 0.2 },
                new Data1Graph(){ values = 196.1, date = 0.3 },
                new Data1Graph(){ values = 196.4, date = 0.4 },
                new Data1Graph(){ values = 196.7, date = 0.5 },
                new Data1Graph(){ values = 196.9, date = 0.6 },
                new Data1Graph(){ values = 197.0, date = 0.7 },
                new Data1Graph(){ values = 197.1, date = 0.8 },
                new Data1Graph(){ values = 197.2, date = 0.9 },
                new Data1Graph(){ values = 197.3, date = 1.0 },
                new Data1Graph(){ values = 197.4, date = 1.1 },
                new Data1Graph(){ values = 197.4, date = 1.2 },
                new Data1Graph(){ values = 197.5, date = 1.3 },
                new Data1Graph(){ values = 197.5, date = 1.4 },
                new Data1Graph(){ values = 197.6, date = 1.5 },
                new Data1Graph(){ values = 197.6, date = 1.6 },
                new Data1Graph(){ values = 197.6, date = 1.7 },
                new Data1Graph(){ values = 197.6, date = 1.8 },
                new Data1Graph(){ values = 197.7, date = 1.9 },
                new Data1Graph(){ values = 197.7, date = 2.0 },
                new Data1Graph(){ values = 197.7, date = 2.1 },
                new Data1Graph(){ values = 197.7, date = 2.2 },
                new Data1Graph(){ values = 197.7, date = 2.3 },
                new Data1Graph(){ values = 197.7, date = 2.4 },
                new Data1Graph(){ values = 197.8, date = 2.5 },
                new Data1Graph(){ values = 197.8, date = 2.6 },
                new Data1Graph(){ values = 197.8, date = 2.7 },
                new Data1Graph(){ values = 197.8, date = 2.8 },
                new Data1Graph(){ values = 197.8, date = 2.9 },
                new Data1Graph(){ values = 197.8, date = 3.0 },
            };

            datas2 = new List<Data2Graph>() // Массив с hv от G
            {
                new Data2Graph(){ values = 0.0005, date = 1.409 },
                new Data2Graph(){ values = 0.0005, date = 1.512 },
                new Data2Graph(){ values = 0.0039, date = 1.625 },
                new Data2Graph(){ values = 0.0820, date = 1.722 },
                new Data2Graph(){ values = 0.3333, date = 1.799 },
                new Data2Graph(){ values = 0.6374, date = 1.873 },
                new Data2Graph(){ values = 1.0000, date = 1.947 },
                new Data2Graph(){ values = 0.8703, date = 2.023 },
                new Data2Graph(){ values = 0.1492, date = 2.095 },
                new Data2Graph(){ values = 0.1027, date = 2.164 },
                new Data2Graph(){ values = 0.0697, date = 2.226 },
                new Data2Graph(){ values = 0.0504, date = 2.292 },
                new Data2Graph(){ values = 0.0347, date = 2.357 },
                new Data2Graph(){ values = 0.0203, date = 2.431 },
                new Data2Graph(){ values = 0.0139, date = 2.489 },
                new Data2Graph(){ values = 0.0104, date = 2.546 },
                new Data2Graph(){ values = 0.0087, date = 2.599 },
                new Data2Graph(){ values = 0.0064, date = 2.649 },
                new Data2Graph(){ values = 0.0072, date = 2.696 },
            };
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WidthSignal();
        }
        private void WidthSignal()
        {
            SeriesCollection series = new SeriesCollection();
            ChartValues<double> zp = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<string> date = new List<string>(); //здесь будут храниться значения для оси X
            foreach (var item in datas1)
            {
                zp.Add(item.values);
                date.Add(item.date.ToString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "d, mm",
                Labels = date
            });
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis //Добавляем на ось Y значения, через блок инициализатора.
            {
                Title = "U, mV",
            });

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PhotoconductivityDependence();
        }

        private void PhotoconductivityDependence()
        {
            SeriesCollection series = new SeriesCollection();
            ChartValues<double> zp = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<string> date = new List<string>(); //Здесь будут храниться значения для оси X
            foreach (var item in datas2)
            {
                zp.Add(item.values);
                date.Add(item.date.ToString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "hv, эВ",
                Labels = date
            });
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis //Добавляем на ось Y значения, через блок инициализатора.
            {
                Title = "G, per-unit",
            });

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            int line = 0;
            List<double> alpha = new List<double>() { 3300, 3200, 3100, 3000, 2900, 2800, 2700, 2600, 2500, 2400, 2300, 2200, 2100,
            2000, 1900, 1800, 1700, 1600, 1500 };
            List<double> L = new List<double>() { 0.880, 0.820, 0.763, 0.720, 0.689, 0.662, 0.637, 0.613, 0.592, 0.573, 0.557, 0.541, 
            0.526, 0.510, 0.498, 0.487, 0.477, 0.468, 0.460 };
            List<double> hv = new List<double>();
            for (int i = 0; i < L.Count; i++)
            {
                hv.Add(1.24 / L[i]);
            }
            List<double> U = new List<double>() { 0.1, 0.1, 0.7, 13.2, 48.5, 84.3, 119.0, 91.8, 14.0, 8.5, 5.2, 3.3, 2.0, 1.0, 0.6, 0.4, 
            0.3, 0.2, 0.2 };
            List<double> I = new List<double>() { 0.766, 0.732, 0.657, 0.595, 0.538, 0.489, 0.440, 0.390, 0.347, 0.306, 0.276, 0.242, 
            0.213, 0.182, 0.160, 0.142, 0.127, 0.115, 0.103 };
            List<double> U_I = new List<double>();
            double uMax = 0;
            for (int i = 0; i < L.Count; i++)
            {
                U_I.Add(U[i] / I[i]);
                if (uMax < U_I[i])
                {
                    uMax = U_I[i];
                }
            }
            List<double> G = new List<double>();
            for (int i = 0; i < L.Count; i++)
            {
                G.Add(U_I[i] / uMax);
            }
            for (int i = 0; i < alpha.Count; i++)
            {
                if (Math.Round(Convert.ToDouble(text)) == alpha[i])
                {
                    line = i;
                    break;
                }
            }
            if (Convert.ToInt32(text) <= 3300 && Convert.ToInt32(text) >= 1500 )
            {
                label2.Text = $"L = {L[line].ToString()} μm";
                label3.Text = $"hv = {Math.Round(hv[line], 6).ToString()} eV";
                label4.Text = $"U = {U[line].ToString()} mV";
                label5.Text = $"U/I = {Math.Round(U_I[line], 6).ToString()}^10e-3 per-unit";
                label6.Text = $"G = {Math.Round(G[line], 6).ToString()} per-unit";
                label7.Text = "Valid values are [1500; 3300]";
            }
            else
            {
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "Please enter a number \nbetween 1500 and 3300.";
            }
        }

        private void textBox1_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // можно нажимать только цифры и клавишн BackSpace
            {
                e.Handled = true;
            }
        }
    }
}