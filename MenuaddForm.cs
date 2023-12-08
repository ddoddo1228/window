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
    public partial class MenuaddForm : Form
    {
        private PictureBox menuPictureBox;
        private Image menuImage; // 변수를 클래스 수준으로 이동
        public string SelectedAddition { get; private set; }
        public int AdditionalPrice { get; private set; }

        public MenuaddForm(Image menuImage)
        {
            InitializeComponent();
            this.menuImage = menuImage; // 생성자에서 값을 할당
            InitializePictureBox();
        }

        private void InitializePictureBox()
        {
            menuPictureBox = new PictureBox();

            // 명시적으로 크기와 위치를 설정합니다.
            menuPictureBox.Size = new Size(200, 250); // 적절한 크기로 설정
            menuPictureBox.Location = new Point(50, 50); // 적절한 위치로 설정

            // 나머지 코드는 이전과 동일하게 유지됩니다.
            menuPictureBox.Image = menuImage;
            menuPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(menuPictureBox);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SelectedAddition = "샷추가";
            AdditionalPrice = 500;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectedAddition = "HOT";
            AdditionalPrice = 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectedAddition = "ICE";
            AdditionalPrice = 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectedAddition = "사이즈업";
            AdditionalPrice = 1000;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectedAddition = "없음";
            AdditionalPrice = 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}