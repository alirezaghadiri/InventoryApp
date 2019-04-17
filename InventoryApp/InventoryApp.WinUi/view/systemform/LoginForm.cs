using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.systemform
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnaccept_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (txtpassword.Text == string.Empty || txtusername.Text == string.Empty)
            {
                MessageBox.Show("اطلاعات وارد شده درست نمی باشد .", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals(txtusername.Text));
                if (relateduser == null)
                {
                    MessageBox.Show("نام کاربری وجود ندارد .", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var saltedPassword = txtpassword.Text + relateduser.PasswordSalt;
                    var saltedPasswordBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
                    var hashedPassword = Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordBytes));
                    if (!hashedPassword.Equals(relateduser.Password))
                    {
                        MessageBox.Show("کلمه عبور نادرست است .", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var identity = new GenericIdentity(relateduser.Username);
                        var roles = relateduser.Roles.Select(p => p.Title).ToArray();
                        var principal = new GenericPrincipal(identity, roles);
                        System.Threading.Thread.CurrentPrincipal = principal;
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            this.Enabled = true;
        }


        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
