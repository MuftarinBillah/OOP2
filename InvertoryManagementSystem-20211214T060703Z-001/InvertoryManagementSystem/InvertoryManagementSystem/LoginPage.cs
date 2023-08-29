using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.Operation;

namespace InvertoryManagementSystem
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        private void pictureBoxCloss_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OUser oUser = new OUser();
            bool un = string.IsNullOrEmpty(this.txtName.Text);
            bool pass = string.IsNullOrEmpty(this.txtPass.Text);

            Console.WriteLine(un);
            Console.WriteLine(pass);
            if (un)
            {
                MessageBox.Show("Insert Your User Name.");
            }

            else if (pass)
            {
                MessageBox.Show("Insert your Password.");

            }
            
            else
            {
                var result = oUser.login(this.txtName.Text, this.txtPass.Text);
                DataTable dataTable = new DataTable();
                result.Fill(dataTable);

                //  MessageBox.Show(dataTable.Rows[0]["Uname"].ToString());
                if (dataTable.Rows.Count == 1)
                {
                    this.Hide();
                    HomePage homePage = new HomePage();
                    homePage.Show();
                }

                else
                {
                    MessageBox.Show("Invalide Username or Password");
                }
            }
            
        }
    }
}
