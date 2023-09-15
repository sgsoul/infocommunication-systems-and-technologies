﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Market
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            ProgressBar1.Value = startpoint;
            if (ProgressBar1.Value == 100)
            {
                ProgressBar1.Value = 0;
                timer1.Stop();
                Login log = new Login();
                this.Hide();
                log.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
