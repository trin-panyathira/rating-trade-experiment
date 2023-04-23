using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class ClientExperimentPage
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
            this.components = new System.ComponentModel.Container();
            this.labelRating1 = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.labelQuestion1 = new System.Windows.Forms.Label();
            this.labelQuality1 = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelRewardRebate = new System.Windows.Forms.Label();
            this.buttonRating0 = new System.Windows.Forms.Button();
            this.buttonRating1 = new System.Windows.Forms.Button();
            this.buttonRating2 = new System.Windows.Forms.Button();
            this.buttonRating3 = new System.Windows.Forms.Button();
            this.buttonRating5 = new System.Windows.Forms.Button();
            this.buttonRating4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonNextRound = new System.Windows.Forms.Button();
            this.labelPayoff = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRating1
            // 
            this.labelRating1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRating1.AutoSize = true;
            this.labelRating1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelRating1.Location = new System.Drawing.Point(454, 107);
            this.labelRating1.Name = "labelRating1";
            this.labelRating1.Size = new System.Drawing.Size(295, 42);
            this.labelRating1.TabIndex = 1;
            this.labelRating1.Text = "Seller’s Rating is";
            this.labelRating1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimer
            // 
            this.labelTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelTimer.Location = new System.Drawing.Point(1145, 9);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(78, 55);
            this.labelTimer.TabIndex = 3;
            this.labelTimer.Text = "30";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.buttonNo);
            this.groupBox1.Controls.Add(this.buttonYes);
            this.groupBox1.Controls.Add(this.labelQuestion1);
            this.groupBox1.Controls.Add(this.labelQuality1);
            this.groupBox1.Controls.Add(this.labelRating1);
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1237, 607);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(664, 457);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(112, 52);
            this.buttonNo.TabIndex = 5;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(516, 457);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(112, 52);
            this.buttonYes.TabIndex = 4;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // labelQuestion1
            // 
            this.labelQuestion1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuestion1.AutoSize = true;
            this.labelQuestion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelQuestion1.Location = new System.Drawing.Point(357, 396);
            this.labelQuestion1.Name = "labelQuestion1";
            this.labelQuestion1.Size = new System.Drawing.Size(606, 42);
            this.labelQuestion1.TabIndex = 3;
            this.labelQuestion1.Text = "Do you want to place buying order?";
            this.labelQuestion1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelQuestion1.Click += new System.EventHandler(this.labelQuestion1_Click);
            // 
            // labelQuality1
            // 
            this.labelQuality1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuality1.AutoSize = true;
            this.labelQuality1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelQuality1.Location = new System.Drawing.Point(578, 191);
            this.labelQuality1.Name = "labelQuality1";
            this.labelQuality1.Size = new System.Drawing.Size(171, 42);
            this.labelQuality1.TabIndex = 2;
            this.labelQuality1.Text = "Quality is";
            this.labelQuality1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelRound.Location = new System.Drawing.Point(12, 9);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(51, 55);
            this.labelRound.TabIndex = 6;
            this.labelRound.Text = "1";
            this.labelRound.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.labelRewardRebate);
            this.groupBox2.Controls.Add(this.buttonRating0);
            this.groupBox2.Controls.Add(this.buttonRating1);
            this.groupBox2.Controls.Add(this.buttonRating2);
            this.groupBox2.Controls.Add(this.buttonRating3);
            this.groupBox2.Controls.Add(this.buttonRating5);
            this.groupBox2.Controls.Add(this.buttonRating4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(2, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1237, 607);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // labelRewardRebate
            // 
            this.labelRewardRebate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRewardRebate.AutoSize = true;
            this.labelRewardRebate.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelRewardRebate.Location = new System.Drawing.Point(411, 149);
            this.labelRewardRebate.Name = "labelRewardRebate";
            this.labelRewardRebate.Size = new System.Drawing.Size(383, 42);
            this.labelRewardRebate.TabIndex = 14;
            this.labelRewardRebate.Text = "Your reward rebate is";
            this.labelRewardRebate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRating0
            // 
            this.buttonRating0.Location = new System.Drawing.Point(364, 457);
            this.buttonRating0.Name = "buttonRating0";
            this.buttonRating0.Size = new System.Drawing.Size(73, 52);
            this.buttonRating0.TabIndex = 12;
            this.buttonRating0.Text = "-";
            this.buttonRating0.UseVisualStyleBackColor = true;
            this.buttonRating0.Click += new System.EventHandler(this.buttonRating0_Click);
            // 
            // buttonRating1
            // 
            this.buttonRating1.Location = new System.Drawing.Point(462, 457);
            this.buttonRating1.Name = "buttonRating1";
            this.buttonRating1.Size = new System.Drawing.Size(73, 52);
            this.buttonRating1.TabIndex = 11;
            this.buttonRating1.Text = "1";
            this.buttonRating1.UseVisualStyleBackColor = true;
            this.buttonRating1.Click += new System.EventHandler(this.buttonRating1_Click);
            // 
            // buttonRating2
            // 
            this.buttonRating2.Location = new System.Drawing.Point(560, 457);
            this.buttonRating2.Name = "buttonRating2";
            this.buttonRating2.Size = new System.Drawing.Size(73, 52);
            this.buttonRating2.TabIndex = 10;
            this.buttonRating2.Text = "2";
            this.buttonRating2.UseVisualStyleBackColor = true;
            this.buttonRating2.Click += new System.EventHandler(this.buttonRating2_Click);
            // 
            // buttonRating3
            // 
            this.buttonRating3.Location = new System.Drawing.Point(658, 457);
            this.buttonRating3.Name = "buttonRating3";
            this.buttonRating3.Size = new System.Drawing.Size(73, 52);
            this.buttonRating3.TabIndex = 7;
            this.buttonRating3.Text = "3";
            this.buttonRating3.UseVisualStyleBackColor = true;
            this.buttonRating3.Click += new System.EventHandler(this.buttonRating3_Click);
            // 
            // buttonRating5
            // 
            this.buttonRating5.Location = new System.Drawing.Point(854, 457);
            this.buttonRating5.Name = "buttonRating5";
            this.buttonRating5.Size = new System.Drawing.Size(73, 52);
            this.buttonRating5.TabIndex = 6;
            this.buttonRating5.Text = "5";
            this.buttonRating5.UseVisualStyleBackColor = true;
            this.buttonRating5.Click += new System.EventHandler(this.buttonRating5_Click);
            // 
            // buttonRating4
            // 
            this.buttonRating4.Location = new System.Drawing.Point(756, 457);
            this.buttonRating4.Name = "buttonRating4";
            this.buttonRating4.Size = new System.Drawing.Size(73, 52);
            this.buttonRating4.TabIndex = 5;
            this.buttonRating4.Text = "4";
            this.buttonRating4.UseVisualStyleBackColor = true;
            this.buttonRating4.Click += new System.EventHandler(this.buttonRating4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(454, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select your Feedback";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.buttonNextRound);
            this.groupBox3.Controls.Add(this.labelPayoff);
            this.groupBox3.Location = new System.Drawing.Point(0, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1239, 606);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // buttonNextRound
            // 
            this.buttonNextRound.Location = new System.Drawing.Point(6, 544);
            this.buttonNextRound.Name = "buttonNextRound";
            this.buttonNextRound.Size = new System.Drawing.Size(1227, 56);
            this.buttonNextRound.TabIndex = 14;
            this.buttonNextRound.Text = "Next";
            this.buttonNextRound.UseVisualStyleBackColor = true;
            this.buttonNextRound.Click += new System.EventHandler(this.buttonNextRound_Click);
            // 
            // labelPayoff
            // 
            this.labelPayoff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPayoff.AutoSize = true;
            this.labelPayoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPayoff.Location = new System.Drawing.Point(337, 272);
            this.labelPayoff.Name = "labelPayoff";
            this.labelPayoff.Size = new System.Drawing.Size(481, 42);
            this.labelPayoff.TabIndex = 13;
            this.labelPayoff.Text = "Your Payoff For This Round";
            this.labelPayoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientExperimentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 607);
            this.ControlBox = false;
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientExperimentPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientExperimentPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientExperimentPage_Load);
            this.VisibleChanged += new System.EventHandler(this.ClientExperimentPage_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelRating1;
        private Label labelTimer;
        private Timer timer1;
        private GroupBox groupBox1;
        private Label labelQuality1;
        private Button buttonNo;
        private Button buttonYes;
        private Label labelQuestion1;
        private Label labelRound;
        private GroupBox groupBox2;
        private Button buttonRating0;
        private Button buttonRating1;
        private Button buttonRating2;
        private Button buttonRating3;
        private Button buttonRating5;
        private Button buttonRating4;
        private Label label1;
        private Label labelRewardRebate;
        private GroupBox groupBox3;
        private Label labelPayoff;
        private Button buttonNextRound;
    }
}