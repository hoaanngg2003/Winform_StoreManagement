using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
 
        private void btnLogin_Click_2(object sender, EventArgs e)
        {
            if (CheckLogin())
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;
                if (user == "admin" && pass == "123")
                {
                    MessageBox.Show("Successfully Login");
                    Form1 c = new Form1();
                    this.Hide();
                    c.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Incorrect account or password!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           
        }

        // ckeck login
        public bool CheckLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show(this, "Account can not blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show(this, "Password can not blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return false;
            }
            return true;
        }

        private void btnExitlogin_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
