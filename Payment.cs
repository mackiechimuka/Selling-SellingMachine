using Microsoft.EntityFrameworkCore.Internal;
using SellingStockingMachine.Auth;
using SellingStockingMachine.Models;
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

namespace SellingStockingMachine
{
    public partial class Payment : Form
    {
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSposb;Integrated Security=True";
        int customerId;

        List<ShoppingCart> selectedProducts;

        public Payment()
        {
            InitializeComponent();
            selectedProducts = new List<ShoppingCart>();
            LoadProducts();
            LoadSelectedItems();
           
        }

        public void LoadProducts()
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Products;", con))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        dataGridViewProduct.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink);
            }
        }

        public void LoadSelectedItems()
        {
            dataGridViewSelectedItems.DataSource = null;

            // Check if selectedProducts is null or empty
            if (selectedProducts == null || selectedProducts.Count == 0)
            {
                // Handle the case when selectedProducts is null or empty
                dataGridViewSelectedItems.DataSource = selectedProducts; // or null, depending on your requirements
                txtTotal.Text = "0";
                return;
            }

            dataGridViewSelectedItems.DataSource = selectedProducts;

            decimal Total = selectedProducts.Sum(item => item.Price * item.Quantity);
            txtTotal.Text = Total.ToString();
        }

        public void InsertCustomer(string name, string email)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand($"INSERT INTO Customers(CustomerName, Email, createdAt) VALUES(@Name, @Email, @CreatedAt); SELECT SCOPE_IDENTITY();", con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        customerId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.HelpLink);
            }
        }

        public void CreateTransactionItems(int transactionId)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    foreach (ShoppingCart cart in selectedProducts)
                    {
                        using (var cmd = new SqlCommand($"INSERT INTO TransactionItems(TransactionId, ProductId, Quantity, Price, createdAt) VALUES(@TransactionId, @ProductId, @Quantity, @Price, @CreatedAt)", con))
                        {
                            cmd.Parameters.AddWithValue("@TransactionId", transactionId);
                            cmd.Parameters.AddWithValue("@ProductId", cart.ProductsId);
                            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                            cmd.Parameters.AddWithValue("@Price", cart.Price);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                        using (var cmd2 = new SqlCommand($"UPDATE Products SET Quantity = Quantity - @Quantity WHERE ProductsId = @ProductId", con))
                        {
                            cmd2.Parameters.AddWithValue("@Quantity", cart.Quantity);
                            cmd2.Parameters.AddWithValue("@ProductId", cart.ProductsId);
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int ProductsId = int.Parse(dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string ProductsName = dataGridViewProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                    decimal Price = decimal.Parse(dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value.ToString());

                    ShoppingCart existingItem = selectedProducts.FirstOrDefault(p => p.ProductsId == ProductsId);
                    if (existingItem != null)
                    {
                        existingItem.Quantity += 1;
                    }
                    else
                    {
                        int Quantity = 1;
                        ShoppingCart selectedProduct = new ShoppingCart
                        {
                            ProductsId = ProductsId,
                            ProductName = ProductsName,
                            Price = Price,
                            Quantity = Quantity
                        };
                        selectedProducts.Add(selectedProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadSelectedItems();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCname.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTotal.Text) || string.IsNullOrEmpty(txtTotal.Text))
                {
                    MessageBox.Show("All fields must be filled");
                }
                else
                {
                    InsertCustomer(txtCname.Text, txtEmail.Text);
                    decimal TotalAmount = Convert.ToDecimal(txtTotal.Text);
                   
                    using (var con = new SqlConnection(connectionString))
                    {
                        string cash = "Cash";
                        con.Open();
                        using (var cmd = new SqlCommand($"INSERT INTO Transactions(CustomerId,UserId,TransactionDate, TotalAmount,PaymentMethod, createdAt) VALUES(@CustomerId,@UserId,@TransactionDate, @TotalAmount,@PaymentMethod, @CreatedAt); SELECT SCOPE_IDENTITY();", con))
                        {
                            cmd.Parameters.AddWithValue("@CustomerId", customerId);
                            cmd.Parameters.AddWithValue("@UserId", Session.UserData.UserId);
                            cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                            cmd.Parameters.AddWithValue("@PaymentMethod", cash);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                            int transactionId = Convert.ToInt32(cmd.ExecuteScalar());
                            CreateTransactionItems(transactionId);
                        }
                    }
                    MessageBox.Show("Payment successful");
                    selectedProducts.Clear();
                    selectedProducts = new List<ShoppingCart>();
                    LoadSelectedItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}