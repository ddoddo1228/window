using MySql.Data.MySqlClient;
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
    public partial class EndForm : Form
    {
        private Timer autoCloseTimer;
        public int fa;
        public EndForm()
        {
            InitializeComponent();
            this.Shown += EndForm_Shown;
            InitializeDynamicComponents();
            
        }

        private void EndForm_Load(object sender, EventArgs e)
        {

        }

        private void EndForm_Shown(object sender, EventArgs e)
        {
            if(Islogin.islogin == false)
            {
                lbl_fa.Text = fa.ToString();
                return;
            }
            lbl_fa.Text = fa.ToString();
            lbl_rp.Text = GetRemainingPoint().ToString();
        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
            InitializeAutoCloseTimer();
        }
        private void InitializeAutoCloseTimer()
        {
            // 타이머 초기화 (인터벌을 밀리초 단위로 설정)
            autoCloseTimer = new Timer();
            autoCloseTimer.Interval = 5000; // 5초
            autoCloseTimer.Tick += AutoCloseTimer_Tick;

            // 타이머 시작
            autoCloseTimer.Start();
        }
        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            // 타이머 이벤트 발생 시 호출되는 메서드
            // 여기에 5초 후에 실행할 작업을 추가할 수 있습니다.

            // 애플리케이션 종료
            Application.Exit();
        }

        private int GetRemainingPoint()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=db_kiosk;Uid=root;Pwd=1111;"))
                {
                    connection.Open();

                    // 사용자의 point 값을 가져오는 SQL 쿼리
                    string query = "SELECT point FROM user WHERE id = @userId;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", ID.id);
                        object result = cmd.ExecuteScalar();
                        int pointValue = Convert.ToInt32(result);
                        return pointValue;
                    }
                }
            }
            catch (Exception ex)
            {
                // 예외 처리
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0;
            }
        }
    }
}
