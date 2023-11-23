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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GSN7C0A;Initial Catalog=MarketDB;Integrated Security=True");
        float Price;
        private void CheckBalance1()
        {
            con.Open();
            string Query = "select * from Product_TB1 where Pid =" + CheckBALTb.Text + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                BalanceLb1.Text = dr["Pprice"].ToString();
               
            }




            con.Close();
        }

        
        private void Deposit()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into AddSellTB_1(TName,TDate,TAmt,TACNum)values(@TN,@TD,@TA,@TAC)", con);
                cmd.Parameters.AddWithValue("@TN", "Deposit");
                cmd.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@TA", DepAmtTb.Text);
                cmd.Parameters.AddWithValue("@TAC", DepAmtTb.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Withdraw()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into AddSellTB_1(TName,TDate,TAmt,TACNum)values(@TN,@TD,@TA,@TAC)", con);
                cmd.Parameters.AddWithValue("@TN", "Withdrawn");
                cmd.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@TA", DepAmtTb.Text);
                cmd.Parameters.AddWithValue("@TAC", DepAmtTb.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void GetNewBalance()
        {
            con.Open();
            string Query = "select * from Product_TB1 where Pid =" + CheckBALTb.Text + "";
            SqlCommand cmd = new SqlCommand(Query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                
                Price = Convert.ToInt32(dr["Pprice"].ToString());
            }




            con.Close();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CheckBalanceBtn_Click(object sender, EventArgs e)
        {
            if (CheckBALTb.Text == "")
            {
                MessageBox.Show("Enter Product Id Number");
            }
            else
            {
                CheckBalance1();
                if (BalanceLb1.Text == "ProductPrice")
                {
                    MessageBox.Show("Product Id Not Found");
                    CheckBALTb.Text = "";

                }
            }
            }
        
        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (DepAccountTb.Text == "" || DepAmtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Deposit();
                GetNewBalance();
                float newBal = Price + Convert.ToInt32(DepAmtTb.Text);



                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Product_Tb1 set Pprice=@Pprice Where Pid=@Pid", con);
                    cmd.Parameters.AddWithValue("@Pprice", newBal);
                    cmd.Parameters.AddWithValue("@Pid", DepAccountTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Quantity!!!");
                    con.Close();
                    DepAmtTb.Text = "";
                    DepAccountTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void WdBtn_Click(object sender, EventArgs e)
        {

            if (WdAccountTb.Text == "" || WdAmtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                GetNewBalance();
                Withdraw();
                if (Price < Convert.ToInt32(WdAmtTb.Text))
                {
                    MessageBox.Show("Insufficient Product Price");



                }
                else



                {
                    float newBal = Price - Convert.ToInt32(WdAmtTb.Text);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update Product_Tb1 set Pprice=@Pprice Where Pid=@Pid", con);
                        cmd.Parameters.AddWithValue("@Pprice", newBal);
                        cmd.Parameters.AddWithValue("@Pid", WdAccountTb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sell Quantity!!!");
                        con.Close();
                        WdAmtTb.Text = "";
                        WdAccountTb.Text = "";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm9 = new Form4();
            fm9.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {

            CheckBALTb.Clear();

            CheckBALTb.Focus();
        }
    }
    }
