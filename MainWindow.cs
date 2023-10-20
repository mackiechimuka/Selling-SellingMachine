using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SellingStockingMachine.Auth;

namespace SellingStockingMachine
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.label3.Text = Session.UserData.UserName;
            if(Session.UserData.Role != "Admin")
            {
                AdminPanel.Hide();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

        private void PaymentPanel_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Hide();

        }

        private void InvPanel_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Show();
            this.Hide();
        }

        private void AdminPanel_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
            
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Session.UserData = null;
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
