using DataAccessLayer.Entity;
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
    public partial class ManageStock : Form
    {
        public ManageStock()
        {
            InitializeComponent();
            loadGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void loadGridView()
        {
            OProduct oProduct = new OProduct();
            var result = oProduct.getAllProduct();
            DataTable dataTable = new DataTable();
            result.Fill(dataTable);
            this.salegdv.DataSource = dataTable;

        }
        private void rtnProduct_Click(object sender, EventArgs e)
        {
            Eproduct eproduct = new Eproduct();

            eproduct.ProdId = ProductID.Text;
            eproduct.ProdNam = productName.Text;
            eproduct.ProdQty = Convert.ToInt32(amount.Text);

            OProduct oProduct = new OProduct();

            int feebback = oProduct.returninsert(eproduct);
            if (feebback > 0)
            {
                MessageBox.Show("Return record inserted");
            }
            else
            {
                MessageBox.Show("Insert failed");
            }
            this.ProductID.Text = string.Empty;
            this.productName.Text = string.Empty;
            this.amount.Text = string.Empty;
            //int check = 
        }

        private void homebtn_click(object sender, EventArgs e)
        {
            this.Hide();
            new HomePage().Show();
        }

        private void sellProductbtn_Click(object sender, EventArgs e)
        {
            Eproduct eproduct = new Eproduct();

            eproduct.ProdId = ProductID.Text;
            eproduct.ProdNam = productName.Text;
            eproduct.ProdQty = Convert.ToInt32(amount.Text);

            OProduct oProduct = new OProduct();

            int feebback = oProduct.sellinsert(eproduct);
            if(feebback > 0)
            {
                MessageBox.Show("Sale record inserted");
                oProduct.updatestock(eproduct);

            }
            else
            {
                MessageBox.Show("Insert failed");
            }

            this.ProductID.Text = string.Empty;
            this.productName.Text = string.Empty;
            this.amount.Text = string.Empty;

            loadGridView();

            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
