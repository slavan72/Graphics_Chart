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

            if (checkBox1.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x+=step) {
                    y = (float)Math.Sin(x);
                    chart1.Series[0].Points.AddXY(x, y);
                }
                
            }

            if (checkBox2.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x += step)
                {
                    y = (float)Math.Cos(x);
                    chart1.Series[0].Points.AddXY(x, y);
                }

            }

            if (checkBox3.Checked == true)
            {
                for (x = minPoint; x < maxPoint; x += step)
                {
                    y = (float)(Math.Sin(x) + Math.Cos(x));
                    chart1.Series[0].Points.AddXY(x, y);
                }

            }
        }
    }
}
