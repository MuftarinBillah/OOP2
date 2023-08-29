using DataAccessLayer.Entity;
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
    public partial class ManageUser : Form
    {
        public object Connection { get; private set; }

        public ManageUser()
        {
            InitializeComponent();
            loadGridView();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       


        private void btnAdd_Click(object sender, EventArgs e)

        {
            EUser eUser = new EUser();

            bool unPhone = string.IsNullOrEmpty(this.txtUPhone.Text);

            if(unPhone)
            {
                MessageBox.Show("Insert Your Number.");
            }

            else
            {
                eUser.Uname = txtUUser.Text;
                eUser.Ufullname = txtUFName.Text;
                eUser.Upassword = txtUPass.Text;
                eUser.Uphone = txtUPhone.Text;


                OUser oUser = new OUser();

                int check = oUser.insert(eUser);

                if (check >= 0)
                {
                    MessageBox.Show("Successfully inserted");
                }
                else
                {
                    MessageBox.Show("Not Insert");
                }

                this.txtUUser.Text = string.Empty;
                this.txtUFName.Text = string.Empty;
                this.txtUPass.Text = string.Empty;
                this.txtUPhone.Text = string.Empty;

                loadGridView();
            }
            
            
        }

          private void UserGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {


          }
        private void loadGridView()
        {
            OUser oUser = new OUser();
           var result =  oUser.getAllUser();
            DataTable dataTable = new DataTable();
            result.Fill(dataTable);
            this.userDGV.DataSource=dataTable;

        }
        private void userDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row =  this.userDGV.SelectedRows[0];
            OUser oUser = new OUser();
            oUser.deleteUser(row.Cells["Uphone"].Value.ToString());
            loadGridView();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HomePage().Show();
          

        }
    }
}
