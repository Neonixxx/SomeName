namespace SomeName.Forms
{
    partial class Inventory_Form
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
            this.HelmetSlot = new System.Windows.Forms.PictureBox();
            this.ChestSlot = new System.Windows.Forms.PictureBox();
            this.PantsSlot = new System.Windows.Forms.PictureBox();
            this.BootsSlot = new System.Windows.Forms.PictureBox();
            this.MainHandSlot = new System.Windows.Forms.PictureBox();
            this.OffHandSlot = new System.Windows.Forms.PictureBox();
            this.GlovesSlot = new System.Windows.Forms.PictureBox();
            this.Inventory_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.надетьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EquippedItems_ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.снятьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatsInfo_Label = new System.Windows.Forms.Label();
            this.ItemInfo_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HelmetSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChestSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantsSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BootsSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainHandSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHandSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlovesSlot)).BeginInit();
            this.Inventory_ContextMenuStrip.SuspendLayout();
            this.EquippedItems_ContextMenuStrip.SuspendLayout();
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
            // Inventory_ContextMenuStrip
            // 
            this.Inventory_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.надетьToolStripMenuItem});
            this.Inventory_ContextMenuStrip.Name = "Inventory_ContextMenuStrip";
            this.Inventory_ContextMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // надетьToolStripMenuItem
            // 
            this.надетьToolStripMenuItem.Name = "надетьToolStripMenuItem";
            this.надетьToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.надетьToolStripMenuItem.Text = "Надеть";
            this.надетьToolStripMenuItem.Click += new System.EventHandler(this.НадетьToolStripMenuItem_Click);
            // 
            // EquippedItems_ContextMenuStrip
            // 
            this.EquippedItems_ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.снятьToolStripMenuItem});
            this.EquippedItems_ContextMenuStrip.Name = "EquippedItems_ContextMenuStrip";
            this.EquippedItems_ContextMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // снятьToolStripMenuItem
            // 
            this.снятьToolStripMenuItem.Name = "снятьToolStripMenuItem";
            this.снятьToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.снятьToolStripMenuItem.Text = "Снять";
            this.снятьToolStripMenuItem.Click += new System.EventHandler(this.СнятьToolStripMenuItem_Click);
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
            // Inventory_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 711);
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
            this.Name = "Inventory_Form";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.HelmetSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChestSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PantsSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BootsSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainHandSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffHandSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlovesSlot)).EndInit();
            this.Inventory_ContextMenuStrip.ResumeLayout(false);
            this.EquippedItems_ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.FlowLayoutPanel InventoryPanel;
        private System.Windows.Forms.PictureBox HelmetSlot;
        private System.Windows.Forms.PictureBox ChestSlot;
        private System.Windows.Forms.PictureBox PantsSlot;
        private System.Windows.Forms.PictureBox BootsSlot;
        private System.Windows.Forms.PictureBox MainHandSlot;
        private System.Windows.Forms.PictureBox OffHandSlot;
        private System.Windows.Forms.PictureBox GlovesSlot;
        private System.Windows.Forms.ContextMenuStrip Inventory_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem надетьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip EquippedItems_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem снятьToolStripMenuItem;
        private System.Windows.Forms.Label StatsInfo_Label;
        private System.Windows.Forms.Label ItemInfo_Label;
    }
}