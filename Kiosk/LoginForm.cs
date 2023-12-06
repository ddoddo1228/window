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
using MySql.Data.MySqlClient;

namespace Kiosk
{
    public partial class LoginForm : Form
    {
        // 가상 키보드 변수 선언
        [DllImport("User32.DLL")]
        public static extern Boolean PostMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
        public const Int32 WM_USER = 1024;
        public const Int32 WM_CSKEYBOARD = WM_USER + 192;
        public const Int32 WM_CSKEYBOARDMOVE = WM_USER + 193;
        public const Int32 WM_CSKEYBOARDRESIZE = WM_USER + 197;
        static Process keyboardPs = null;

        public LoginForm()
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
        private void LoginForm_Load(object sender, EventArgs e)
        {
        
        // 로그인 이벤트
        }
        private void btn_login_Click(object sender, EventArgs e) 
        {
            try
            { 
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=db_kiosk;Uid=root;Pwd=1111;"); //데이터베이스 연결
                connection.Open();

                int login_status = 0;

                string loginid = tbox_id.Text;
                string loginpwd = tbox_pwd.Text;

                string selectQuery = "SELECT * FROM user WHERE id = \'" + loginid + "\' "; //DB에서 ID 찾기
                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);

                MySqlDataReader userAccount = Selectcommand.ExecuteReader();

                while (userAccount.Read())
                {
                    if (loginid == (string)userAccount["id"] && loginpwd == (string)userAccount["pwd"]) // ID와 PWD가 입력값과 맞는지 대조
                    {
                        login_status = 1;
                        Islogin.islogin = true;
                        ID.id = loginid;
                    }
                }
                connection.Close();

                if (login_status == 1) // 로그인 여부
                {
                    MessageBox.Show("로그인 완료");
                    MenuForm menuform = new MenuForm();
                    menuform.StartPosition = FormStartPosition.Manual;
                    menuform.Location = this.Location;
                    menuform.ShowDialog();

                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            RegisterForm registerform = new RegisterForm();
            registerform.StartPosition = FormStartPosition.Manual;
            registerform.Location = this.Location;
            registerform.ShowDialog();
        }

        private void btn_skip_Click(object sender, EventArgs e) 
        {
            MenuForm menuform = new MenuForm();
            menuform.StartPosition = FormStartPosition.Manual;
            menuform.Location = this.Location;
            menuform.ShowDialog();
        }
        //내장 키보드 이벤트
        private void tbox_Click(object sender, EventArgs e)
        {
            // 내장 가상 키보드 실행 경로를 설정
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
                    keyboardPs = Process.Start(filePath); //osk.exe 실행
                }
            }
            keyboardPs = null;
        } 
    }
}
