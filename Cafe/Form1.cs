// Form1.cs 파일 내부

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // 폼 로드 이벤트 핸들러 등록
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeUI();
            this.Show(); // 폼을 표시하도록 추가
        }

        private void InitializeUI()
        {
            // 폼 설정
            this.Text = "카페 결제 시스템";
            this.Size = new Size(1200, 600); // 화면 크기 조절

            // 왼쪽 패널 설정
            Panel leftPanel = new Panel();
            leftPanel.BackColor = Color.White;
            leftPanel.Size = new Size(this.Width / 2, this.Height);
            leftPanel.Location = new Point(0, 0); // 왼쪽 위치로 조정

            // 왼쪽 포장 버튼 설정
            Button takeoutButton = new Button();
            takeoutButton.Text = " 포장";
            takeoutButton.Font = new Font("한초롬돋움", 20); // 폰트 크기 증가
            takeoutButton.Size = new Size(leftPanel.Width, leftPanel.Height); // 전체 영역을 감싸도록 크기 조절
            takeoutButton.TextAlign = ContentAlignment.MiddleCenter; // 텍스트를 중앙에 위치시킴
            takeoutButton.ForeColor = Color.FromArgb(75, 137, 220); // 포장 글씨 색을 오른쪽 패널의 배경색과 같은 색으로 설정
            takeoutButton.Image = ResizeImage(Image.FromFile("C:\\Users\\USER\\source\\repos\\Cafe\\coffee.png"), 100, 100); // 이미지 설정
            takeoutButton.ImageAlign = ContentAlignment.MiddleCenter; // 이미지를 중앙에 위치시킴
            takeoutButton.TextImageRelation = TextImageRelation.ImageAboveText; // 이미지 위에 텍스트 표시
            takeoutButton.Padding = new Padding(0, 100, 0, 0);

            // 포장 버튼 클릭 이벤트 핸들러 등록
            takeoutButton.Click += TakeoutButton_Click;

            // 오른쪽 패널 설정
            Panel rightPanel = new Panel();
            rightPanel.BackColor = Color.FromArgb(75, 137, 220); // #4B89DC
            rightPanel.Size = new Size(this.Width / 2, this.Height);
            rightPanel.Location = new Point(this.Width / 2, 0); // 오른쪽 위치로 조정

            // 오른쪽 매장 버튼 설정
            Button dineInButton = new Button();
            dineInButton.Text = "매장 ";
            dineInButton.Font = new Font("한초롬돋움", 20); // 폰트 크기 증가
            dineInButton.Size = new Size(rightPanel.Width, rightPanel.Height); // 전체 영역을 감싸도록 크기 조절
            dineInButton.TextAlign = ContentAlignment.MiddleCenter; // 텍스트를 중앙에 위치시킴
            dineInButton.ForeColor = Color.White; // 매장 글씨 색을 흰색으로 설정
            dineInButton.Image = ResizeImage(Image.FromFile("C:\\Users\\USER\\source\\repos\\Cafe\\cup.png"), 100, 100); // 이미지 설정
            dineInButton.ImageAlign = ContentAlignment.MiddleCenter; // 이미지를 중앙에 위치시킴
            dineInButton.TextImageRelation = TextImageRelation.ImageAboveText; // 이미지 위에 텍스트 표시
            dineInButton.Padding = new Padding(0, 100, 0, 0);

            // 매장 버튼 클릭 이벤트 핸들러 등록
            dineInButton.Click += DineInButton_Click;

            // 버튼을 각 패널에 추가
            leftPanel.Controls.Add(takeoutButton);
            rightPanel.Controls.Add(dineInButton);

            // 패널을 폼에 추가
            this.Controls.Add(leftPanel);
            this.Controls.Add(rightPanel);
        }

        private void TakeoutButton_Click(object sender, EventArgs e)
        {
            // 포장 버튼이 클릭되었을 때 수행할 동작 추가
        }

        private void DineInButton_Click(object sender, EventArgs e)
        {
            // 매장 버튼이 클릭되었을 때 수행할 동작 추가
            OnDineInButtonClicked();
        }

        protected virtual void OnDineInButtonClicked()
        {
            DineInButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler DineInButtonClicked;

        private Image ResizeImage(Image originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }
            return resizedImage;
        }
    }
}
