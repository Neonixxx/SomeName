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
    // TODO : реализовать экипировку предметов.
    public partial class Inventory_Form : Form, ICanStart
    {
        //private bool IsElementDragged = false;
        //private Control DraggedControl;

        public InventoryController InventoryController { get; set; }

        private Dictionary<PictureBox, ItemType> _equippedItemsSlots;

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

            //InventoryItems.Clear();
            //for (int i = ITEMS_PER_PAGE * (CurrentPage - 1); i < itemsOnPage + ITEMS_PER_PAGE * (CurrentPage - 1); i++)
            //{
            //    InventoryItems.Add(Player.Items[i]);
            //}

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
                //InventoryPanel.Controls[i].MouseUp += InventoryPanelControls_MouseUp;
                //InventoryPanel.Controls[i].MouseMove += InventoryPanelControls_MouseMove;
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
            pictureBox.MouseDown += InventoryPanelControls_MouseDown;
        }

        //private void InventoryPanelControls_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (IsElementDragged)
        //    {
        //        DraggedControl.Location = e.Location;
        //    }
        //}

        //private void InventoryPanelControls_MouseUp(object sender, MouseEventArgs e)
        //{
        //    IsElementDragged = false;
        //}

        private void InventoryPanelControls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pictureBox = (PictureBox)sender;
                if (InventoryPanel.Controls.Contains(pictureBox))
                {
                    var itemIndex = InventoryPanel.Controls.IndexOf(pictureBox);
                    InventoryController.EquipItem(itemIndex);
                }
                else if (_equippedItemsSlots.ContainsKey(pictureBox))
                {
                    var itemType = _equippedItemsSlots[pictureBox];
                    InventoryController.UnequipItem(itemType);
                }
            }
            //else if (e.Button == MouseButtons.Left)
            //{
            //    IsElementDragged = true;
            //    DraggedControl = sender as Control;
            //    DraggedControl.MouseUp += InventoryPanelControls_MouseUp;
            //    DraggedControl.MouseMove += InventoryPanelControls_MouseMove;
            //    DraggedControl.Visible = true;
            //    Player.Items.RemoveAt(InventoryPanel.Controls.IndexOf(sender as Control));
            //    InventoryPanel.Controls.RemoveAt(InventoryPanel.Controls.IndexOf(sender as Control));
            //    InventoryRefresh();
            //}
        }

        //private void ContexMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    //Point point = (sender as PictureBox).PointToClient(ContexMenuItems.Bounds.Location);
        //}

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            CurrentPage = CurrentPage + 1;
        }
    }
}
