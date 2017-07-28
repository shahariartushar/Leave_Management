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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void loginCheck()
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                SqlCommand thisCommand = new SqlCommand();

                thisCommand.Connection = CN.thisConnection;
                if (comboBox1.Text=="Employee")
                {
                    thisCommand.CommandText = "SELECT EmpID FROM Employe WHERE EmpUserName='" + textBox1.Text + "' AND EmpPassword='" + textBox2.Text + "'";
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                    
                    if (thisReader.Read())
                    {
                        
                        Helper.UserId = Convert.ToInt32(thisReader["EmpID"]);
                        EmployeeForm empform = new EmployeeForm();
                        empform.Show();
                        
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password incorrect");
                    }
                }
                else if (comboBox1.Text == "Admin")
                {
                    thisCommand.CommandText = "SELECT * FROM Admin WHERE UserName='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                    if (thisReader.Read())
                    {
                        Helper.AdminName = thisReader["UserName"].ToString();
                        AdminForm oform = new AdminForm();
                        oform.Show();
                        
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password incorrect");
                    }
                    
                }
                CN.thisConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)// register an employee
        {
            RegisterForm regform = new RegisterForm();
            regform.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//username
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                loginCheck();
            }*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//password
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                loginCheck();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginCheck();
        }
    }
}
