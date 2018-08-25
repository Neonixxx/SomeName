using SomeName.Items.Impl;
using SomeName.Items.Interfaces;
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
    public partial class ForgeForm : Form
    {
        private Weapon _itemToEnchant;

        private ScrollOfEnchantWeapon _scrollOfEnchant;

        public ForgeForm()
        {
            InitializeComponent();
        }

        public void Start(Weapon item, ScrollOfEnchantWeapon scrollOfEnchant)
        {
            _itemToEnchant = item;
            _scrollOfEnchant = scrollOfEnchant;

            EnchantButton.Text += item.EnchantmentLevel + 1;
            SetSlot(ItemSlot, _itemToEnchant);
            SetSlot(ScrollOfEnchantSlot, _scrollOfEnchant);
        }

        private void SetSlot(PictureBox pictureBox, Item item)
        {
            pictureBox.Image = item?.Image;
            toolTip1.SetToolTip(pictureBox, item?.ToString());
        }

        private void EnchantButton_Click(object sender, EventArgs e)
        {

        }
    }
}
