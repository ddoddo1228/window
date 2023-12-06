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
    public partial class CardForm : Form
    {
        public int p;
        public int gp;
        public int fa;
        public CardForm()
        {
            InitializeComponent();
            InitializeDynamicComponents();
        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }
        private void CardForm_Load(object sender, EventArgs e)
        {

        }
        //클릭 이벤트를 통해 '결제' 발생시 실제 DB에서 포인트 적립 및 차감 정리 진행 + 최종금액 다음 폼으로 값 이동
        private void btn_next_Click(object sender, EventArgs e)
        {
            AssignPoint();
            SubstractPoint();
            EndForm endform = new EndForm();
            endform.fa = fa;
            endform.StartPosition = FormStartPosition.Manual;
            endform.Location = this.Location;
            endform.ShowDialog();
        }
        //적립금 적립 함수
        private void AssignPoint()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=db_kiosk;Uid=root;Pwd=1111;"))
                {
                    connection.Open();

                    // 사용자의 point 값을 업데이트하는 SQL 쿼리
                    string query = "UPDATE user SET point = point + @point WHERE id = @userid;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@point", gp);
                        cmd.Parameters.AddWithValue("@userId", ID.id);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
        //사용한 적립금만큼 감소시키는 함수
        private void SubstractPoint()
        {
            if (Used.used == true)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=db_kiosk;Uid=root;Pwd=1111;"))
                    {
                        connection.Open();

                        // 사용자의 point 값을 현재 point 값에서 p를 뺀 값으로 업데이트하는 SQL 쿼리
                        string query = "UPDATE user SET point = point - @deductionAmount WHERE id = @userId;";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@deductionAmount", p);
                            cmd.Parameters.AddWithValue("@userId", ID.id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else { return; }
        }
    }
}
