﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName
{
    public partial class Menu_Form : Form
    {
        public Menu_Form()
        {
            InitializeComponent();
        }

        private void NewGame_Button_Click(object sender, EventArgs e)
        {
            new Main_Form(PlayerIO.StartNew())
                .ShowDialog();
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
