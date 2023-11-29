// Form1.cs ���� ����

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
            this.Load += Form1_Load; // �� �ε� �̺�Ʈ �ڵ鷯 ���
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeUI();
            this.Show(); // ���� ǥ���ϵ��� �߰�
        }

        private void InitializeUI()
        {
            // �� ����
            this.Text = "ī�� ���� �ý���";
            this.Size = new Size(1200, 600); // ȭ�� ũ�� ����

            // ���� �г� ����
            Panel leftPanel = new Panel();
            leftPanel.BackColor = Color.White;
            leftPanel.Size = new Size(this.Width / 2, this.Height);
            leftPanel.Location = new Point(0, 0); // ���� ��ġ�� ����

            // ���� ���� ��ư ����
            Button takeoutButton = new Button();
            takeoutButton.Text = " ����";
            takeoutButton.Font = new Font("���ʷҵ���", 20); // ��Ʈ ũ�� ����
            takeoutButton.Size = new Size(leftPanel.Width, leftPanel.Height); // ��ü ������ ���ε��� ũ�� ����
            takeoutButton.TextAlign = ContentAlignment.MiddleCenter; // �ؽ�Ʈ�� �߾ӿ� ��ġ��Ŵ
            takeoutButton.ForeColor = Color.FromArgb(75, 137, 220); // ���� �۾� ���� ������ �г��� ������ ���� ������ ����
            takeoutButton.Image = ResizeImage(Image.FromFile("C:\\Users\\USER\\source\\repos\\Cafe\\coffee.png"), 100, 100); // �̹��� ����
            takeoutButton.ImageAlign = ContentAlignment.MiddleCenter; // �̹����� �߾ӿ� ��ġ��Ŵ
            takeoutButton.TextImageRelation = TextImageRelation.ImageAboveText; // �̹��� ���� �ؽ�Ʈ ǥ��
            takeoutButton.Padding = new Padding(0, 100, 0, 0);

            // ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯 ���
            takeoutButton.Click += TakeoutButton_Click;

            // ������ �г� ����
            Panel rightPanel = new Panel();
            rightPanel.BackColor = Color.FromArgb(75, 137, 220); // #4B89DC
            rightPanel.Size = new Size(this.Width / 2, this.Height);
            rightPanel.Location = new Point(this.Width / 2, 0); // ������ ��ġ�� ����

            // ������ ���� ��ư ����
            Button dineInButton = new Button();
            dineInButton.Text = "���� ";
            dineInButton.Font = new Font("���ʷҵ���", 20); // ��Ʈ ũ�� ����
            dineInButton.Size = new Size(rightPanel.Width, rightPanel.Height); // ��ü ������ ���ε��� ũ�� ����
            dineInButton.TextAlign = ContentAlignment.MiddleCenter; // �ؽ�Ʈ�� �߾ӿ� ��ġ��Ŵ
            dineInButton.ForeColor = Color.White; // ���� �۾� ���� ������� ����
            dineInButton.Image = ResizeImage(Image.FromFile("C:\\Users\\USER\\source\\repos\\Cafe\\cup.png"), 100, 100); // �̹��� ����
            dineInButton.ImageAlign = ContentAlignment.MiddleCenter; // �̹����� �߾ӿ� ��ġ��Ŵ
            dineInButton.TextImageRelation = TextImageRelation.ImageAboveText; // �̹��� ���� �ؽ�Ʈ ǥ��
            dineInButton.Padding = new Padding(0, 100, 0, 0);

            // ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯 ���
            dineInButton.Click += DineInButton_Click;

            // ��ư�� �� �гο� �߰�
            leftPanel.Controls.Add(takeoutButton);
            rightPanel.Controls.Add(dineInButton);

            // �г��� ���� �߰�
            this.Controls.Add(leftPanel);
            this.Controls.Add(rightPanel);
        }

        private void TakeoutButton_Click(object sender, EventArgs e)
        {
            // ���� ��ư�� Ŭ���Ǿ��� �� ������ ���� �߰�
        }

        private void DineInButton_Click(object sender, EventArgs e)
        {
            // ���� ��ư�� Ŭ���Ǿ��� �� ������ ���� �߰�
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
