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

            // Form1 �ν��Ͻ� ����
            Form1 form1 = new Form1();

            // Form1�� DineInButton_Click �޼��忡 ī�� �޴� ���� �����ϰ� ǥ���ϴ� �ڵ带 �߰�
            form1.DineInButtonClicked += (sender, e) =>
            {
                Form2 form2 = new Form2();
                form1.Hide();
                form2.ShowDialog();
                form1.Show();
            };

            // Form1 ����
            Application.Run(form1);
        }
    }
}
