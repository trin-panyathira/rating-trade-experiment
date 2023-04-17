using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class ClientMainPage
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
            this.buttonConnectServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHostAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConnectServer
            // 
            this.buttonConnectServer.Location = new System.Drawing.Point(222, 44);
            this.buttonConnectServer.Name = "buttonConnectServer";
            this.buttonConnectServer.Size = new System.Drawing.Size(89, 32);
            this.buttonConnectServer.TabIndex = 0;
            this.buttonConnectServer.Text = "Connect";
            this.buttonConnectServer.UseVisualStyleBackColor = true;
            this.buttonConnectServer.Click += new System.EventHandler(this.buttonConnectServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host Address";
            // 
            // textBoxHostAddress
            // 
            this.textBoxHostAddress.Location = new System.Drawing.Point(116, 51);
            this.textBoxHostAddress.Name = "textBoxHostAddress";
            this.textBoxHostAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxHostAddress.TabIndex = 2;
            this.textBoxHostAddress.TextChanged += new System.EventHandler(this.textBoxHostAddress_TextChanged);
            // 
            // ClientMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 607);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxHostAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConnectServer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientMainPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientMainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientMainPage_Load);
            this.VisibleChanged += new System.EventHandler(this.ClientMainPage_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnectServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHostAddress;
    }
}