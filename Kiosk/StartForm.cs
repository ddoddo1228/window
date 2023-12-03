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
    public static class Takeout
    {
        public static int takeout = 0;
    }
    public static class ID
    {
        public static String id;
    }
    public static class Used
    {
        public static bool used = true;
    }
    
    public partial class StartForm : Form
    {
        static int pageNumber = 1;
        public StartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Takeout.takeout = 1;
            RecForm recform = new RecForm();
            recform.StartPosition = FormStartPosition.Manual;
            recform.Location = this.Location;
            recform.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecForm recform = new RecForm();
            recform.StartPosition = FormStartPosition.Manual;
            recform.Location = this.Location;
            recform.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
