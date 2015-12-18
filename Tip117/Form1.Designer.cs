namespace Tip117
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
            this.listBoxServer = new System.Windows.Forms.ListBox();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonStartSendToClient = new System.Windows.Forms.Button();
            this.listBoxClient = new System.Windows.Forms.ListBox();
            this.buttonConnectAndReceiveMsg = new System.Windows.Forms.Button();
            this.buttonStartSendToServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxServer
            // 
            this.listBoxServer.FormattingEnabled = true;
            this.listBoxServer.ItemHeight = 12;
            this.listBoxServer.Location = new System.Drawing.Point(12, 12);
            this.listBoxServer.Name = "listBoxServer";
            this.listBoxServer.Size = new System.Drawing.Size(206, 220);
            this.listBoxServer.TabIndex = 0;
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(12, 253);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(128, 23);
            this.buttonStartServer.TabIndex = 1;
            this.buttonStartServer.Text = "buttonStartServer";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStartSendToClient
            // 
            this.buttonStartSendToClient.Location = new System.Drawing.Point(12, 282);
            this.buttonStartSendToClient.Name = "buttonStartSendToClient";
            this.buttonStartSendToClient.Size = new System.Drawing.Size(206, 23);
            this.buttonStartSendToClient.TabIndex = 2;
            this.buttonStartSendToClient.Text = "buttonStartSendToClient";
            this.buttonStartSendToClient.UseVisualStyleBackColor = true;
            this.buttonStartSendToClient.Click += new System.EventHandler(this.buttonStartSendToClient_Click);
            // 
            // listBoxClient
            // 
            this.listBoxClient.FormattingEnabled = true;
            this.listBoxClient.ItemHeight = 12;
            this.listBoxClient.Location = new System.Drawing.Point(279, 12);
            this.listBoxClient.Name = "listBoxClient";
            this.listBoxClient.Size = new System.Drawing.Size(206, 220);
            this.listBoxClient.TabIndex = 3;
            // 
            // buttonConnectAndReceiveMsg
            // 
            this.buttonConnectAndReceiveMsg.Location = new System.Drawing.Point(279, 253);
            this.buttonConnectAndReceiveMsg.Name = "buttonConnectAndReceiveMsg";
            this.buttonConnectAndReceiveMsg.Size = new System.Drawing.Size(206, 23);
            this.buttonConnectAndReceiveMsg.TabIndex = 4;
            this.buttonConnectAndReceiveMsg.Text = "buttonConnectAndReceiveMsg";
            this.buttonConnectAndReceiveMsg.UseVisualStyleBackColor = true;
            this.buttonConnectAndReceiveMsg.Click += new System.EventHandler(this.buttonConnectAndReceiveMsg_Click);
            // 
            // buttonStartSendToServer
            // 
            this.buttonStartSendToServer.Location = new System.Drawing.Point(279, 282);
            this.buttonStartSendToServer.Name = "buttonStartSendToServer";
            this.buttonStartSendToServer.Size = new System.Drawing.Size(206, 23);
            this.buttonStartSendToServer.TabIndex = 5;
            this.buttonStartSendToServer.Text = "buttonStartSendToServer";
            this.buttonStartSendToServer.UseVisualStyleBackColor = true;
            this.buttonStartSendToServer.Click += new System.EventHandler(this.buttonStartSendToServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 434);
            this.Controls.Add(this.buttonStartSendToServer);
            this.Controls.Add(this.buttonConnectAndReceiveMsg);
            this.Controls.Add(this.listBoxClient);
            this.Controls.Add(this.buttonStartSendToClient);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.listBoxServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxServer;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonStartSendToClient;
        private System.Windows.Forms.ListBox listBoxClient;
        private System.Windows.Forms.Button buttonConnectAndReceiveMsg;
        private System.Windows.Forms.Button buttonStartSendToServer;
    }
}

