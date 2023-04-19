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
            this.SuspendLayout();
            // 
            // labelActualPayment
            // 
            this.labelActualPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelActualPayment.AutoSize = true;
            this.labelActualPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelActualPayment.Location = new System.Drawing.Point(475, 194);
            this.labelActualPayment.Name = "labelActualPayment";
            this.labelActualPayment.Size = new System.Drawing.Size(201, 29);
            this.labelActualPayment.TabIndex = 1;
            this.labelActualPayment.Text = "Actual Payment is";
            this.labelActualPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(410, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thank you for participated";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientFinalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 607);
            this.ControlBox = false;
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
    }
}