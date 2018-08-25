using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName.Forms
{
    // TODO : сделать открытие форм по центру от изначальной формы.
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void NewGame_Button_Click(object sender, EventArgs e)
        {
            this.StartForm(new MainForm(PlayerIO.StartNew()));
        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            var isLoaded = PlayerIO.TryLoad(out var player);
            if (isLoaded)
                this.StartForm(new MainForm(player));
            else
                MessageBox.Show("Не удалось загрузить персонажа.");
        }
    }
}
