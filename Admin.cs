
using LiveCharts.Wpf.Charts.Base;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SellingStockingMachine.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SellingStockingMachine
{
    public partial class Admin : Form
    {
        readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSposb;Integrated Security=True";
        private Timer timer;
        public Admin()
        {
            InitializeComponent();
        }




private void LoadChartData()
    {
        // Clear previous data
        chart1.Series.Clear();

        // Apply dark mode style
        chart1.BackColor = Color.Black;
        chart1.ChartAreas[0].BackColor = Color.Black;
        chart1.ForeColor = Color.White;
        chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
        chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

        // Create a new series for the chart
        Series revenueSeries = new Series("Total Revenue")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.White
        };

        try
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                // Get the total revenue for the last 7 days
                string query = "SELECT CONVERT(date, TransactionDate) AS TransactionDate, SUM(TotalAmount) AS TotalRevenue " +
                               "FROM Transactions " +
                               "WHERE TransactionDate >= DATEADD(day, -7, CONVERT(date, GETDATE())) " +
                               "GROUP BY CONVERT(date, TransactionDate) " +
                               "ORDER BY CONVERT(date, TransactionDate)";

                using (var cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(0);
                            decimal totalRevenue = reader.GetDecimal(1);

                            // Add data points to the series
                            revenueSeries.Points.AddXY(date.ToShortDateString(), (double)totalRevenue);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        // Add the series to the chart
        chart1.Series.Add(revenueSeries);

        // Set axis labels
        chart1.ChartAreas[0].AxisX.Title = "Last 7 Days";
        chart1.ChartAreas[0].AxisY.Title = "Amount ($)";
        chart1.ChartAreas[0].AxisY.LabelStyle.Format = "${0}";

        // Adjust axis intervals if needed
        //chart1.ChartAreas[0].AxisX.Interval = 1;
        //chart1.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
        //chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 10;
    }





        private void LoadGaugeChartData()
        {
            try
            {
                double totalRevenue = GetTotalRevenueFromTransactions();
                double last7DaysRevenue = GetLast7DaysRevenueFromTransactions();

                double percentage = (last7DaysRevenue / totalRevenue) * 100;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = (int)percentage;

               

                progressBar1.ForeColor = Color.LightGreen;
                progressBar1.BackColor = Color.Black;
                progressBar1.Style = ProgressBarStyle.Continuous;
                // Update the label to display the value
                label1.Text = $"{last7DaysRevenue:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double GetTotalRevenueFromTransactions()
        {
            double totalRevenue = 0;

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT SUM(TotalAmount) FROM Transactions";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            totalRevenue = Convert.ToDouble(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving total revenue from transactions.", ex);
            }

            return totalRevenue;
        }

        private double GetLast7DaysRevenueFromTransactions()
        {
            double last7DaysRevenue = 0;

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT SUM(TotalAmount) FROM Transactions " +
                                   "WHERE TransactionDate >= DATEADD(day, -7, CONVERT(date, GETDATE()))";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            last7DaysRevenue = Convert.ToDouble(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving revenue of the last 7 days from transactions.", ex);
            }

            return last7DaysRevenue;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 30000; // 55 minutes
            timer.Tick += Timer_Tick;
            timer.Start();

            // Load initial data for the chart
            LoadChartData();
            LoadGaugeChartData();
            

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadChartData();
            LoadGaugeChartData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
