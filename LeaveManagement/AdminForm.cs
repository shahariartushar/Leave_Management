using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LeaveManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//create new admin
        {
            try
            {
                Connection sv = new Connection();
                sv.thisConnection.Open();

                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM Admin", sv.thisConnection);

                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Admin");

                DataRow thisRow = thisDataSet.Tables["Admin"].NewRow();


                thisRow["UserName"] = textBox1.Text.ToString();
                thisRow["Password"] = textBox2.Text.ToString();

                thisDataSet.Tables["Admin"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "Admin");

                sv.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void alisv()
        {
            listView1.Items.Clear();
            try
            {
                //listView
                Connection CN2 = new Connection();
                CN2.thisConnection.Open();
                SqlCommand thisCommand2 = new SqlCommand();
                thisCommand2.Connection = CN2.thisConnection;
                
                thisCommand2.CommandText = "SELECT e.EmpID,e.EmpName,i.IssueStartDate,i.IssueEndDate,i.IssueDescription FROM Employe e,Issue i WHERE e.EmpID=i.EmpID and i.IssueStatus='pending'";
                SqlDataReader thisReader2 = thisCommand2.ExecuteReader();

                int c = 1;
                while (thisReader2.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    
                    lsvItem.Text = c.ToString();
                    lsvItem.SubItems.Add(thisReader2["EmpID"].ToString());
                    lsvItem.SubItems.Add(thisReader2["EmpName"].ToString());
                    lsvItem.SubItems.Add(thisReader2["IssueStartDate"].ToString());
                    lsvItem.SubItems.Add(thisReader2["IssueEndDate"].ToString());
                    lsvItem.SubItems.Add(thisReader2["IssueDescription"].ToString());

                    listView1.Items.Add(lsvItem);
                    c++;
                }
                CN2.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void aload()
        {
            try
            {
                //textbox fill
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                textBox3.Text = Helper.AdminName.ToString();

                thisCommand.CommandText = "SELECT * FROM  Admin WHERE UserName='" + textBox3.Text + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    textBox4.Text = thisReader["Password"].ToString();
                }
                CN.thisConnection.Close();

                alisv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            aload();
        }

        private void button2_Click(object sender, EventArgs e)//search
        {
            try
            {
                //textbox fill
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "SELECT * FROM  Employe WHERE EmpID='" + textBox5.Text + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    MessageBox.Show("Employee ID: "+thisReader["EmpID"]+"\nEmployee Name: "+thisReader["EmpName"]+"\nEmployee Email: "+thisReader["EmpEmail"]+"\nEmployee Phone NO: "+thisReader["EmpPhoneNo"]+"\nEmployee Address: "+thisReader["EmpAddress"]);
                }
                CN.thisConnection.Close();

                alisv();
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
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                DialogResult result = MessageBox.Show("Allow this leave application?",
                                                        "Leave",
                                                        MessageBoxButtons.YesNoCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button3);

                if (result.ToString() == "Yes")
                {
                    thisCommand.CommandText = "update Issue set IssueStatus='allowed' WHERE EmpID='" + listView1.SelectedItems[0].SubItems[1].Text + "'AND IssueStartDate='" + listView1.SelectedItems[0].SubItems[3].Text + "'AND IssueEndDate='" + listView1.SelectedItems[0].SubItems[4].Text + "'AND IssueDescription='" + listView1.SelectedItems[0].SubItems[5].Text + "'";
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                }
                else if (result.ToString() == "No")
                {
                    thisCommand.CommandText = "update Issue set IssueStatus='rejected' WHERE EmpID='" + listView1.SelectedItems[0].SubItems[1].Text + "'AND IssueStartDate='" + listView1.SelectedItems[0].SubItems[3].Text + "'AND IssueEndDate='" + listView1.SelectedItems[0].SubItems[4].Text + "'AND IssueDescription='" + listView1.SelectedItems[0].SubItems[5].Text + "'";
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                }
                aload();
                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;

                thisCommand.CommandText = "update Admin set Password='" + textBox4.Text + "'" + "WHERE UserName='" + Helper.AdminName + "'";
                SqlDataReader thisReader = thisCommand.ExecuteReader();


                CN.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        


        
    }
}
