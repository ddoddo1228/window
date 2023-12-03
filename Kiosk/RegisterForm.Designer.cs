namespace Kiosk
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_skip = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtbox_name = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btn_register = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtbox_pwd = new System.Windows.Forms.TextBox();
            this.txtbox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_skip);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 525);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1184, 236);
            this.panel3.TabIndex = 6;
            // 
            // btn_skip
            // 
            this.btn_skip.Location = new System.Drawing.Point(1057, 153);
            this.btn_skip.Name = "btn_skip";
            this.btn_skip.Size = new System.Drawing.Size(110, 61);
            this.btn_skip.TabIndex = 0;
            this.btn_skip.Text = "스킵";
            this.btn_skip.UseVisualStyleBackColor = true;
            this.btn_skip.Click += new System.EventHandler(this.btn_skip_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 619);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("굴림", 15F);
            this.label4.Location = new System.Drawing.Point(351, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "별명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtbox_name);
            this.panel9.Location = new System.Drawing.Point(440, 203);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(312, 44);
            this.panel9.TabIndex = 10;
            // 
            // txtbox_name
            // 
            this.txtbox_name.BackColor = System.Drawing.Color.White;
            this.txtbox_name.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtbox_name.Location = new System.Drawing.Point(0, 23);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(312, 21);
            this.txtbox_name.TabIndex = 0;
            this.txtbox_name.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btn_register);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(323, 284);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(550, 102);
            this.panel8.TabIndex = 9;
            // 
            // btn_register
            // 
            this.btn_register.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_register.Location = new System.Drawing.Point(0, 0);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(550, 102);
            this.btn_register.TabIndex = 1;
            this.btn_register.Text = "회원가입";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(323, 386);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(550, 233);
            this.panel7.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(351, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "비밀번호";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 15F);
            this.label3.Location = new System.Drawing.Point(351, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "아이디";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtbox_pwd);
            this.panel6.Controls.Add(this.txtbox_id);
            this.panel6.Location = new System.Drawing.Point(440, 129);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(313, 71);
            this.panel6.TabIndex = 5;
            // 
            // txtbox_pwd
            // 
            this.txtbox_pwd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtbox_pwd.Location = new System.Drawing.Point(0, 50);
            this.txtbox_pwd.Name = "txtbox_pwd";
            this.txtbox_pwd.Size = new System.Drawing.Size(313, 21);
            this.txtbox_pwd.TabIndex = 4;
            this.txtbox_pwd.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // txtbox_id
            // 
            this.txtbox_id.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtbox_id.Location = new System.Drawing.Point(0, 0);
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(313, 21);
            this.txtbox_id.TabIndex = 3;
            this.txtbox_id.Click += new System.EventHandler(this.TextBox_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("굴림", 40F);
            this.label1.Location = new System.Drawing.Point(323, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 103);
            this.label1.TabIndex = 2;
            this.label1.Text = "회원가입";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(873, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(311, 619);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(323, 619);
            this.panel4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 142);
            this.panel1.TabIndex = 4;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RegisterForm";
            this.Text = "ReigsterForm";
            this.Load += new System.EventHandler(this.ReigsterForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_skip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtbox_pwd;
        private System.Windows.Forms.TextBox txtbox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtbox_name;
    }
}