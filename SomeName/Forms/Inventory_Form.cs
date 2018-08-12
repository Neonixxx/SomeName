using System;
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

namespace SomeName.Forms
{
    public partial class Inventory_Form : Form, ICanStart
    {
        public InventoryController InventoryController { get; set; }

        private Dictionary<PictureBox, ItemType> _equippedItemsSlots;

        private PictureBox _selectedPictureBox;

        public const int ItemsPerPage = 30;

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

            _equippedItemsSlots = new Dictionary<PictureBox, ItemType>
            {
                { MainHandSlot, ItemType.Weapon }
            };
        }

        public void Start()
        {
            InventoryController.Start();
            ShowDialog();
        }

        public void Initialize(int itemsCount)
        {
            if (itemsCount % ItemsPerPage == 0 & itemsCount != 0)
                MaxPages = itemsCount / ItemsPerPage;
            else
                MaxPages = itemsCount / ItemsPerPage + 1;
            _firstItemIndex = ItemsPerPage * (CurrentPage - 1);
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
        }

        private void SetEquippedSlot(PictureBox pictureBox, Item item)
        {
            pictureBox.Image = item?.Image;
            ToolTip1.SetToolTip(pictureBox, item?.ToString());
            pictureBox.MouseDown += EquippedItemsSlots_MouseDown;
        }

        private void InventoryPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender is PictureBox pictureBox)
                    _selectedPictureBox = pictureBox;
                Inventory_ContextMenuStrip.Show(Cursor.Position);
            }
        }

        private void EquippedItemsSlots_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender is PictureBox pictureBox)
                    _selectedPictureBox = pictureBox;
                EquippedItems_ContextMenuStrip.Show(Cursor.Position);
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
                var itemIndex = InventoryPanel.Controls.IndexOf(_selectedPictureBox);
                InventoryController.EquipItem(itemIndex);
            }
        }

        private void СнятьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_equippedItemsSlots.ContainsKey(_selectedPictureBox))
            {
                var itemType = _equippedItemsSlots[_selectedPictureBox];
                InventoryController.UnequipItem(itemType);
            }
        }
    }
}
