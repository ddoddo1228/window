using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kiosk
{   
    public partial class CashForm : Form
    {
        public int p;
        public int gp;
        public int fa;
        public CashForm()
        {
            InitializeComponent();
            this.Shown += CashForm_Shown;
            InitializeDynamicComponents();
        }

        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }
        private void CashForm_Load(object sender, EventArgs e)
        {

        }
        private void CashForm_Shown(object sender, EventArgs e)
        {

        }
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
