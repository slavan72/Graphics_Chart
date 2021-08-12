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

        private void button1_Click(object sender, EventArgs e)
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

    }
}
