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
using SomeName.Domain;
using SomeName.Items.Impl;

namespace SomeName.Forms
{
    public partial class InventoryForm : Form
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

        private EquippedItems _equippedItems;

        public InventoryForm()
        {
            InitializeComponent();
            ToolTip1.InitialDelay = 1;
            ItemInfo_Label.Text = string.Empty;
            EnchantChanceLabel.Text = string.Empty;

            _equippedItemsSlots = new Dictionary<PictureBox, ItemType>
            {
                { MainHandSlot, ItemType.Weapon },
                { ChestSlot, ItemType.Chest },
                { GlovesSlot, ItemType.Gloves }
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
        public void UpdateInventory(List<IItem> items)
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
                InventoryPanel.Controls[i].MouseDown += InventoryPanelControls_MouseDown;
            }
        }

        private List<IItem> _sellingItems;

        public void UpdateSellingItems(List<IItem> items)
        {
            _sellingItems = items;
            SellingItemsPanel.Controls.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                var pictureBox = new PictureBox
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = items[i + _firstItemIndex].Image,
                    Size = new Size(45, 45)
                };
                SellingItemsPanel.Controls.Add(pictureBox);
                ToolTip1.SetToolTip(SellingItemsPanel.Controls[i], items[i + _firstItemIndex].ToString());
                SellingItemsPanel.Controls[i].MouseDown += SellingItemsPanelControls_MouseDown;
            }
        }

        private void SellingItemsPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            SetSelectedPictureBox((PictureBox)sender);
        }

        public void UpdateEquippedItems(EquippedItems equippedItems)
        {
            _equippedItems = equippedItems;
            SetEquippedSlot(MainHandSlot, equippedItems.Weapon);
            SetEquippedSlot(ChestSlot, equippedItems.Chest);
            SetEquippedSlot(GlovesSlot, equippedItems.Gloves);
        }

        private void SetEquippedSlot(PictureBox pictureBox, Item item)
        {
            SetPictureBox(pictureBox, item);
            pictureBox.MouseDown += EquippedItemsSlots_MouseDown;
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
                var itemIndex = GetSelectedItemIndex();
                Sell_Button.Text = $"Sell for:{Environment.NewLine}{InventoryController.GetSellGoldValueOfItem(itemIndex)}";
            }
            else if (SellingItemsPanel.Controls.Contains(_selectedPictureBox))
            {
                var index = SellingItemsPanel.Controls.IndexOf(_selectedPictureBox);
                var sellingItem = _sellingItems[index];
                BuyButton.Text = $"Buy for: {Environment.NewLine}{sellingItem.GoldValue}";
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
                var itemIndex = GetSelectedItemIndex();
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
                var itemIndex = GetSelectedItemIndex();
                InventoryController.SellItem(itemIndex);
                InventoryController.Update();
                if (InventoryPanel.Controls.Count <= itemIndex)
                    itemIndex--;

                if (InventoryPanel.Controls.Count > 0)
                    SetSelectedPictureBox(InventoryPanel.Controls[itemIndex] as PictureBox);
            }
        }

        private int GetSelectedItemIndex()
            => (_currentPage - 1) * ItemsPerPage + InventoryPanel.Controls.IndexOf(_selectedPictureBox);

        private ICanBeEnchanted _itemToEnchant;

        private ScrollOfEnchant _scrollOfEnchant;

        private void УлучшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
                return;
                
            if (item is ICanBeEnchanted itemToEnchant)
            {
                _itemToEnchant = itemToEnchant;
                UpdateItemToEnchantSlot(_itemToEnchant);

                if (_scrollOfEnchant != null && !InventoryController.CanBeEnchantedWith(_itemToEnchant, _scrollOfEnchant))
                {
                    _scrollOfEnchant = null;
                    SetPictureBox(ScrollOfEnchantSlot, null);
                }
            }
            else if (item is ScrollOfEnchant scrollOfEnchant)
            {
                if (_itemToEnchant == null || InventoryController.CanBeEnchantedWith(_itemToEnchant, scrollOfEnchant))
                {
                    _scrollOfEnchant = scrollOfEnchant;
                    SetPictureBox(ScrollOfEnchantSlot, scrollOfEnchant);
                }
            }

            if (_itemToEnchant != null && _scrollOfEnchant != null)
            {
                EnchantChanceLabel.Text = InventoryController.GetItemEnchantChance(_itemToEnchant, _scrollOfEnchant)
                    .ToPercentString(2);

                EnchantButton.Text = $"Улучшить на +{_itemToEnchant.EnchantmentLevel + 1}";
            }
            else
            {
                EnchantChanceLabel.Text = "";
                EnchantButton.Text = "";
            }
        }

        private void UpdateItemToEnchantSlot(ICanBeEnchanted itemToEnchant)
        {
            SetPictureBox(ItemToEnchantSlot, itemToEnchant);
        }

        private void SetPictureBox(PictureBox pictureBox, IItem item)
        {
            pictureBox.Image = item?.Image;
            ToolTip1.SetToolTip(pictureBox, item?.ToString());
        }

        private IItem GetSelectedItem()
        {
            IItem item = null;
            if (InventoryPanel.Controls.Contains(_selectedPictureBox))
            {
                var itemIndex = GetSelectedItemIndex();
                item = InventoryController.GetItem(itemIndex);
            }
            else if (_equippedItemsSlots.ContainsKey(_selectedPictureBox))
            {
                // HACK : Технический долг - нужно убрать зависимость от количества предметов в EquippedItems.
                switch (_equippedItemsSlots[_selectedPictureBox])
                {
                    case ItemType.Weapon: item = _equippedItems.Weapon; break;
                    case ItemType.Gloves: item = _equippedItems.Gloves; break;
                    case ItemType.Chest: item = _equippedItems.Chest; break;
                }
            }
            else if (SellingItemsPanel.Controls.Contains(_selectedPictureBox))
            {
                var index = SellingItemsPanel.Controls.IndexOf(_selectedPictureBox);
                item = _sellingItems[index];
            }
            return item;
        }

        private void EnchantButton_Click(object sender, EventArgs e)
        {
            if (_itemToEnchant != null && _scrollOfEnchant != null)
            {
                var isEnchantSuccesful = InventoryController.EnchantWeapon(_itemToEnchant, _scrollOfEnchant);
                InventoryController.Update();

                _scrollOfEnchant = null;
                SetPictureBox(ScrollOfEnchantSlot, null);

                if (isEnchantSuccesful)
                {
                    UpdateItemToEnchantSlot(_itemToEnchant);
                    EnchantChanceLabel.Text = "Успешно";
                }
                else
                {
                    UpdateItemToEnchantSlot(null);
                    EnchantChanceLabel.Text = "Неуспешно";
                }
                EnchantButton.Text = "";
            }
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();
            if (InventoryController.CanBuyItem(selectedItem))
                InventoryController.BuyItem(selectedItem);
        }
    }
}
