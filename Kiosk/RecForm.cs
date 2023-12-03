using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class RecForm : Form
    {
        public RecForm()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }
        private void RecForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.StartPosition = FormStartPosition.Manual;
            loginform.Location = this.Location;
            loginform.ShowDialog();
        }
        private void btn_skip_Click(object sender, EventArgs e)
        {
            MenuForm menuform = new MenuForm();
            menuform.StartPosition = FormStartPosition.Manual;
            menuform.Location = this.Location;
            menuform.ShowDialog();
     
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            RegisterForm registerform = new RegisterForm();
            registerform.StartPosition = FormStartPosition.Manual;
            registerform.Location = this.Location;
            registerform.ShowDialog();
        }
    }
}
