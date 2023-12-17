namespace ElectronicLibrary
{
    partial class Form1
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(73, 469);
            button1.Name = "button1";
            button1.Size = new Size(260, 47);
            button1.TabIndex = 0;
            button1.Text = "Читать ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonOpenReadForm_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(12, 168);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(260, 100);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 124);
            label1.Name = "label1";
            label1.Size = new Size(191, 32);
            label1.TabIndex = 3;
            label1.Text = "Выберите книгу";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(487, 168);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(539, 219);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 6;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.HighlightText;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(414, 256);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(539, 422);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(176, 35);
            label3.Name = "label3";
            label3.Size = new Size(620, 65);
            label3.TabIndex = 8;
            label3.Text = "Электронная библиотека";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(414, 219);
            label5.Name = "label5";
            label5.Size = new Size(119, 25);
            label5.TabIndex = 10;
            label5.Text = "Дата выхода:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(414, 168);
            label6.Name = "label6";
            label6.Size = new Size(67, 25);
            label6.TabIndex = 9;
            label6.Text = "Автор:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(965, 691);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label4;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label label5;
        private Label label6;
    }
}