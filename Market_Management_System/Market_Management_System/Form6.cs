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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GSN7C0A;Initial Catalog=MarketDB;Integrated Security=True");



        public int Pserial;
        public int Balanc;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Cus = new Form4();
            Cus.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            GetProductRecordsRecord();
        }
        private void GetProductRecordsRecord()
        {


            SqlCommand cmd = new SqlCommand("Select * from Product_TB1", con);

            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Pserial > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE Product_TB1  WHERE Pserial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.Pserial);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Product is deleted from the record ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetProductRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Product to delete", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                
              

                con.Open();
                string Query1 = "select Sid from Shop_TB1 ";
                SqlCommand cmd = new SqlCommand(Query1, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    // BalanceLb1.Text = dr["Abalance"].ToString();
                    Balanc = Convert.ToInt32(dr["Sid"].ToString());

                    if (Balanc == Convert.ToInt32(txtPsid.Text))
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO Product_TB1 VALUES (@Sid1, @Pid, @Pquantity,@Pprice,@Ptype,@Pname)", con);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@Sid1", txtPsid.Text);
                        cmd1.Parameters.AddWithValue("@Pid", txtPid.Text);
                        cmd1.Parameters.AddWithValue("@Pquantity", txtPqua.Text);
                        cmd1.Parameters.AddWithValue("@Pprice", txtPprice.Text);
                        cmd1.Parameters.AddWithValue("@Ptype", txtPtyp.Text);
                        cmd1.Parameters.AddWithValue("@Pname", txtPname.Text);


                        //  con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("New Product inserted", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetProductRecordsRecord();
                        ResetFormControls();
                       break;
                    }

                  // else
                  //  {
                       // MessageBox.Show("Shop Id not Found !!!");

                      // break;
                   // }
                  //  break;
                }

               
            }
        }
        private bool isValid()
        {
            if (txtPname.Text == string.Empty)
            {
                SqlCommand cmd = new SqlCommand("Select Sid1 from Product_TB1 WHERE Sid1 =(Select Sid from Shop_TB1)", con);

                MessageBox.Show("Product name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Pserial = 0;
            txtPsid.Clear();
            txtPid.Clear();
            txtPqua.Clear();
            txtPprice.Clear();
            txtPtyp.Clear();
            txtPname.Clear();
            txtPsid.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Pserial > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Product_TB1 SET Sid1 = @Sid1, Pid = @Pid, Pquantity = @Pquantity, Pprice = @Pprice,Ptype =@Ptype,Pname=@Pname WHERE Pserial = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Sid1", txtPsid.Text);
                cmd.Parameters.AddWithValue("@Pid", txtPid.Text);
                cmd.Parameters.AddWithValue("@Pquantity", txtPqua.Text);
                cmd.Parameters.AddWithValue("@Pprice", txtPprice.Text);
                cmd.Parameters.AddWithValue("@Ptype", txtPtyp.Text);
                cmd.Parameters.AddWithValue("@Pname", txtPname.Text);
                cmd.Parameters.AddWithValue("@ID", this.Pserial);


            

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Product info updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetProductRecordsRecord();
                ResetFormControls();
            }
            else
            {
                MessageBox.Show("Please, select Product to update", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Pserial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtPsid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtPid.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPqua.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPprice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPtyp.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtPname.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fm6 = new Form6();
            fm6.Show();
        }

        private void txtPsid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
