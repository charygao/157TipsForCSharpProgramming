namespace Tip72
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
            this.buttonStartAThread = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartAThread
            // 
            this.buttonStartAThread.Location = new System.Drawing.Point(113, 22);
            this.buttonStartAThread.Name = "buttonStartAThread";
            this.buttonStartAThread.Size = new System.Drawing.Size(129, 23);
            this.buttonStartAThread.TabIndex = 0;
            this.buttonStartAThread.Text = "buttonStartAThread";
            this.buttonStartAThread.UseVisualStyleBackColor = true;
            this.buttonStartAThread.Click += new System.EventHandler(this.buttonStartAThread_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(278, 22);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(129, 23);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "buttonSet";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.buttonStartAThread);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartAThread;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

