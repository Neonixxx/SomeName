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
    public partial class Main_Form : Form
    {
        private Player _player;

        private Farm_Form _farmForm = new Farm_Form();

        private FarmController _farmController;

        public Main_Form(Player player)
        {
            InitializeComponent();
            _player = player;
            _farmController = new FarmController(_player, _farmForm);
            _farmForm.FarmController = _farmController;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Farm_Button_Click(object sender, EventArgs e)
        {
            _farmForm.StartFarm();
        }
    }
}
