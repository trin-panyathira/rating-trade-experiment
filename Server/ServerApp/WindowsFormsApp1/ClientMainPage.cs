﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Constant;

namespace WindowsFormsApp1
{
    public partial class ClientMainPage : Form
    {
        public ClientMainPage()
        {
            InitializeComponent();
        }

        private void ClientMainPage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void ClientMainPage_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                SocketUtil.memoryModel.clientMainPage = this;

                // start sever
                SocketUtil.isServer = false;
                SocketUtil.StartThreadServer();
            }
        }

        delegate void ActivityCallback(Form f, string text);

        public void startExpirement(Form form, string text)
        {
            if (this.InvokeRequired)
            {
                ActivityCallback d = new ActivityCallback(startExpirement);
                form.Invoke(d, new object[] { form, text });
            }
            else
            {
                ClientExperimentPage page = new ClientExperimentPage();
                SocketUtil.memoryModel.isTest = true;
                page.Show();
                this.Hide();
            }
        }
    }
}
