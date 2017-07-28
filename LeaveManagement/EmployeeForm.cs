using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LeaveManagement
{
    public partial class EmployeeForm : Form
    {
        
        public EmployeeForm()
        {
            InitializeComponent();
        }
        private void lisv()
        {
            listView1.Items.Clear();
            try
            {
                //listView
                Connection CN2 = new Connection();
                CN2.thisConnection.Open();
                SqlCommand thisCommand2 = new SqlCommand();
                thisCommand2.Connection = CN2.thisConnection;
                
                thisCommand2.CommandText = "SELECT * FROM Issue WHERE EmpID='" + textBox1.Text + "'";
                SqlDataReader thisReader2 = thisCommand2.ExecuteReader();
                
                while (thisReader2.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader2["IssueStartDate"].ToString();
                    lsvItem.SubItems.Add(thisReader2["IssueEndDate"].ToString());
                    lsvItem.SubItems.Add(thisReader2["IssueStatus"].ToString());
                    lsvItem.SubItems.Add(thisReader2["IssueDescription"].ToString());

                    listView1.Items.Add(lsvItem); 
                }
                CN2.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void load()
        {
            try
            {
                //textbox fill
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                textBox1.Text = Helper.UserId.ToString();

                thisCommand.CommandText = "SELECT * FROM  Employe WHERE EmpID='" + textBox1.Text + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    textBox2.Text = thisReader["EmpName"].ToString();
                    textBox3.Text = thisReader["EmpEmail"].ToString();
                    textBox4.Text = thisReader["EmpUserName"].ToString();
                    textBox5.Text = thisReader["EmpPassword"].ToString();
                    textBox6.Text = thisReader["EmpPhoneNo"].ToString();
                    richTextBox1.Text = thisReader["EmpAddress"].ToString();
                }
                CN.thisConnection.Close();
                
                lisv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)//clear log
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                //Helper.UserId;

                thisCommand.CommandText = "delete from Issue where EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//name change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpName='" + textBox2.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)//add issue
        {
            try
            {
                Connection sv = new Connection();
                sv.thisConnection.Open();

                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM Issue", sv.thisConnection);

                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Issue");

                DataRow thisRow = thisDataSet.Tables["Issue"].NewRow();
            

                thisRow["EmpID"] = Helper.UserId;
                thisRow["IssueStartDate"] = dateTimePicker1.Text.ToString();
                thisRow["IssueEndDate"] = dateTimePicker2.Text.ToString();
                thisRow["IssueStatus"] = "pending";
                thisRow["IssueDescription"] = richTextBox2.Text.ToString();

                thisDataSet.Tables["Issue"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "Issue");
                load();

                sv.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//email change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpEmail='" + textBox3.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//uesrname change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpUserName='" + textBox4.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)//password change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpPassword='" + textBox5.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)//phone no change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpPhoneNo='" + textBox6.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)//address change
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Employe set EmpAddress='" + richTextBox1.Text + "'" + "WHERE EmpID='" + Helper.UserId + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)//logout
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }

       
    }
}
