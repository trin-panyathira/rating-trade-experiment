﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class MainPage : Form
    {
        //private int port = 10001;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void MainPage_Shown(object sender, EventArgs e)
        {

        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            ServerMainPage page = new ServerMainPage();
            this.Hide();
            page.Show();
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            ClientMainPage page = new ClientMainPage();
            this.Hide();
            page.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
