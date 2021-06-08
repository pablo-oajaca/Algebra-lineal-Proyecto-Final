using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Algebra_lineal_Proyecto_Final
{
    public partial class Form1 : Form
    {
        List<Poblacion> poblacions = new List<Poblacion>();
        List<Calculo> calculos = new List<Calculo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            FileStream stream = new FileStream(@"..\..\poblacion.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while(reader.Peek() > -1)
            {
                Poblacion poblacion = new Poblacion();

                poblacion.Edades = reader.ReadLine();
                poblacion.PoblacionInicial1 = reader.ReadLine();
                poblacion.PorcentajeNatalidad1 = reader.ReadLine();
                poblacion.PorcentajeSupervivencia1 = reader.ReadLine();


                poblacions.Add(poblacion);

            }
            reader.Close();
        }
        private void Mostrar()
        {
            calculos.Clear();

            foreach(var poblacion in poblacions)
            {
                Calculo calculo = new Calculo();

                calculo.Edades = poblacion.Edades;
                calculo.PoblacionInicial1 = poblacion.PoblacionInicial1;
                calculo.PorcentajeNatalidad1 = poblacion.PorcentajeNatalidad1;
                calculo.PorcentajeSupervivencia1 = poblacion.PorcentajeSupervivencia1;

                calculos.Add(calculo);


            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = calculos;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // chart1.Series["Niños"].Points.Clear();
            //chart1.Series["Jovenes"].Points.Clear();
            //chart1.Series["Adultos"].Points.Clear();
            //chart1.Series["Mayores"].Points.Clear();


            for (int j= 0; j<100; j++)
            {
              //  chart1.Series["Niños"].Points.AddXY(j, j+1);
               // chart1.Series["Jovenes"].Points.AddXY(j, j +1);
                //chart1.Series["Adultos"].Points.AddXY(j, j +1);
                //chart1.Series["Mayores"].Points.AddXY(j, j +1);

            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            //chart1.Series["Niños"].Points.Clear();
            //chart1.Series["Jovenes"].Points.Clear();
           // chart1.Series["Adultos"].Points.Clear();
            //chart1.Series["Mayores"].Points.Clear();

            string[] series = { "niños", "jovenes", "adultos", "mayores" };
            double[] puntos = { 5899702, 3357330, 2417467, 397029 };

            
            
            chart1.Palette = ChartColorPalette.Pastel;



            for(int i= 0; i<series.Length; i++)
            {
                Series serie = chart1.Series.Add(series[i]);

                serie.Label = puntos[i].ToString();
                serie.Points.Add(puntos[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            objChart.AxisX.Minimum = 2014;
            objChart.AxisX.Maximum = 2025;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 3000000;

            chart1.Series.Clear();

            Random random = new Random();

            foreach(Poblacion p in poblacionBindingSource.DataSource as List<Poblacion>)
            {
                chart1.Series.Add(p.PoblacionInicial1);
                chart1.Series[p.PoblacionInicial1].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                chart1.Series[p.PoblacionInicial1].Legend = "Legend1";
                chart1.Series[p.PoblacionInicial1].ChartArea = "ChartArea1";
                chart1.Series[p.PoblacionInicial1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                for(int i =2014; i<=2025; i++)
                {
                    chart1.Series[p.PoblacionInicial1].Points.AddXY(i, Convert.ToInt32(p[$"PoblacionInicial{i}"]));
                }


            }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
