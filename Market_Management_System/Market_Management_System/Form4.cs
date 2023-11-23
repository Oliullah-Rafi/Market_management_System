using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Market_Management_System
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
        }
    

   SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GSN7C0A;Initial Catalog=MarketDB;Integrated Security=True");


       

        public int Eserial;
        private void Form1_Load(object sender, EventArgs e)
    {
        GetEmployeeRecordsRecord();
    }

    private void GetEmployeeRecordsRecord()
    {


       SqlCommand cmd = new SqlCommand("Select * from Employee_TB1", con);

        DataTable dt = new DataTable();
        con.Open();

        SqlDataReader sdr = cmd.ExecuteReader();
        dt.Load(sdr);
        con.Close();

        dataGridView1.DataSource = dt;
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void button6_Click(object sender, EventArgs e)
    {
            this.Hide();
            Form3 fm3 = new Form3();
            fm3.Show();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        }

    private void button7_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void button10_Click(object sender, EventArgs e)
    {
        if (Eserial > 0)
        {
            SqlCommand cmd = new SqlCommand("DELETE Employee_TB1  WHERE Eserial = @ID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ID", this.Eserial);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Employee is deleted from the record ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetEmployeeRecordsRecord();
            ResetFormControls();
        }
        else
        {
            MessageBox.Show("Please, select Employee to delete", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button11_Click(object sender, EventArgs e)
    {
            this.Hide();
            Form4  fm4 = new Form4();
            fm4.Show();
    }

    private void Form4_Load(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form5 Cus = new Form5();
        Cus.Show();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form6 Cus = new Form6();
        Cus.Show();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form9 Cus = new Form9();
        Cus.Show();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        this.Hide();
        Form8 Cus = new Form8();
        Cus.Show();
    }

    private void button8_Click(object sender, EventArgs e)
    {
        if (isValid())
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee_TB1 VALUES (@EName, @EId, @ESalary,@EContact)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@EId", txtEmpId.Text);
            cmd.Parameters.AddWithValue("@ESalary", txtEmpSalary.Text);
            cmd.Parameters.AddWithValue("@EContact", txtEmpContact.Text);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("New Employee inserted", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetEmployeeRecordsRecord();
            ResetFormControls();
        }
    }

    private bool isValid()
    {
        if (txtEmpName.Text == string.Empty)
        {
            MessageBox.Show("Employee name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    private void button9_Click(object sender, EventArgs e)
    {
        ResetFormControls();
    }
         private void ResetFormControls()
         {
             Eserial = 0;
             txtEmpName.Clear();
             txtEmpId.Clear();
             txtEmpSalary.Clear();
             txtEmpContact.Clear();
             txtEmpName.Focus();
         }

         private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {

          

        }
         
        private void button12_Click(object sender, EventArgs e)   
    {
       if (Eserial > 0)        
        {
            SqlCommand cmd = new SqlCommand("UPDATE Employee_TB1 SET Ename = @EName, Eid = @EId, Esalary = @ESalary, Econtact = @EContact WHERE Eserial = @ID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@EId", txtEmpId.Text);
            cmd.Parameters.AddWithValue("@ESalary", txtEmpSalary.Text);
            cmd.Parameters.AddWithValue("@EContact", txtEmpContact.Text);
            cmd.Parameters.AddWithValue("@ID", this.Eserial);


            

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Employee info updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetEmployeeRecordsRecord();
            ResetFormControls();
        }
        else
        {
            MessageBox.Show("Please, select Employee to update", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Employee_TB1", con);
            GetEmployeeRecordsRecord();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.Eserial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            txtEmpName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtEmpId.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEmpSalary.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtEmpContact.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(textEmpName.Text == string.Empty)
            {
                MessageBox.Show("Please, Enter name  to search Employee", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee_TB1 WHERE Ename = @EName", con);
                cmd.Parameters.AddWithValue("Ename", textEmpName.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
              //  MessageBox.Show("Employee is found", "slected?", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
            
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
