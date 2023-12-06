namespace Kiosk
{
    partial class StartForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_out = new System.Windows.Forms.Button();
            this.btn_in = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_out
            // 
            this.btn_out.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_out.Font = new System.Drawing.Font("굴림", 40F);
            this.btn_out.Location = new System.Drawing.Point(0, 0);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(585, 333);
            this.btn_out.TabIndex = 0;
            this.btn_out.Text = "포장";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // btn_in
            // 
            this.btn_in.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_in.Font = new System.Drawing.Font("굴림", 40F);
            this.btn_in.Location = new System.Drawing.Point(599, 0);
            this.btn_in.Name = "btn_in";
            this.btn_in.Size = new System.Drawing.Size(585, 333);
            this.btn_in.TabIndex = 1;
            this.btn_in.Text = "매장";
            this.btn_in.UseVisualStyleBackColor = true;
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_in);
            this.panel1.Controls.Add(this.btn_out);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 333);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("굴림", 40F);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1184, 164);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "\r\n환영합니다";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.Button btn_in;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

