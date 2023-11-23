using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Market_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick1(object sender, EventArgs e)
        {
            startPoint += 1;

            progressBar1.Value = startPoint;

            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                Form3 log = new Form3();
                this.Hide();
                log.Show();

            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

