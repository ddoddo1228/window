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
            LoadNameToLabel();           
        }

        private void Initializeitems()
        {
            items_name = new Label[] { item1_name, item2_name, item3_name, item4_name, item5_name };
            items_quantity = new Label[] { item1_quantity, item2_quantity, item3_quantity, item4_quantity, item5_quantity };
            items_price = new Label[] { item1_price, item2_price, item3_price, item4_price, item5_price };

        }
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
            lbl_getpoint.Text = (amount / 100).ToString();
        }
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

        private void LoadNameToLabel()
        {
            if(Islogin.islogin == false)
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
        private void CatalogForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CatalogForm_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                items_name[i].Text = n[i];
                items_quantity[i].Text = q[i].ToString();
                items_price[i].Text = p[i].ToString();               
            }
            if (Islogin.islogin == false)
            {
                lbl_getpoint.Visible = false;
                label5.Visible = false;
                btn_no.Visible = false;
            }
            else
            {
                lbl_getpoint.Visible = true;
                label5.Visible = true;
                btn_no.Visible = true;
            }
            point = GetPointValue();
            GetValue();           
        }
        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
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
        private void btn_no_Click(object sender, EventArgs e)
        {
            point = 0;
            Used.used = false;
            GetValue();
        }
    }
}
