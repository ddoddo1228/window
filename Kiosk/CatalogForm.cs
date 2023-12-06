using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
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
    public partial class CatalogForm : Form
    {
        public int amount;
        public int point;
        public Label[] items_name;
        public Label[] items_quantity;
        public Label[] items_price;
        public string[] names = new string[5];
        public int[] quantities = new int[5];
        public int[] prices = new int[5];
        public string[] n = new string[5];
        public int[] q = new int[5];
        public int[] p = new int[5];
        public int finalamount;

        public CatalogForm()
        {
            InitializeComponent();
            this.Shown += CatalogForm_Shown;
            InitializeDynamicComponents();
            Initializeitems();  
            InitializeLabel();           
        }
        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }
        private void Initializeitems()
        {
            items_name = new Label[] { item1_name, item2_name, item3_name, item4_name, item5_name };
            items_quantity = new Label[] { item1_quantity, item2_quantity, item3_quantity, item4_quantity, item5_quantity };
            items_price = new Label[] { item1_price, item2_price, item3_price, item4_price, item5_price };

        }
        // 회원의 이름을 DB에서 가져와 할당하는 함수
        private void InitializeLabel()
        {
            if (Islogin.islogin == false)
            {
                return;
            }
            using (MySqlConnection connection = new MySqlConnection("Server = localhost;Database=db_kiosk;Uid=root;Pwd=1111;"))
            {
                connection.Open();

                string query = "SELECT name FROM user;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nameValue = reader.GetString("name");
                            lbl_name.Text = nameValue;
                        }
                    }
                }
            }
        }
        // 최종 결제 금액 산출 및 금액 할당 함수
        public void GetValue()
        {

            finalamount = amount - Takeout.takeout * 1000 - point;
            if (finalamount < 0)
            {
                finalamount = 0;
            }
            lbl_amount.Text = finalamount.ToString();
            lbl_list.Text = amount.ToString();
            lbl_point.Text = point.ToString();
            if (Takeout.takeout == 1)
            {
                lbl_takeout.Text = "1000";
            }
            else
            {
                lbl_takeout.Text = "0";
            }
            lbl_stackpoint.Text = (amount / 100).ToString();
        }
        // 회원의 적립금액을 DB에서 가져오는 함수
        private int GetPointValue()
        {
            int pointValue = 0;

            using (MySqlConnection connection = new MySqlConnection("Server = localhost;Database=db_kiosk;Uid=root;Pwd=1111;"))
            {
                connection.Open();

                if (Islogin.islogin)
                {
                    string query = "SELECT point FROM user;";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pointValue = reader.GetInt32("point");
                            }
                        }
                    }
                }
            }

            return pointValue;
        }
        private void CatalogForm_Load(object sender, EventArgs e)
        {
            
        }

        //폼 생성시 이벤트
        private void CatalogForm_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                items_name[i].Text = n[i];
                items_quantity[i].Text = q[i].ToString();
                items_price[i].Text = p[i].ToString();               
            }
            if (Islogin.islogin == false) //회원 로그인에 따라 적립금 관련 표시 유무
            {
                lbl_stackpoint.Visible = false;
                label5.Visible = false;
                btn_remove.Visible = false;
            }
            else
            {
                lbl_stackpoint.Visible = true;
                label5.Visible = true;
                btn_remove.Visible = true;
            }
            point = GetPointValue();
            GetValue();           
        }       

        // 다음 폼으로 이동함과 동시에 값을 이동시킴 (쌓이는적립금, 최종결제금액, 적립금)
        private void btn_cash_Click(object sender, EventArgs e)
        {
            CashForm cashform = new CashForm();
            cashform.StartPosition = FormStartPosition.Manual;
            cashform.Location = this.Location;
            cashform.gp = amount / 100;
            cashform.fa = finalamount;
            cashform.p = GetPointValue();
            cashform.ShowDialog();

        }
        // 다음 폼으로 이동함과 동시에 값을 이동시킴 (쌓이는적립금, 최종결제금액, 적립금)
        private void btn_card_Click(object sender, EventArgs e)
        {
            CardForm cardform = new CardForm();
            cardform.StartPosition = FormStartPosition.Manual;
            cardform.Location = this.Location;
            cardform.gp = amount / 100;
            cardform.fa = finalamount;
            cardform.p = GetPointValue();
            cardform.ShowDialog();
        }

        //적립금 계산에서 제거하고 초기화
        private void btn_remove_Click(object sender, EventArgs e)
        {
            point = 0;
            Used.used = false; // 적립금 사용 안했음 체크
            GetValue();
        }
    }
}
