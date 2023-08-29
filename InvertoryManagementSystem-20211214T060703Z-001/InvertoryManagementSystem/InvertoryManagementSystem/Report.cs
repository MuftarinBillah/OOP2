using DataAccessLayer.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvertoryManagementSystem
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            sellloadGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void sellloadGridView()
        {
            OProduct oProduct = new OProduct();
            var result = oProduct.getAllSale();
            DataTable dataTable = new DataTable();
            result.Fill(dataTable);
            this.reportgdv.DataSource = dataTable;

        }
        private void rtnloadGridView()
        {
            OProduct oProduct = new OProduct();
            var result = oProduct.getAllReturn();
            DataTable dataTable = new DataTable();
            result.Fill(dataTable);
            this.reportgdv.DataSource = dataTable;

        }
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void salesbtn_Click(object sender, EventArgs e)
        {
            sellloadGridView();
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            rtnloadGridView();
        }

        private void Home_click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void reportgdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
