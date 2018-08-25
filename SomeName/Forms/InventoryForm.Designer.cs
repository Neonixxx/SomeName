namespace SomeName.Forms
{
    partial class InventoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.InventoryPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Inventory_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.надетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улучшитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EquippedItems_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.снятьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улучшитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatsInfo_Label = new System.Windows.Forms.Label();
            this.ItemInfo_Label = new System.Windows.Forms.Label();
            this.Gold_Label = new System.Windows.Forms.Label();
            this.Sell_Button = new System.Windows.Forms.Button();
            this.GlovesSlot = new System.Windows.Forms.PictureBox();
            this.OffHandSlot = new System.Windows.Forms.PictureBox();
            this.MainHandSlot = new System.Windows.Forms.PictureBox();
            this.BootsSlot = new System.Windows.Forms.PictureBox();
            this.PantsSlot = new System.Windows.Forms.PictureBox();
            this.ChestSlot = new System.Windows.Forms.PictureBox();
            this.HelmetSlot = new System.Windows.Forms.PictureBox();
            this.EnchantButton = new System.Windows.Forms.Button();
            this.ScrollOfEnchantSlot = new System.Windows.Forms.PictureBox();
            this.ItemToEnchantSlot = new System.Windows.Forms.PictureBox();
            this.EnchantChanceLabel = new System.Windows.Forms.Label();
            this.Inventory_ContextMenuStrip.SuspendLayout();
            this.EquippedItems_ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GlovesSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHandSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainHandSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BootsSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantsSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChestSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelmetSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollOfEnchantSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemToEnchantSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.Location = new System.Drawing.Point(522, 520);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(50, 42);
            this.PreviousPageButton.TabIndex = 35;
            this.PreviousPageButton.Text = "Left";
            this.PreviousPageButton.UseVisualStyleBackColor = true;
            this.PreviousPageButton.Click += new System.EventHandler(this.PreviousPageButton_Click);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Location = new System.Drawing.Point(890, 520);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(50, 42);
            this.NextPageButton.TabIndex = 36;
            this.NextPageButton.Text = "Right";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(687, 396);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(88, 13);
            this.PageLabel.TabIndex = 37;
            this.PageLabel.Text = "Страница 1 из 1";
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.Location = new System.Drawing.Point(578, 412);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(306, 260);
            this.InventoryPanel.TabIndex = 38;
            // 
            // Inventory_ContextMenuStrip
            // 
            this.Inventory_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.надетьToolStripMenuItem,
            this.улучшитьToolStripMenuItem1});
            this.Inventory_ContextMenuStrip.Name = "Inventory_ContextMenuStrip";
            this.Inventory_ContextMenuStrip.Size = new System.Drawing.Size(131, 48);
            // 
            // надетьToolStripMenuItem
            // 
            this.надетьToolStripMenuItem.Name = "надетьToolStripMenuItem";
            this.надетьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.надетьToolStripMenuItem.Text = "Надеть";
            this.надетьToolStripMenuItem.Click += new System.EventHandler(this.НадетьToolStripMenuItem_Click);
            // 
            // улучшитьToolStripMenuItem1
            // 
            this.улучшитьToolStripMenuItem1.Name = "улучшитьToolStripMenuItem1";
            this.улучшитьToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.улучшитьToolStripMenuItem1.Text = "Улучшить";
            this.улучшитьToolStripMenuItem1.Click += new System.EventHandler(this.улучшитьToolStripMenuItem_Click);
            // 
            // EquippedItems_ContextMenuStrip
            // 
            this.EquippedItems_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снятьToolStripMenuItem,
            this.улучшитьToolStripMenuItem});
            this.EquippedItems_ContextMenuStrip.Name = "EquippedItems_ContextMenuStrip";
            this.EquippedItems_ContextMenuStrip.Size = new System.Drawing.Size(131, 48);
            // 
            // снятьToolStripMenuItem
            // 
            this.снятьToolStripMenuItem.Name = "снятьToolStripMenuItem";
            this.снятьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.снятьToolStripMenuItem.Text = "Снять";
            this.снятьToolStripMenuItem.Click += new System.EventHandler(this.СнятьToolStripMenuItem_Click);
            // 
            // улучшитьToolStripMenuItem
            // 
            this.улучшитьToolStripMenuItem.Name = "улучшитьToolStripMenuItem";
            this.улучшитьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.улучшитьToolStripMenuItem.Text = "Улучшить";
            this.улучшитьToolStripMenuItem.Click += new System.EventHandler(this.улучшитьToolStripMenuItem_Click);
            // 
            // StatsInfo_Label
            // 
            this.StatsInfo_Label.AutoSize = true;
            this.StatsInfo_Label.Location = new System.Drawing.Point(478, 58);
            this.StatsInfo_Label.Name = "StatsInfo_Label";
            this.StatsInfo_Label.Size = new System.Drawing.Size(49, 13);
            this.StatsInfo_Label.TabIndex = 46;
            this.StatsInfo_Label.Text = "StatsInfo";
            // 
            // ItemInfo_Label
            // 
            this.ItemInfo_Label.AutoSize = true;
            this.ItemInfo_Label.Location = new System.Drawing.Point(394, 430);
            this.ItemInfo_Label.Name = "ItemInfo_Label";
            this.ItemInfo_Label.Size = new System.Drawing.Size(45, 13);
            this.ItemInfo_Label.TabIndex = 47;
            this.ItemInfo_Label.Text = "ItemInfo";
            // 
            // Gold_Label
            // 
            this.Gold_Label.AutoSize = true;
            this.Gold_Label.Location = new System.Drawing.Point(575, 682);
            this.Gold_Label.Name = "Gold_Label";
            this.Gold_Label.Size = new System.Drawing.Size(29, 13);
            this.Gold_Label.TabIndex = 48;
            this.Gold_Label.Text = "Gold";
            // 
            // Sell_Button
            // 
            this.Sell_Button.Location = new System.Drawing.Point(286, 395);
            this.Sell_Button.Name = "Sell_Button";
            this.Sell_Button.Size = new System.Drawing.Size(102, 48);
            this.Sell_Button.TabIndex = 49;
            this.Sell_Button.Text = "Sell";
            this.Sell_Button.UseVisualStyleBackColor = true;
            this.Sell_Button.Click += new System.EventHandler(this.Sell_Button_Click);
            // 
            // GlovesSlot
            // 
            this.GlovesSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GlovesSlot.BackColor = System.Drawing.SystemColors.Control;
            this.GlovesSlot.ImageLocation = "";
            this.GlovesSlot.InitialImage = null;
            this.GlovesSlot.Location = new System.Drawing.Point(665, 190);
            this.GlovesSlot.Name = "GlovesSlot";
            this.GlovesSlot.Size = new System.Drawing.Size(45, 45);
            this.GlovesSlot.TabIndex = 45;
            this.GlovesSlot.TabStop = false;
            // 
            // OffHandSlot
            // 
            this.OffHandSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OffHandSlot.BackColor = System.Drawing.SystemColors.Control;
            this.OffHandSlot.ImageLocation = "";
            this.OffHandSlot.InitialImage = null;
            this.OffHandSlot.Location = new System.Drawing.Point(845, 256);
            this.OffHandSlot.Name = "OffHandSlot";
            this.OffHandSlot.Size = new System.Drawing.Size(45, 45);
            this.OffHandSlot.TabIndex = 44;
            this.OffHandSlot.TabStop = false;
            // 
            // MainHandSlot
            // 
            this.MainHandSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainHandSlot.BackColor = System.Drawing.SystemColors.Control;
            this.MainHandSlot.ImageLocation = "";
            this.MainHandSlot.InitialImage = null;
            this.MainHandSlot.Location = new System.Drawing.Point(665, 256);
            this.MainHandSlot.Name = "MainHandSlot";
            this.MainHandSlot.Size = new System.Drawing.Size(45, 45);
            this.MainHandSlot.TabIndex = 43;
            this.MainHandSlot.TabStop = false;
            // 
            // BootsSlot
            // 
            this.BootsSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BootsSlot.BackColor = System.Drawing.SystemColors.Control;
            this.BootsSlot.ImageLocation = "";
            this.BootsSlot.InitialImage = null;
            this.BootsSlot.Location = new System.Drawing.Point(755, 256);
            this.BootsSlot.Name = "BootsSlot";
            this.BootsSlot.Size = new System.Drawing.Size(45, 45);
            this.BootsSlot.TabIndex = 42;
            this.BootsSlot.TabStop = false;
            // 
            // PantsSlot
            // 
            this.PantsSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PantsSlot.BackColor = System.Drawing.SystemColors.Control;
            this.PantsSlot.ImageLocation = "";
            this.PantsSlot.InitialImage = null;
            this.PantsSlot.Location = new System.Drawing.Point(755, 190);
            this.PantsSlot.Name = "PantsSlot";
            this.PantsSlot.Size = new System.Drawing.Size(45, 45);
            this.PantsSlot.TabIndex = 41;
            this.PantsSlot.TabStop = false;
            // 
            // ChestSlot
            // 
            this.ChestSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChestSlot.BackColor = System.Drawing.SystemColors.Control;
            this.ChestSlot.ImageLocation = "";
            this.ChestSlot.InitialImage = null;
            this.ChestSlot.Location = new System.Drawing.Point(755, 124);
            this.ChestSlot.Name = "ChestSlot";
            this.ChestSlot.Size = new System.Drawing.Size(45, 45);
            this.ChestSlot.TabIndex = 40;
            this.ChestSlot.TabStop = false;
            // 
            // HelmetSlot
            // 
            this.HelmetSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HelmetSlot.BackColor = System.Drawing.SystemColors.Control;
            this.HelmetSlot.ImageLocation = "";
            this.HelmetSlot.InitialImage = null;
            this.HelmetSlot.Location = new System.Drawing.Point(755, 58);
            this.HelmetSlot.Name = "HelmetSlot";
            this.HelmetSlot.Size = new System.Drawing.Size(45, 45);
            this.HelmetSlot.TabIndex = 39;
            this.HelmetSlot.TabStop = false;
            // 
            // EnchantButton
            // 
            this.EnchantButton.Location = new System.Drawing.Point(279, 643);
            this.EnchantButton.Name = "EnchantButton";
            this.EnchantButton.Size = new System.Drawing.Size(74, 45);
            this.EnchantButton.TabIndex = 51;
            this.EnchantButton.Text = "Улучшить на +";
            this.EnchantButton.UseVisualStyleBackColor = true;
            this.EnchantButton.Click += new System.EventHandler(this.EnchantButton_Click);
            // 
            // ScrollOfEnchantSlot
            // 
            this.ScrollOfEnchantSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScrollOfEnchantSlot.BackColor = System.Drawing.SystemColors.Control;
            this.ScrollOfEnchantSlot.ImageLocation = "";
            this.ScrollOfEnchantSlot.InitialImage = null;
            this.ScrollOfEnchantSlot.Location = new System.Drawing.Point(343, 557);
            this.ScrollOfEnchantSlot.Name = "ScrollOfEnchantSlot";
            this.ScrollOfEnchantSlot.Size = new System.Drawing.Size(45, 45);
            this.ScrollOfEnchantSlot.TabIndex = 50;
            this.ScrollOfEnchantSlot.TabStop = false;
            // 
            // ItemToEnchantSlot
            // 
            this.ItemToEnchantSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ItemToEnchantSlot.BackColor = System.Drawing.SystemColors.Control;
            this.ItemToEnchantSlot.ImageLocation = "";
            this.ItemToEnchantSlot.InitialImage = null;
            this.ItemToEnchantSlot.Location = new System.Drawing.Point(244, 557);
            this.ItemToEnchantSlot.Name = "ItemToEnchantSlot";
            this.ItemToEnchantSlot.Size = new System.Drawing.Size(45, 45);
            this.ItemToEnchantSlot.TabIndex = 49;
            this.ItemToEnchantSlot.TabStop = false;
            // 
            // EnchantChanceLabel
            // 
            this.EnchantChanceLabel.AutoSize = true;
            this.EnchantChanceLabel.Location = new System.Drawing.Point(299, 616);
            this.EnchantChanceLabel.Name = "EnchantChanceLabel";
            this.EnchantChanceLabel.Size = new System.Drawing.Size(107, 13);
            this.EnchantChanceLabel.TabIndex = 52;
            this.EnchantChanceLabel.Text = "EnchantmentChance";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 711);
            this.Controls.Add(this.EnchantChanceLabel);
            this.Controls.Add(this.EnchantButton);
            this.Controls.Add(this.ScrollOfEnchantSlot);
            this.Controls.Add(this.ItemToEnchantSlot);
            this.Controls.Add(this.Sell_Button);
            this.Controls.Add(this.Gold_Label);
            this.Controls.Add(this.ItemInfo_Label);
            this.Controls.Add(this.StatsInfo_Label);
            this.Controls.Add(this.GlovesSlot);
            this.Controls.Add(this.OffHandSlot);
            this.Controls.Add(this.MainHandSlot);
            this.Controls.Add(this.BootsSlot);
            this.Controls.Add(this.PantsSlot);
            this.Controls.Add(this.ChestSlot);
            this.Controls.Add(this.HelmetSlot);
            this.Controls.Add(this.InventoryPanel);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.PreviousPageButton);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.Inventory_Form_Load);
            this.Inventory_ContextMenuStrip.ResumeLayout(false);
            this.EquippedItems_ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GlovesSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHandSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainHandSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BootsSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantsSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChestSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HelmetSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollOfEnchantSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemToEnchantSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.FlowLayoutPanel InventoryPanel;
        private System.Windows.Forms.ContextMenuStrip Inventory_ContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip EquippedItems_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem снятьToolStripMenuItem;
        private System.Windows.Forms.Label StatsInfo_Label;
        private System.Windows.Forms.Label ItemInfo_Label;
        private System.Windows.Forms.Label Gold_Label;
        private System.Windows.Forms.Button Sell_Button;
        private System.Windows.Forms.ToolStripMenuItem надетьToolStripMenuItem;
        private System.Windows.Forms.PictureBox GlovesSlot;
        private System.Windows.Forms.PictureBox OffHandSlot;
        private System.Windows.Forms.PictureBox MainHandSlot;
        private System.Windows.Forms.PictureBox BootsSlot;
        private System.Windows.Forms.PictureBox PantsSlot;
        private System.Windows.Forms.PictureBox ChestSlot;
        private System.Windows.Forms.PictureBox HelmetSlot;
        private System.Windows.Forms.ToolStripMenuItem улучшитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem улучшитьToolStripMenuItem;
        private System.Windows.Forms.Button EnchantButton;
        private System.Windows.Forms.PictureBox ScrollOfEnchantSlot;
        private System.Windows.Forms.PictureBox ItemToEnchantSlot;
        private System.Windows.Forms.Label EnchantChanceLabel;
    }
}