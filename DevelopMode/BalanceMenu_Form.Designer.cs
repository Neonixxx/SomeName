namespace DevelopMode
{
    partial class BalanceMenu_Form
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PrintBalanceInfo_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(350, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // PrintBalanceInfo_Button
            // 
            this.PrintBalanceInfo_Button.Location = new System.Drawing.Point(689, 12);
            this.PrintBalanceInfo_Button.Name = "PrintBalanceInfo_Button";
            this.PrintBalanceInfo_Button.Size = new System.Drawing.Size(99, 54);
            this.PrintBalanceInfo_Button.TabIndex = 1;
            this.PrintBalanceInfo_Button.Text = "Print balance info";
            this.PrintBalanceInfo_Button.UseVisualStyleBackColor = true;
            this.PrintBalanceInfo_Button.Click += new System.EventHandler(this.PrintBalanceInfo_Button_Click);
            // 
            // BalanceMenu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrintBalanceInfo_Button);
            this.Controls.Add(this.comboBox1);
            this.Name = "BalanceMenu_Form";
            this.Text = "BalanceMenu_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button PrintBalanceInfo_Button;
    }
}