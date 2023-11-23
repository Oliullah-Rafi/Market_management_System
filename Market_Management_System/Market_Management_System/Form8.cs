using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Market_Management_System
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GSN7C0A;Initial Catalog=MarketDB;Integrated Security=True");

        public int Cserial;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Cust = new Form4();
            Cust.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer_TB1 VALUES (@Cname, @Cid, @Cphone,@Ctype,@Cpayoption)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Cname", txtCusName.Text);
                cmd.Parameters.AddWithValue("@Cid", txtCusId.Text);
                cmd.Parameters.AddWithValue("@Cphone", txtCusPhone.Text);
                cmd.Parameters.AddWithValue("@Ctype", txtCusType1.Text);
                cmd.Parameters.AddWithValue("@Cpayoption", txtCusPoption1.Text);



                if (comboBox1.SelectedIndex > -1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Old_Customer")
                    {
                        label7.Visible = true;
                   

                      

                    }
                }
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("New Customer inserted", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerRecordsRecord();
                ResetFormControls();
            }


        }
        private bool isValid()
        {
            if (txtCusName.Text == string.Empty)
            {
                MessageBox.Show("Customer name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 fm8 = new Form8();
            fm8.Show();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            GetCustomerRecordsRecord();
        }

        private void GetCustomerRecordsRecord()
        {


            SqlCommand cmd = new SqlCommand("Select * from Customer_TB1", con);

            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Cserial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE Customer_TB1  WHERE Cserial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.Cserial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Customer is deleted from the record ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Customer to delete", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            Cserial = 0;
            txtCusName.Clear();
            txtCusId.Clear();
            txtCusPhone.Clear();

            txtCusPoption1.Clear();
            

              txtCusType1.Clear();

            txtCusName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cserial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customer_TB1 SET Cname = @CName, Cid = @Cid, Cphone = @Cphone,Ctype = @Ctype,Cpayoption = @Cpayoption WHERE Cserial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CName", txtCusName.Text);
                cmd.Parameters.AddWithValue("@Cid", txtCusId.Text);
                cmd.Parameters.AddWithValue("@Cphone", txtCusPhone.Text);
               cmd.Parameters.AddWithValue("@Ctype", txtCusType1.Text);
                cmd.Parameters.AddWithValue("@Cpayoption", txtCusPoption1.Text);
                cmd.Parameters.AddWithValue("@ID", this.Cserial);


     

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Customer info updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetCustomerRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Customer to update", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cserial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtCusName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtCusId.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtCusPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtCusType1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtCusPoption1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        
        }

        private void txtCusD_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
              
              
          
        }
    }
}
