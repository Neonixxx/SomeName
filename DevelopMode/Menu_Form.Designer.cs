namespace DevelopMode
{
    partial class Menu_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BalanceMenu_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BalanceMenu_Button
            // 
            this.BalanceMenu_Button.Location = new System.Drawing.Point(73, 45);
            this.BalanceMenu_Button.Name = "BalanceMenu_Button";
            this.BalanceMenu_Button.Size = new System.Drawing.Size(103, 70);
            this.BalanceMenu_Button.TabIndex = 0;
            this.BalanceMenu_Button.Text = "Open balance menu";
            this.BalanceMenu_Button.UseVisualStyleBackColor = true;
            this.BalanceMenu_Button.Click += new System.EventHandler(this.BalanceMenu_Button_Click);
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BalanceMenu_Button);
            this.Name = "Menu_Form";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BalanceMenu_Button;
    }
}

