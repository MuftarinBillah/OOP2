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
    public partial class ManageProduct : Form
    {
        public object Connection { get; private set; }
        public OUser OProduct { get; private set; }

        public ManageProduct()
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
            this.productgdv.DataSource = dataTable;

        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            Eproduct eproduct = new Eproduct();

            eproduct.ProdNam = ProductName.Text;
            eproduct.ProdId = ProductID.Text;
            eproduct.ProdPrice = Convert.ToInt32(ProductPrice.Text);
            eproduct.ProdQty = Convert.ToInt32(ProductQty.Text);
            eproduct.ProdCat = ProductCat.Text;

            OProduct oProduct = new OProduct();

            int success=oProduct.insert(eproduct);

            if (success >= 0)
            {
                MessageBox.Show("Successfully inserted");
            }
            else
            {
                MessageBox.Show("Not Insert");
            }


            this.ProductName.Text = string.Empty;
            this.ProductID.Text = string.Empty;
            this.ProductPrice.Text = string.Empty;
            this.ProductQty.Text = string.Empty;
            this.ProductCat.Text = string.Empty;


            loadGridView();


        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.productgdv.SelectedRows[0];
            OProduct oProduct = new OProduct();
            oProduct.deleteProduct(row.Cells["ProdId"].Value.ToString());
            loadGridView();
        }
        private void Home_click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void SearchProd_Click(object sender, EventArgs e)
        {
            Eproduct eproduct = new Eproduct();

            eproduct.ProdCat = searchbox.Text;

            OProduct oproduct = new OProduct();

            var result =oproduct.View(eproduct);

            DataTable dataTable = new DataTable();
            result.Fill(dataTable);
            this.productgdv.DataSource = dataTable;


        }

        private void productgdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
