namespace ElectronicLibrary
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(103, 549);
            label4.Name = "label4";
            label4.Size = new Size(272, 25);
            label4.TabIndex = 13;
            label4.Text = "Уже зарегистрированы?? Войти";
            label4.Click += label4_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 287);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 12;
            label3.Text = "пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 211);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 11;
            label2.Text = "логин";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(139, 284);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 31);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 208);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 31);
            textBox1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(62, 41);
            label1.Name = "label1";
            label1.Size = new Size(347, 70);
            label1.TabIndex = 8;
            label1.Text = "Регистрация";
            // 
            // button1
            // 
            button1.Location = new Point(62, 400);
            button1.Name = "button1";
            button1.Size = new Size(357, 93);
            button1.TabIndex = 7;
            button1.Text = "Зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnRegister_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(469, 622);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
    }
}