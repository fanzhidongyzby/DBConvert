namespace DBConvert
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtTB = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ckMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "TableList：";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(12, 34);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(519, 21);
            this.txtDB.TabIndex = 2;
            this.txtDB.Text = "DataBaseName";
            // 
            // txtTB
            // 
            this.txtTB.Location = new System.Drawing.Point(80, 70);
            this.txtTB.Multiline = true;
            this.txtTB.Name = "txtTB";
            this.txtTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTB.Size = new System.Drawing.Size(451, 119);
            this.txtTB.TabIndex = 3;
            this.txtTB.Text = "TableList";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(456, 202);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(10, 213);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here for help";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ckMode
            // 
            this.ckMode.AutoSize = true;
            this.ckMode.Checked = true;
            this.ckMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMode.Location = new System.Drawing.Point(12, 12);
            this.ckMode.Name = "ckMode";
            this.ckMode.Size = new System.Drawing.Size(138, 16);
            this.ckMode.TabIndex = 8;
            this.ckMode.Text = "数据库名/连接字符串";
            this.ckMode.UseVisualStyleBackColor = true;
            this.ckMode.CheckedChanged += new System.EventHandler(this.ckMode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 241);
            this.Controls.Add(this.ckMode);
            this.Controls.Add(this.txtTB);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Sql the table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtTB;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox ckMode;
    }
}

