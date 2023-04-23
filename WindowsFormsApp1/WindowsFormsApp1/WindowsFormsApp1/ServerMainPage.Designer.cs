namespace WindowsFormsApp1
{
    partial class ServerMainPage
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
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxRebate = new System.Windows.Forms.ComboBox();
            this.labelServerAddress = new System.Windows.Forms.Label();
            this.textBoxExperimentRound = new System.Windows.Forms.TextBox();
            this.textBoxTestRound = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxActivity = new System.Windows.Forms.ListBox();
            this.listBoxUser = new System.Windows.Forms.ListBox();
            this.textBoxPayoffDivideRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(148, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(115, 50);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop Experiment";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(18, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 50);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start Experiment";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.VisibleChanged += new System.EventHandler(this.buttonStart_VisibleChanged);
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.textBoxPayoffDivideRate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxRebate);
            this.panel1.Controls.Add(this.labelServerAddress);
            this.panel1.Controls.Add(this.textBoxExperimentRound);
            this.panel1.Controls.Add(this.textBoxTestRound);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 77);
            this.panel1.TabIndex = 5;
            // 
            // comboBoxRebate
            // 
            this.comboBoxRebate.FormattingEnabled = true;
            this.comboBoxRebate.Items.AddRange(new object[] {
            "Without Rebate",
            "Rebate"});
            this.comboBoxRebate.Location = new System.Drawing.Point(323, 53);
            this.comboBoxRebate.Name = "comboBoxRebate";
            this.comboBoxRebate.Size = new System.Drawing.Size(175, 21);
            this.comboBoxRebate.TabIndex = 9;
            // 
            // labelServerAddress
            // 
            this.labelServerAddress.AutoSize = true;
            this.labelServerAddress.Location = new System.Drawing.Point(536, 13);
            this.labelServerAddress.Name = "labelServerAddress";
            this.labelServerAddress.Size = new System.Drawing.Size(82, 13);
            this.labelServerAddress.TabIndex = 6;
            this.labelServerAddress.Text = "Server Address:";
            // 
            // textBoxExperimentRound
            // 
            this.textBoxExperimentRound.Location = new System.Drawing.Point(420, 29);
            this.textBoxExperimentRound.Name = "textBoxExperimentRound";
            this.textBoxExperimentRound.Size = new System.Drawing.Size(78, 20);
            this.textBoxExperimentRound.TabIndex = 8;
            // 
            // textBoxTestRound
            // 
            this.textBoxTestRound.Location = new System.Drawing.Point(420, 6);
            this.textBoxTestRound.Name = "textBoxTestRound";
            this.textBoxTestRound.Size = new System.Drawing.Size(78, 20);
            this.textBoxTestRound.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Experiment Round";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Test Round";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Online User";
            // 
            // listBoxActivity
            // 
            this.listBoxActivity.BackColor = System.Drawing.Color.LightYellow;
            this.listBoxActivity.FormattingEnabled = true;
            this.listBoxActivity.Location = new System.Drawing.Point(12, 112);
            this.listBoxActivity.Name = "listBoxActivity";
            this.listBoxActivity.Size = new System.Drawing.Size(441, 576);
            this.listBoxActivity.TabIndex = 8;
            // 
            // listBoxUser
            // 
            this.listBoxUser.BackColor = System.Drawing.Color.MintCream;
            this.listBoxUser.FormattingEnabled = true;
            this.listBoxUser.Location = new System.Drawing.Point(484, 112);
            this.listBoxUser.Name = "listBoxUser";
            this.listBoxUser.Size = new System.Drawing.Size(219, 576);
            this.listBoxUser.TabIndex = 9;
            // 
            // textBoxPayoffDivideRate
            // 
            this.textBoxPayoffDivideRate.Location = new System.Drawing.Point(605, 53);
            this.textBoxPayoffDivideRate.Name = "textBoxPayoffDivideRate";
            this.textBoxPayoffDivideRate.Size = new System.Drawing.Size(78, 20);
            this.textBoxPayoffDivideRate.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Payoff Rate";
            // 
            // ServerMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(715, 697);
            this.Controls.Add(this.listBoxUser);
            this.Controls.Add(this.listBoxActivity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "ServerMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerMainPage";
            this.Load += new System.EventHandler(this.ServerMainPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxExperimentRound;
        private System.Windows.Forms.TextBox textBoxTestRound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelServerAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxActivity;
        private System.Windows.Forms.ListBox listBoxUser;
        private System.Windows.Forms.ComboBox comboBoxRebate;
        private System.Windows.Forms.TextBox textBoxPayoffDivideRate;
        private System.Windows.Forms.Label label5;
    }
}