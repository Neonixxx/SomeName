namespace SomeName.Forms
{
    partial class MenuForm
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
            this.NewGame_Button = new System.Windows.Forms.Button();
            this.Load_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame_Button
            // 
            this.NewGame_Button.Location = new System.Drawing.Point(44, 34);
            this.NewGame_Button.Name = "NewGame_Button";
            this.NewGame_Button.Size = new System.Drawing.Size(89, 72);
            this.NewGame_Button.TabIndex = 0;
            this.NewGame_Button.Text = "New Game";
            this.NewGame_Button.UseVisualStyleBackColor = true;
            this.NewGame_Button.Click += new System.EventHandler(this.NewGame_Button_Click);
            // 
            // Load_Button
            // 
            this.Load_Button.Location = new System.Drawing.Point(231, 34);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(89, 72);
            this.Load_Button.TabIndex = 1;
            this.Load_Button.Text = "Load";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 259);
            this.Controls.Add(this.Load_Button);
            this.Controls.Add(this.NewGame_Button);
            this.Name = "Menu_Form";
            this.Text = "Menu_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame_Button;
        private System.Windows.Forms.Button Load_Button;
    }
}