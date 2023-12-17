namespace ElectronicLibrary
{
    partial class LoginForm
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
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(80, 423);
            button1.Name = "button1";
            button1.Size = new Size(357, 93);
            button1.TabIndex = 0;
            button1.Text = "Авторизоваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(70, 64);
            label1.Name = "label1";
            label1.Size = new Size(367, 70);
            label1.TabIndex = 1;
            label1.Text = "Авторизация";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(157, 231);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 31);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(157, 307);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 31);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 234);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 4;
            label2.Text = "логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 310);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 5;
            label3.Text = "пароль";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(102, 575);
            label4.Name = "label4";
            label4.Size = new Size(304, 25);
            label4.TabIndex = 6;
            label4.Text = "Нет аккаунта?? Зарегистрироваться";
            label4.Click += label4_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(502, 711);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}