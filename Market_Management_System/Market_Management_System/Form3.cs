using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_Management_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {

        }

        private void label4_exit_MouseEnter(object sender, EventArgs e)
        {
            label4_exit.ForeColor = Color.Red;
        }

        private void label4_exit_MouseLeave(object sender, EventArgs e)
        {
            label4_exit.ForeColor = Color.ForestGreen;
        }

        private void label_clear_MouseEnter(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Red;
        }

        private void label_clear_MouseLeave(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Goldenrod;
        }

        private void label4_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show(" Enter the Username and Password ");


            }
            else
            {
                if (comboBox_Role.SelectedIndex > -1)
                {
                    if (comboBox_Role.SelectedItem.ToString() == "Manager")
                    {
                        if (textBox_username.Text == "Admin" && textBox_password.Text == "Danger1234")
                        {
                            Form4 Prod = new Form4();
                            Prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are the Admin, Enter The correct Id and Password");
                       

}



                    }
                    else
                    {
                        //MessageBox.Show(" You are in The seller Section ")
                    }
                }
                else
                {
                    MessageBox.Show("Select A role ");
                }
            }



            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show(" Enter the Username and Password ");


            }
            else
            {
                if (comboBox_Role.SelectedIndex > -1)
                {
                    if (comboBox_Role.SelectedItem.ToString() == "Employee")
                    {
                        if (textBox_username.Text == "Admin" && textBox_password.Text == "Emp24")
                        {
                            Form8 Cus = new Form8();
                            Cus.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If you are the Employee, Enter The correct Id and Password");


                        }



                    }
                    else
                    {
                        //MessageBox.Show(" You are in The seller Section ")
                    }
                }
                else
                {
                    MessageBox.Show("Select A role ");
                }
            }






        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            textBox_username.Text = "";
            textBox_password.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm3 = new Form3();
            fm3.Show();
        }
    }
}
