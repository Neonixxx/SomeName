﻿namespace SomeName.Forms
{
    partial class MainForm
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
            this.Farm_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Inventory_Button = new System.Windows.Forms.Button();
            this.BattleDifficulty_ComboBox = new System.Windows.Forms.ComboBox();
            this.BattleDifficultyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Farm_Button
            // 
            this.Farm_Button.Location = new System.Drawing.Point(48, 39);
            this.Farm_Button.Name = "Farm_Button";
            this.Farm_Button.Size = new System.Drawing.Size(122, 68);
            this.Farm_Button.TabIndex = 0;
            this.Farm_Button.Text = "Farm";
            this.Farm_Button.UseVisualStyleBackColor = true;
            this.Farm_Button.Click += new System.EventHandler(this.Farm_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(662, 39);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(96, 78);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Inventory_Button
            // 
            this.Inventory_Button.Location = new System.Drawing.Point(157, 197);
            this.Inventory_Button.Name = "Inventory_Button";
            this.Inventory_Button.Size = new System.Drawing.Size(122, 68);
            this.Inventory_Button.TabIndex = 2;
            this.Inventory_Button.Text = "Inventory";
            this.Inventory_Button.UseVisualStyleBackColor = true;
            this.Inventory_Button.Click += new System.EventHandler(this.Inventory_Button_Click);
            // 
            // BattleDifficulty_ComboBox
            // 
            this.BattleDifficulty_ComboBox.FormattingEnabled = true;
            this.BattleDifficulty_ComboBox.Location = new System.Drawing.Point(176, 39);
            this.BattleDifficulty_ComboBox.Name = "BattleDifficulty_ComboBox";
            this.BattleDifficulty_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.BattleDifficulty_ComboBox.TabIndex = 3;
            // 
            // BattleDifficultyLabel
            // 
            this.BattleDifficultyLabel.AutoSize = true;
            this.BattleDifficultyLabel.Location = new System.Drawing.Point(193, 21);
            this.BattleDifficultyLabel.Name = "BattleDifficultyLabel";
            this.BattleDifficultyLabel.Size = new System.Drawing.Size(84, 13);
            this.BattleDifficultyLabel.TabIndex = 4;
            this.BattleDifficultyLabel.Text = "Сложность боя";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BattleDifficultyLabel);
            this.Controls.Add(this.BattleDifficulty_ComboBox);
            this.Controls.Add(this.Inventory_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Farm_Button);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Farm_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Button Inventory_Button;
        private System.Windows.Forms.ComboBox BattleDifficulty_ComboBox;
        private System.Windows.Forms.Label BattleDifficultyLabel;
    }
}

