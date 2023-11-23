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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GSN7C0A;Initial Catalog=MarketDB;Integrated Security=True");


        public int S_serial;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Shop = new Form4();
            Shop.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm5 = new Form5();
            fm5.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            GetShopRecordsRecord();
        }
        private void GetShopRecordsRecord()
        {


            SqlCommand cmd = new SqlCommand("Select * from Shop_TB1", con);

            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (S_serial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE Shop_TB1  WHERE S_serial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.S_serial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Shop is deleted from the record ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetShopRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Shop to delete", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Shop_TB1 VALUES (@Sname, @Sid, @Slocation,@SContact)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sname", txtSname.Text);
                cmd.Parameters.AddWithValue("@Sid", txtSid.Text);
                cmd.Parameters.AddWithValue("@Slocation", txtSlocation.Text);
                cmd.Parameters.AddWithValue("@SContact", txtScontact.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Shop inserted", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetShopRecordsRecord();
                ResetFormControls();
            }
        }

        private bool isValid()
        {
            if (txtSname.Text == string.Empty)
            {
                MessageBox.Show("Shop name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            S_serial = 0;
            txtSname.Clear();
            txtSid.Clear();
            txtSlocation.Clear();
            txtScontact.Clear();
            txtSname.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (S_serial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Shop_TB1 SET Sname = @Sname, Sid = @Sid, Slocation = @Slocation, Scontact = @Scontact WHERE S_serial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sname", txtSname.Text);
                cmd.Parameters.AddWithValue("@Sid", txtSid.Text);
                cmd.Parameters.AddWithValue("@Slocation", txtSlocation.Text);
                cmd.Parameters.AddWithValue("@Scontact", txtScontact.Text);
                cmd.Parameters.AddWithValue("@ID", this.S_serial);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Shop info updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetShopRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Shop to update", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textshopname.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter name  to search Shop", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Shop_TB1 WHERE Sname = @SName", con);
                cmd.Parameters.AddWithValue("Sname", textshopname.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               // MessageBox.Show("Shop is found", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.S_serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtSname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtSid.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtSlocation.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtScontact.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void textshopname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
