using DataAccessLayer.Operation;
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

namespace InvertoryManagementSystem
{
    public partial class HomePage : Form
    {
        

        public HomePage()
        {
            InitializeComponent();
        }

        private void AdminPage(object sender, EventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

       private void homeUserbtn_Click(object sender, EventArgs e)
        {
           ManageUser manageUser = new ManageUser();
            manageUser.Show();

            this.Hide();
                  

        }

        private void manageStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageStock manageStock = new ManageStock();
            manageStock.Show();
        }

        private void homeproduct_click(object sender, EventArgs e)
        {
            this.Hide();
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Show();
        }

        private void homeSettingbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report report = new Report();
            report.Show();
            
        }

        private void signoutbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
