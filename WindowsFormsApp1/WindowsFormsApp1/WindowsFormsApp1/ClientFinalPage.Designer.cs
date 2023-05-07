using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class ClientFinalPage
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
            this.labelActualPayment = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelActualPayment
            // 
            this.labelActualPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelActualPayment.AutoSize = true;
            this.labelActualPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelActualPayment.Location = new System.Drawing.Point(280, 180);
            this.labelActualPayment.Name = "labelActualPayment";
            this.labelActualPayment.Size = new System.Drawing.Size(708, 33);
            this.labelActualPayment.TabIndex = 1;
            this.labelActualPayment.Text = "Your final payment for this experiment is  300.00 THB";
            this.labelActualPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelActualPayment.Click += new System.EventHandler(this.labelActualPayment_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(448, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thank you for participation\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(284, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(710, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "The calculation of the final payment in THB is 100 THB show-up fee plus \r\n(the pa" +
    "yoff from your 3 random rounds in ECU*0.365).";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientFinalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 607);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelActualPayment);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientFinalPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientFinalPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientFinalPage_Load);
            this.VisibleChanged += new System.EventHandler(this.ClientFinalPage_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelActualPayment;
        private Label label2;
        private Label label1;
    }
}