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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            lf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)//reg complete
        {
            try
            {
                Connection sv = new Connection();
                sv.thisConnection.Open();

                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM Employe", sv.thisConnection);

                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "Employe");

                DataRow thisRow = thisDataSet.Tables["Employe"].NewRow();


                thisRow["EmpID"] = textBox1.Text;
                thisRow["EmpName"] = textBox2.Text.ToString();
                thisRow["EmpEmail"] = textBox3.Text.ToString();
                thisRow["EmpUserName"] = textBox4.Text.ToString();
                thisRow["EmpPassword"] = textBox5.Text.ToString();
                thisRow["EmpPhoneNo"] = textBox6.Text.ToString();
                thisRow["EmpAddress"] = richTextBox1.Text.ToString();

                thisDataSet.Tables["Employe"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "Employe");

                sv.thisConnection.Close();


                MessageBox.Show("Registration Complete");
                LoginForm lf = new LoginForm();
                lf.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
