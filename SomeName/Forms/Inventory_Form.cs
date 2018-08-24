﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomeName.Items.Interfaces;
using System.Windows.Input;
using SomeName.Domain;

namespace SomeName.Forms
{
    // TODO : Добавить возможность продавать предмет.
    public partial class Inventory_Form : Form
    {
        public InventoryController InventoryController { get; set; }

        private Dictionary<PictureBox, ItemType> _equippedItemsSlots;

        private PictureBox _selectedPictureBox;

        private const int ItemsPerPage = 30;

        private int _currentPage = 1;
        private int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (1 <= value & value <= MaxPages)
                {
                    _currentPage = value;
                    PageLabel.Text = $"Страница {_currentPage} из {MaxPages}";
                    _firstItemIndex = ItemsPerPage * (_currentPage - 1);
                    InventoryController.Update();
                }
            }
        }

        private int _firstItemIndex;

        private int _maxPages = 1;
        private int MaxPages
        {
            get
            {
                return _maxPages;
            }
            set
            {
                _maxPages = value;
                PageLabel.Text = $"Страница {CurrentPage} из {_maxPages}";
            }
        }

        public Inventory_Form()
        {
            InitializeComponent();
            ToolTip1.InitialDelay = 1;
            ItemInfo_Label.Text = string.Empty;

            _equippedItemsSlots = new Dictionary<PictureBox, ItemType>
            {
                { MainHandSlot, ItemType.Weapon },
                { ChestSlot, ItemType.Armor }
            };
        }

        public void Start(int itemsCount)
        {
            if (itemsCount % ItemsPerPage == 0 & itemsCount != 0)
                MaxPages = itemsCount / ItemsPerPage;
            else
                MaxPages = itemsCount / ItemsPerPage + 1;
            _firstItemIndex = ItemsPerPage * (CurrentPage - 1);

            InventoryController.Update();
            
            ShowDialog();
        }

        /// <summary>
        /// Прорисовка инвентаря
        /// </summary>
        public void UpdateInventory(List<Item> items)
        {
            int itemsOnPage;
            if (items.Count <= ItemsPerPage * CurrentPage)
                itemsOnPage = items.Count - _firstItemIndex;
            else
                itemsOnPage = ItemsPerPage;

            PictureBox[] pb = new PictureBox[itemsOnPage];
            InventoryPanel.Controls.Clear();

            for (int i = 0; i < pb.Length; i++)
            {
                pb[i] = new PictureBox
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = items[i + _firstItemIndex].Image,
                    Size = new Size(45, 45)
                };
                InventoryPanel.Controls.Add(pb[i]);
                ToolTip1.SetToolTip(InventoryPanel.Controls[i], items[i + _firstItemIndex].ToString());
                InventoryPanel.Controls[i].AllowDrop = true;
                InventoryPanel.Controls[i].MouseDown += InventoryPanelControls_MouseDown;
            }
        }

        public void UpdateEquippedItems(EquippedItems equippedItems)
        {
            SetEquippedSlot(MainHandSlot, equippedItems.Weapon);
            SetEquippedSlot(ChestSlot, equippedItems.Armor);
        }

        private void SetEquippedSlot(PictureBox pictureBox, Item item)
        {
            pictureBox.Image = item?.Image;
            ToolTip1.SetToolTip(pictureBox, item?.ToString());
            pictureBox.MouseDown += EquippedItemsSlots_MouseDown;
        }

        public void UpdateStatsInfo(StatsInfo statsInfo)
        {
            StatsInfo_Label.Text = statsInfo.ToString();
        }

        public void UpdateGold(long goldValue)
            => Gold_Label.Text = $"Золото: {goldValue}";

        /// <summary>
        /// Событие нажатия мышки на предмет в инвентаре.
        /// </summary>
        /// <param name="sender">PictureBox предмета в инвентаре.</param>
        /// <param name="e"></param>
        private void InventoryPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelectedPictureBox((PictureBox)sender);

            if (e.Button == MouseButtons.Right)
            {
                Inventory_ContextMenuStrip.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Событие нажатия мышки на экипированный предмет.
        /// </summary>
        /// <param name="sender">PictureBox экипированного предмета.</param>
        /// <param name="e"></param>
        private void EquippedItemsSlots_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelectedPictureBox((PictureBox)sender);

            if (e.Button == MouseButtons.Right)
            {
                EquippedItems_ContextMenuStrip.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// Поместить выбранный предмет (PictureBox) в фокус.
        /// </summary>
        /// <param name="pictureBox">Выбранный предмет (PictureBox).</param>
        private void SetSelectedPictureBox(PictureBox pictureBox)
        {
            if (_selectedPictureBox != null)
                _selectedPictureBox.BorderStyle = BorderStyle.None;

            _selectedPictureBox = pictureBox;
            _selectedPictureBox.BorderStyle = BorderStyle.Fixed3D;

            ItemInfo_Label.Text = ToolTip1.GetToolTip(_selectedPictureBox);
            if (InventoryPanel.Controls.Contains(_selectedPictureBox))
            {
                var itemIndex = (_currentPage - 1) * ItemsPerPage + InventoryPanel.Controls.IndexOf(_selectedPictureBox);
                Sell_Button.Text = $"Sell for:{Environment.NewLine}{InventoryController.GetGoldValueOfItem(itemIndex)}";
            }
            
        }

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage + 1;
        }

        private void НадетьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InventoryPanel.Controls.Contains(_selectedPictureBox))
            {
                var itemIndex = (_currentPage - 1) * ItemsPerPage + InventoryPanel.Controls.IndexOf(_selectedPictureBox);
                InventoryController.EquipItem(itemIndex);
                InventoryController.Update();
            }
        }

        private void СнятьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_equippedItemsSlots.ContainsKey(_selectedPictureBox))
            {
                var itemType = _equippedItemsSlots[_selectedPictureBox];
                InventoryController.UnequipItem(itemType);
                InventoryController.Update();
            }
        }

        private void Inventory_Form_Load(object sender, EventArgs e)
        {

        }

        private void Sell_Button_Click(object sender, EventArgs e)
        {
            if (InventoryPanel.Controls.Contains(_selectedPictureBox))
            {
                var itemIndex = (_currentPage - 1) * ItemsPerPage + InventoryPanel.Controls.IndexOf(_selectedPictureBox);
                InventoryController.SellItem(itemIndex);
                InventoryController.Update();
                if (InventoryPanel.Controls.Count <= itemIndex)
                    itemIndex--;

                if (InventoryPanel.Controls.Count > 0)
                    SetSelectedPictureBox(InventoryPanel.Controls[itemIndex] as PictureBox);
            }
        }
    }
}
