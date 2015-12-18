namespace Tip71
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
            this.buttonGetPage = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGetPage
            // 
            this.buttonGetPage.Location = new System.Drawing.Point(37, 13);
            this.buttonGetPage.Name = "buttonGetPage";
            this.buttonGetPage.Size = new System.Drawing.Size(136, 23);
            this.buttonGetPage.TabIndex = 0;
            this.buttonGetPage.Text = "buttonGetPage";
            this.buttonGetPage.UseVisualStyleBackColor = true;
            this.buttonGetPage.Click += new System.EventHandler(this.buttonGetPage_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(37, 54);
            this.textBoxPage.Multiline = true;
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(407, 196);
            this.textBoxPage.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 262);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonGetPage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetPage;
        private System.Windows.Forms.TextBox textBoxPage;
    }
}

