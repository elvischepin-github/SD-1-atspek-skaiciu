using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtspekSkaiciu
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int atsitiktinisSkaicius;
        public Form1()
        {
            InitializeComponent();

            trackBar1.Enabled = false;
            trackBar2.Enabled = false;
            trackBar3.Enabled = false;
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int pasirinktasSkaicius = Convert.ToInt32(numericUpDown1.Value);
            atsitiktinisSkaicius = random.Next(1, pasirinktasSkaicius);

            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;

            trackBar1.Minimum = 1;
            trackBar1.Maximum = Convert.ToInt32(numericUpDown1.Value);
            trackBar1.Value = 1;
            label1.Text = trackBar1.Value.ToString();

            trackBar2.Minimum = 1;
            trackBar2.Maximum = Convert.ToInt32(numericUpDown1.Value);
            trackBar2.Value = Convert.ToInt32(numericUpDown1.Value);
            label2.Text = trackBar2.Value.ToString();

            trackBar3.Enabled = true;
            trackBar3.Minimum = 1;
            trackBar3.Maximum = Convert.ToInt32(numericUpDown1.Value);
            trackBar3.Value = 1;
            label3 .Text = trackBar3.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int minValue = trackBar1.Value;
            int maxValue = trackBar2.Value;

            if (trackBar3.Value < minValue)
            {
                trackBar3.Value = minValue;
            }
            else if (trackBar3.Value > maxValue)
            {
                trackBar3.Value = maxValue;
            }

            label3.Text = trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int mazesnysis = 1, didesnysis = Convert.ToInt32(numericUpDown1.Value);

            if (trackBar3.Value == atsitiktinisSkaicius)
            {
                label4.BackColor = Color.Green;
                label4.Text = "Atspėjote!";
                button2.Enabled = false;
                button3.Enabled = true;
            }
            else if (trackBar3.Value < atsitiktinisSkaicius)
            {
                label4.BackColor = Color.Red;
                label4.Text = "Skaičius yra didesnis!";

                if(didesnysis > trackBar3.Value)
                {
                    didesnysis = trackBar3.Value;
                    trackBar1.Value = didesnysis;
                }
            }
            else if (trackBar3.Value > atsitiktinisSkaicius)
            {
                label4.BackColor = Color.Red;
                label4.Text = "Skaičius yra mažesnis!";

                if (mazesnysis < trackBar3.Value)
                {
                    mazesnysis = trackBar3.Value;
                    trackBar2.Value = mazesnysis;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            label4.Text = "";
            label4.BackColor = SystemColors.Control;
            trackBar1.Enabled = false;
            trackBar1.Value = 1;
            label1.Text = "";
            trackBar2.Enabled = false;
            trackBar2.Value = 1;
            label2.Text = "";
            trackBar3.Enabled = false;
            trackBar3.Value = 1;
            label3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //numericUpDown1.Minimum = 10;
            //numericUpDown1.Maximum = 10000;
        }
    }
}
