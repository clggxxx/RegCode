namespace CreateRegCode
{
    partial class CreateRegCode
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRegCode));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_day = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_guid = new System.Windows.Forms.TextBox();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "授权时长：";
            // 
            // textBox_day
            // 
            this.textBox_day.Location = new System.Drawing.Point(134, 72);
            this.textBox_day.Name = "textBox_day";
            this.textBox_day.Size = new System.Drawing.Size(100, 21);
            this.textBox_day.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "天";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "机器码：";
            // 
            // textBox_guid
            // 
            this.textBox_guid.Location = new System.Drawing.Point(134, 138);
            this.textBox_guid.Name = "textBox_guid";
            this.textBox_guid.Size = new System.Drawing.Size(394, 21);
            this.textBox_guid.TabIndex = 4;
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(134, 216);
            this.textBox_code.Multiline = true;
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.ReadOnly = true;
            this.textBox_code.Size = new System.Drawing.Size(394, 159);
            this.textBox_code.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "注册码：";
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(593, 99);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 276);
            this.button_Create.TabIndex = 7;
            this.button_Create.Text = "生成";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // CreateRegCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_code);
            this.Controls.Add(this.textBox_guid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_day);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRegCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册码生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_day;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_guid;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Create;
    }
}

