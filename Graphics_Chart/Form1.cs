using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void form1_Load(object sender, EventArgs e)
        {
            buildGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buildGraphics();
        }

        //строим график
        private void buildGraphics()
        {
            float minPoint = (float)Convert.ToDouble(textBox1.Text);
            float maxPoint = (float)Convert.ToDouble(textBox2.Text);
            float step = 0.1f;
            float x, y;

            chart1.Series["sin(x)"].Points.Clear();
            chart1.Series["cos(x)"].Points.Clear();
            chart1.Series[2].Points.Clear();

            scaleGraphics(minPoint, maxPoint);

            if (checkBox1.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x += step)
                {
                    chart1.Series[0].Points.AddXY(x, Math.Sin(x));
                }

            }

            if (checkBox2.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x += step)
                {
                    chart1.Series[1].Points.AddXY(x, Math.Cos(x));
                }

            }

            if (checkBox3.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x += step)
                {
                    chart1.Series[2].Points.AddXY(x, (Math.Sin(x) + Math.Cos(x)));
                }
            }
        }


        //масштабируем график
        private void scaleGraphics(float minPoint, float maxPoint)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(minPoint, maxPoint);//диапазон масштабирования
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;//включение интервала масштабирования
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;//включение масштабирования
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;//полоса прокрутки

            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(-1, 1);
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;//полоса прокрутки

        }
        int N = 199;//последняя добавленная точка на графике
        private void timer1_Tick(object sender, EventArgs e)
        {
            N++;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, N);//minPoint  0
            chart1.Series[0].Points.RemoveAt(0);//удаление крайней левой точки
            chart1.Series[0].Points.AddXY(N, Math.Sin(N));
            chart1.ChartAreas[0].AxisX.Minimum = N - 200;
            chart1.ChartAreas[0].AxisX.Maximum = N;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button2.Text = "Стоп";

            }
            else
            {
                timer1.Enabled = false;
                button2.Text = "Пуск";
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Interval = hScrollBar1.Value;

        }
    }
}
