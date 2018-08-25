namespace SomeName.Forms
{
    partial class ForgeForm
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
            this.ItemSlot = new System.Windows.Forms.PictureBox();
            this.ScrollOfEnchantSlot = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.EnchantButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemSlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollOfEnchantSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemSlot
            // 
            this.ItemSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ItemSlot.BackColor = System.Drawing.SystemColors.Control;
            this.ItemSlot.ImageLocation = "";
            this.ItemSlot.InitialImage = null;
            this.ItemSlot.Location = new System.Drawing.Point(108, 76);
            this.ItemSlot.Name = "ItemSlot";
            this.ItemSlot.Size = new System.Drawing.Size(45, 45);
            this.ItemSlot.TabIndex = 46;
            this.ItemSlot.TabStop = false;
            // 
            // ScrollOfEnchantSlot
            // 
            this.ScrollOfEnchantSlot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScrollOfEnchantSlot.BackColor = System.Drawing.SystemColors.Control;
            this.ScrollOfEnchantSlot.ImageLocation = "";
            this.ScrollOfEnchantSlot.InitialImage = null;
            this.ScrollOfEnchantSlot.Location = new System.Drawing.Point(221, 76);
            this.ScrollOfEnchantSlot.Name = "ScrollOfEnchantSlot";
            this.ScrollOfEnchantSlot.Size = new System.Drawing.Size(45, 45);
            this.ScrollOfEnchantSlot.TabIndex = 47;
            this.ScrollOfEnchantSlot.TabStop = false;
            // 
            // EnchantButton
            // 
            this.EnchantButton.Location = new System.Drawing.Point(149, 162);
            this.EnchantButton.Name = "EnchantButton";
            this.EnchantButton.Size = new System.Drawing.Size(74, 45);
            this.EnchantButton.TabIndex = 48;
            this.EnchantButton.Text = "Улучшить на +";
            this.EnchantButton.UseVisualStyleBackColor = true;
            this.EnchantButton.Click += new System.EventHandler(this.EnchantButton_Click);
            // 
            // ForgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 264);
            this.Controls.Add(this.EnchantButton);
            this.Controls.Add(this.ScrollOfEnchantSlot);
            this.Controls.Add(this.ItemSlot);
            this.Name = "ForgeForm";
            this.Text = "ForgeForm";
            ((System.ComponentModel.ISupportInitialize)(this.ItemSlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollOfEnchantSlot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ItemSlot;
        private System.Windows.Forms.PictureBox ScrollOfEnchantSlot;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button EnchantButton;
    }
}