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
    
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }

        //레이아웃 컴포넌트

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }

        // 이벤트
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            Takeout.takeout = 1;
            RecForm recform = new RecForm();
            recform.StartPosition = FormStartPosition.Manual;
            recform.Location = this.Location;
            recform.ShowDialog();
            
        }

        private void btn_in_Click(object sender, EventArgs e)
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

    // 정적 함수 목록
    public static class Takeout // 포장 여부
    {
        public static int takeout = 0;
    }
    public static class ID // 로그인한 ID
    {
        public static String id;
    }
    public static class Used // 적립금 사용 여부
    {
        public static bool used = true;
    }
    public static class Islogin // 로그인 여부
    {
        public static bool islogin = false;
    }
}
