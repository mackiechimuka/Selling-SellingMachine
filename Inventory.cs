using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SellingStockingMachine
{
    public partial class Inventory : Form
    {
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSposb;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        int CellId;
        public Inventory()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
            DisplayInventory();

        }

        public void DisplayInventory()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Products ", con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProduct.Text) || nudPrice.Value <= 0 || nudQuantity.Value <= 0)
                {
                    MessageBox.Show("All Inputs must be filled");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand($"INSERT INTO Products(ProductName,Price,Quantity,CreatedDate) VALUES('{txtProduct.Text}','{nudPrice.Value}','{nudQuantity.Value}','{DateTime.Now}')", con);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                DisplayInventory();
                Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand($"DELETE FROM Products WHERE ProductsId ='{CellId}';", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inventory has been deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink);
            }
            finally
            {
                con.Close();
                DisplayInventory();
                Clear();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CellId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtProduct.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            nudPrice.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            nudQuantity.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

        }

        public void Clear()
        {
            txtProduct.Text = "";
            nudPrice.Value = 2;
            nudQuantity.Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtProduct.Text)|| nudPrice.Value <=0 || nudQuantity.Value <= 0 || CellId <= 0)
                {
                    MessageBox.Show("All fields must be filled");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand($" UPDATE Products SET ProductName ='{txtProduct.Text}',Price='{nudPrice.Value}',Quantity='{nudQuantity.Value}',UpdatedAt='{DateTime.Now}' WHERE ProductsId ='{CellId}'",con);
                    cmd.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.HelpLink, ex.Message);
            }
            finally
            {
                con.Close();
                DisplayInventory();
                Clear();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
