using System;
using System.Windows.Forms;

namespace Cafe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Form1 인스턴스 생성
            Form1 form1 = new Form1();

            // Form1의 DineInButton_Click 메서드에 카페 메뉴 폼을 생성하고 표시하는 코드를 추가
            form1.DineInButtonClicked += (sender, e) =>
            {
                Form2 form2 = new Form2();
                form1.Hide();
                form2.ShowDialog();
                form1.Show();
            };

            // Form1 실행
            Application.Run(form1);
        }
    }
}
