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
    public partial class CustomForm : Form
    {
        public CustomForm()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }

        private void CustomForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }
    }
}
