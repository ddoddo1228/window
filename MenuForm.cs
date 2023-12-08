using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class MenuForm : Form
    {
        int amount = 0;
        private int[] previousValues;
        private int[] Checked;
        private Label[] labels_name;
        private Label[] labels_price;
        private PictureBox[] pboxes;
        private PictureBox[] items_image;
        private Button[] items_remove;
        private Label[] items_name;
        private Label[] items_price;
        private NumericUpDown[] items_quantity;
        public static string Value { get; private set; }

        public MenuForm()
        {
            InitializeComponent();
            InitializeComponents();
        }
        //컴포넌트 집합 함수
        private void InitializeComponents()
        {
            InitializeThings();
            InitializeDynamicComponents();
            InitializePictureBoxes();
            InitializeNumericUpDown();
            InitializeButtons();
        }
        //레이아웃 컴포넌트
        private void InitializeDynamicComponents()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 800);
            this.ResumeLayout(false);
        }
        // 다양한 컨트롤들을 배열로 정리
        private void InitializeThings()
        {
            labels_name = new Label[] { lbl1_name, lbl2_name, lbl3_name, lbl4_name, lbl5_name, lbl6_name, lbl7_name, lbl8_name, lbl9_name, lbl10_name, lbl11_name, lbl12_name };
            labels_price = new Label[] { lbl1_price, lbl2_price, lbl3_price, lbl4_price, lbl5_price, lbl6_price, lbl7_price, lbl8_price, lbl9_price, lbl10_price, lbl11_price, lbl11_price, lbl12_price };
            pboxes = new PictureBox[] { pbox_1, pbox_2, pbox_3, pbox_4, pbox_5, pbox_6, pbox_7, pbox_8, pbox_9, pbox_10, pbox_11, pbox_12 };
            items_image = new PictureBox[] { item1_image, item2_image, item3_image, item4_image, item5_image };
            items_name = new Label[] { item1_name, item2_name, item3_name, item4_name, item5_name };
            items_quantity = new NumericUpDown[] { item1_quantity, item2_quantity, item3_quantity, item4_quantity, item5_quantity };
            items_price = new Label[] { item1_price, item2_price, item3_price, item4_price, item5_price };
            items_remove = new Button[] { item1_remove, item2_remove, item3_remove, item4_remove, item5_remove };
            Checked = new int[5];
        }
        // 배열로 이벤트 할당
        private void InitializeNumericUpDown()
        {
            previousValues = new int[items_quantity.Length];
            for (int i = 0; i < items_quantity.Length; i++)
            {
                items_quantity[i].ValueChanged += item_quantity_ValueChanged;
                items_quantity[i].Tag = i;
                previousValues[i] = (int)items_quantity[i].Value;
            }
        }
        private void InitializePictureBoxes()
        {
            for (int i = 0; i < pboxes.Length; i++)
            {
                pboxes[i].Click += PictureBox_Click;
                pboxes[i].Tag = i; // Set the Tag property to store the index
            }
        }

        private void InitializeButtons()
        {
            for (int i = 0; i < items_remove.Length; i++)
            {
                items_remove[i].Click += Button_Remove_Click;
                items_remove[i].Tag = i; // Set the Tag property to store the index
            }
        }

        // 각 메뉴에 해당하는 텍스트와 가격 할당
        private string[] GetMenuNamesByCategory(string category)
        {
            switch (category)
            {
                case "카페":
                    return new string[] { "아메리카노", "디카페인 아메리카노", "콜드브루", "에스프레소", "돌체 콜드브루", "오트 콜드브루", "카라멜 마끼아또", "카페 라떼" };
                case "스무디":
                    return new string[] { "딸기 스무디", "블루베리 스무디", "망고 스무디", "바나나 스무디", "딸기 요거트 스무디", "망고 요거트 스무디", "타로 블루베리 스무디", "자몽 스무디" };
                case "에이드":
                    return new string[] { "레몬 에이드", "자몽 에이드", "오렌지 에이드", "청포도 에이드", "라임 에이드", "딸기 에이드", "레드 레몬 에이드", "수박 에이드" };
                case "디저트":
                    return new string[] { "초코 케이크", "치즈 케이크", "카스테라", "녹차 케이크", "블루베리 치즈 케이크", "티라미수", "레드벨벳 치즈 케이크", "화이트 케이크" };
                case "기타":
                    return new string[] { "기타1", "기타2", "기타3", "기타4" };
                default:
                    return new string[] { };
            }
        }

        private int GetMenuPrice(string menuName)
        {
            switch (menuName)
            {
                case "아메리카노": return 3000;
                case "디카페인 아메리카노": return 3000;
                case "콜드브루": return 3500;
                case "에스프레소": return 2500;
                case "돌체 콜드브루": return 4000;
                case "오트 콜드브루": return 4500;
                case "카라멜 마끼아또": return 4500;
                case "카페 라떼": return 4000;
                case "딸기 스무디": return 4000;
                case "블루베리 스무디": return 4500;
                case "망고 스무디": return 4500;
                case "바나나 스무디": return 4500;
                case "딸기 요거트 스무디": return 4500;
                case "망고 요거트 스무디": return 4500;
                case "타로 블루베리 스무디": return 4500;
                case "자몽 스무디": return 4500;
                case "레몬 에이드": return 4500;
                case "자몽 에이드": return 4500;
                case "오렌지 에이드": return 4500;
                case "청포도 에이드": return 4500;
                case "라임 에이드": return 4500;
                case "딸기 에이드": return 4500;
                case "레드 레몬 에이드": return 4500;
                case "수박 에이드": return 4500;
                case "초코 케이크": return 5000;
                case "치즈 케이크": return 5000;
                case "카스테라": return 500;
                case "녹차 케이크": return 3000;
                case "블루베리 치즈 케이크": return 4500;
                case "티라미수": return 5000;
                case "레드벨벳 치즈 케이크": return 3000;
                case "화이트 케이크": return 5000;
                default: return 0;
            }
        }
        // 메뉴 로드
        private void LoadMenuItems(string category)
        {
            String[] Menu = GetMenuNamesByCategory(category);
            for (int i = 0; i < 12; i++)
            {
                try
                {
                    pboxes[i].Load($@"C:\Users\PC CAFE\Desktop\kiossk\window\Kiosk\Assets\{Menu[i]}.jpg");
                    labels_name[i].Text = Menu[i];
                    labels_price[i].Text = GetMenuPrice(Menu[i]).ToString();
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }
        //초기 로드시 1번 메뉴항목 할당
        private void Form2_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadMenuItems("카페");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadMenuItems("스무디");
        }
        private void button3_Click(object sender, EventArgs e)
        {

            LoadMenuItems("에이드");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadMenuItems("디저트");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LoadMenuItems("기타");
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox && clickedPictureBox.Tag is int index)
            {
                // 이미지를 복사하여 items 배열에 저장
                if (clickedPictureBox.Image == null)
                {
                    return;
                }

                using (MenuaddForm menuAddForm = new MenuaddForm(clickedPictureBox.Image))
                {
                    menuAddForm.ShowDialog();

                    if (menuAddForm.DialogResult == DialogResult.OK)
                    {
                        string selectedAddition = menuAddForm.SelectedAddition;
                        int additionalPrice = menuAddForm.AdditionalPrice;

                        Image clickedImage = new Bitmap(clickedPictureBox.Image);

                        for (int i = 0; i < items_image.Length; i++)
                        {
                            if (items_image[i].Image == null)
                            {
                                items_image[i].Image = clickedImage;

                                // 해당 픽쳐박스와 동일한 인덱스의 labels_name을 가져와서 items[i]_name에 할당
                                if (items_name[i].Text == "")
                                {
                                    items_name[i].Text = labels_name[index].Text;
                                    items_price[i].Text = (GetMenuPrice(labels_name[index].Text) + additionalPrice).ToString();
                                    amount += GetMenuPrice(labels_name[index].Text) + additionalPrice;
                                    tbox_amount.Text = amount.ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }


        // 수량 변경시 현재와 과거의 수량을 비교하여 amount를 증감함
        private void item_quantity_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown numericUpDown && numericUpDown.Tag is int index)
            {
                if (Checked[index] == 1)
                {
                    previousValues[index] = 0;
                    Checked[index] = 0;
                }
                int currentValue = (int)numericUpDown.Value;

                int previousValue = previousValues[index];
                if (items_name[index].Text == "")
                {
                    items_quantity[index].Value = 1;
                    return;
                }
                if (currentValue > previousValue)
                {
                    amount += int.Parse(items_price[index].Text);
                    tbox_amount.Text = amount.ToString();
                }
                else if (currentValue < previousValue)
                {
                    amount -= int.Parse(items_price[index].Text);
                    tbox_amount.Text = amount.ToString();
                }
                else if (currentValue == previousValue)
                {
                    return;
                }


                // 이전 값을 현재 값으로 업데이트
                previousValues[index] = currentValue;
            }
        }
        // 메뉴 옆 X버튼 클릭시 이미지와 텍스트를 제거하고 amount에서 해당가격만큼 감소시킴
        private void Button_Remove_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is int index)
            {
                if (items_name[index].Text == "")
                {
                    return;
                }
                if (button.Name == "btn_next")
                {
                    return;
                }
                amount -= int.Parse(items_price[index].Text) * (int)items_quantity[index].Value;
                tbox_amount.Text = amount.ToString();
                items_image[index].Image = null;
                items_name[index].Text = "";
                items_price[index].Text = "";
                items_quantity[index].Value = 1;
                Checked[index] = 1;
            }
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            CatalogForm cform = new CatalogForm();
            for (int i = 0; i < 5; i++)
            {
                cform.n[i] = items_name[i].Text;
                cform.q[i] = (int)items_quantity[i].Value;
                if (items_price[i].Text == "")
                {
                    cform.p[i] = 0;
                }
                else
                {
                    cform.p[i] = int.Parse(items_price[i].Text);
                }
            }
            cform.amount = amount;
            cform.StartPosition = FormStartPosition.Manual;
            cform.Location = this.Location;
            cform.ShowDialog();
        }
    }
}