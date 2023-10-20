using SellingStockingMachine.Auth;
using SellingStockingMachine.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCryptNet = BCrypt.Net.BCrypt;

using SellingStockingMachine.Auth;

namespace SellingStockingMachine
{
    public partial class Main : Form
    {

        
        int id;
        string passwordHarshed;
        bool isPassword;
        string role;
        string name;
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSposb;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Main()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
        }

        private void btnLgn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Fill all the fields");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT p.UserId,p.UserName,p.Password,a.Role FROM Users AS p INNER JOIN UserManagement AS a ON p.UserId = a.UserId WHERE p.UserName = @firstname;  ", con);
                    cmd.Parameters.AddWithValue("@firstname", txtUsername.Text);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader["UserId"]);
                            passwordHarshed = reader["Password"].ToString();
                            name = reader["UserName"].ToString();
                            role = reader["Role"].ToString();
                        }
                        isPassword = BCryptNet.Verify(txtPassword.Text, passwordHarshed);

                        if (!isPassword)
                        {
                            MessageBox.Show($"Password is wrong  ");

                        }
                        else
                        {
                            Session.UserData = new UserData(name,role, id);
                            MainWindow mainMenu = new MainWindow();
                            mainMenu.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Can't find the User try to check the Username if to see if u made mistakes");

                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink);

            }
            finally
            {
                con.Close();

            }

        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        {
            Register mainWindow = new Register();
            mainWindow.Show();
            this.Hide();
        }
    }
}
