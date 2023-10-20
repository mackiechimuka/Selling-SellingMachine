using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SellingStockingMachine.Auth;

namespace SellingStockingMachine
{
    public partial class Register : Form
    {
        

        string passwordHarshed;
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSposb;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        public Register()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
        }

        private void btnSgn_Click(object sender, EventArgs e)
        {
            string selectedPerm = UseChoiceBox1.SelectedItem.ToString();
            MessageBox.Show(selectedPerm);
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(selectedPerm))
                {
                    MessageBox.Show("Fill all the fields");
                }
                else
                {
                    PasswordHash passwordHash = new PasswordHash();
                    passwordHarshed = passwordHash.HashPassword(txtPassword.Text);
                    MessageBox.Show(passwordHarshed);
                    DateTime createdDate = DateTime.Now;
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Users(UserName,Password,Email,CreatedDate,UpdatedDate) VALUES('" + txtUsername.Text + "','" + passwordHarshed + "','" + txtEmail.Text + "','" + createdDate + "','"+ DateTime.Now +"');SELECT SCOPE_IDENTITY(); ", con);
                    int UserId = Convert.ToInt32(cmd.ExecuteScalar());


                    SqlCommand cmd2 = new SqlCommand("INSERT INTO UserManagement(UserId,Role) VALUES('" + UserId + "','" + selectedPerm + "')", con);
                    cmd2.ExecuteNonQuery();
                    Main Login = new Main();
                    Login.Show();
                    this.Hide();

                }

            }
            catch (Exception ex)
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
            Main login = new Main();
            login.Show();
            this.Hide();
        }
    }
}
