using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class RegisterForm : Form
    {

        [DllImport("User32.DLL")]
        public static extern Boolean PostMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
        public const Int32 WM_USER = 1024;
        public const Int32 WM_CSKEYBOARD = WM_USER + 192;
        public const Int32 WM_CSKEYBOARDMOVE = WM_USER + 193;
        public const Int32 WM_CSKEYBOARDRESIZE = WM_USER + 197;

        static Process keyboardPs = null;
        public RegisterForm()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }

        private void ReigsterForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=db_kiosk;Uid=root;Pwd=1111;");
                connection.Open();

                string insertQuery = "INSERT INTO user (name, id, pwd, point) VALUES ('" + txtbox_name.Text + "', '" + txtbox_id.Text + "', '" + txtbox_pwd.Text + "', '" + 0 + "');";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(txtbox_name.Text + "님 회원가입 완료, 사용할 아이디는 " + txtbox_id.Text + "입니다.");
                    connection.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("비정상 입력 정보, 재확인 요망");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_skip_Click(object sender, EventArgs e)
        {
            MenuForm menuform = new MenuForm();
            menuform.StartPosition = FormStartPosition.Manual;
            menuform.Location = this.Location;
            menuform.ShowDialog();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (keyboardPs == null)
            {
                string filePath;
                if (Environment.Is64BitOperatingSystem)
                {
                    filePath = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"),
                        "amd64_microsoft-windows-osk_*")[0],
                        "osk.exe");
                }
                else
                {
                    filePath = @"C:\windows\system32\osk.exe";
                }
                if (File.Exists(filePath))
                {
                    keyboardPs = Process.Start(filePath);
                }
            }
            keyboardPs = null;
        }      
    }
}
