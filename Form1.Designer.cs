namespace 一键修改账户名密码
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(37, 58);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 45);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(299, 58);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(156, 45);
            textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(37, 226);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(158, 45);
            textBox3.TabIndex = 0;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(299, 226);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(156, 45);
            textBox4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(71, 24);
            label1.Name = "label1";
            label1.Size = new Size(86, 31);
            label1.TabIndex = 1;
            label1.Text = "账户名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(339, 24);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 1;
            label2.Text = "密码";
            // 
            // button1
            // 
            button1.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(53, 132);
            button1.Name = "button1";
            button1.Size = new Size(142, 48);
            button1.TabIndex = 2;
            button1.Text = "修改账户";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(312, 132);
            button2.Name = "button2";
            button2.Size = new Size(130, 48);
            button2.TabIndex = 2;
            button2.Text = "修改密码";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(53, 192);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 1;
            label3.Text = "当前账户名";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(323, 192);
            label4.Name = "label4";
            label4.Size = new Size(110, 31);
            label4.TabIndex = 1;
            label4.Text = "当前密码";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 282);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
    }
}