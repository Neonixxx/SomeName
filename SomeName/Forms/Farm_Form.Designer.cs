namespace SomeName.Forms
{
    partial class Farm_Form
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
            this.Attack_Button = new System.Windows.Forms.Button();
            this.GoldText_Label = new System.Windows.Forms.Label();
            this.Gold_Label = new System.Windows.Forms.Label();
            this.Level_Label = new System.Windows.Forms.Label();
            this.LevelText_Label = new System.Windows.Forms.Label();
            this.Exp_Bar = new System.Windows.Forms.ProgressBar();
            this.Exp_Label = new System.Windows.Forms.Label();
            this.MonsterHealth_Bar = new System.Windows.Forms.ProgressBar();
            this.MonsterInfo_Label = new System.Windows.Forms.Label();
            this.MonsterHealth_Label = new System.Windows.Forms.Label();
            this.DropInfo_Label = new System.Windows.Forms.Label();
            this.ExpText_Label = new System.Windows.Forms.Label();
            this.PlayerHealth_Bar = new System.Windows.Forms.ProgressBar();
            this.PlayerHealth_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Attack_Button
            // 
            this.Attack_Button.Location = new System.Drawing.Point(318, 195);
            this.Attack_Button.Name = "Attack_Button";
            this.Attack_Button.Size = new System.Drawing.Size(153, 78);
            this.Attack_Button.TabIndex = 0;
            this.Attack_Button.Text = "Attack";
            this.Attack_Button.UseVisualStyleBackColor = true;
            this.Attack_Button.Click += new System.EventHandler(this.Attack_Button_Click);
            // 
            // GoldText_Label
            // 
            this.GoldText_Label.AutoSize = true;
            this.GoldText_Label.Location = new System.Drawing.Point(12, 114);
            this.GoldText_Label.Name = "GoldText_Label";
            this.GoldText_Label.Size = new System.Drawing.Size(29, 13);
            this.GoldText_Label.TabIndex = 1;
            this.GoldText_Label.Text = "Gold";
            // 
            // Gold_Label
            // 
            this.Gold_Label.AutoSize = true;
            this.Gold_Label.Location = new System.Drawing.Point(12, 140);
            this.Gold_Label.Name = "Gold_Label";
            this.Gold_Label.Size = new System.Drawing.Size(56, 13);
            this.Gold_Label.TabIndex = 2;
            this.Gold_Label.Text = "GoldValue";
            // 
            // Level_Label
            // 
            this.Level_Label.AutoSize = true;
            this.Level_Label.Location = new System.Drawing.Point(12, 35);
            this.Level_Label.Name = "Level_Label";
            this.Level_Label.Size = new System.Drawing.Size(60, 13);
            this.Level_Label.TabIndex = 6;
            this.Level_Label.Text = "LevelValue";
            // 
            // LevelText_Label
            // 
            this.LevelText_Label.AutoSize = true;
            this.LevelText_Label.Location = new System.Drawing.Point(12, 9);
            this.LevelText_Label.Name = "LevelText_Label";
            this.LevelText_Label.Size = new System.Drawing.Size(33, 13);
            this.LevelText_Label.TabIndex = 5;
            this.LevelText_Label.Text = "Level";
            // 
            // Exp_Bar
            // 
            this.Exp_Bar.Location = new System.Drawing.Point(12, 73);
            this.Exp_Bar.Name = "Exp_Bar";
            this.Exp_Bar.Size = new System.Drawing.Size(125, 26);
            this.Exp_Bar.TabIndex = 7;
            // 
            // Exp_Label
            // 
            this.Exp_Label.AutoSize = true;
            this.Exp_Label.Location = new System.Drawing.Point(58, 79);
            this.Exp_Label.Name = "Exp_Label";
            this.Exp_Label.Size = new System.Drawing.Size(62, 13);
            this.Exp_Label.TabIndex = 8;
            this.Exp_Label.Text = "ExpPercent";
            // 
            // MonsterHealth_Bar
            // 
            this.MonsterHealth_Bar.Location = new System.Drawing.Point(217, 44);
            this.MonsterHealth_Bar.Name = "MonsterHealth_Bar";
            this.MonsterHealth_Bar.Size = new System.Drawing.Size(360, 48);
            this.MonsterHealth_Bar.TabIndex = 9;
            // 
            // MonsterInfo_Label
            // 
            this.MonsterInfo_Label.AutoSize = true;
            this.MonsterInfo_Label.Location = new System.Drawing.Point(377, 19);
            this.MonsterInfo_Label.Name = "MonsterInfo_Label";
            this.MonsterInfo_Label.Size = new System.Drawing.Size(63, 13);
            this.MonsterInfo_Label.TabIndex = 10;
            this.MonsterInfo_Label.Text = "MonsterInfo";
            // 
            // MonsterHealth_Label
            // 
            this.MonsterHealth_Label.AutoSize = true;
            this.MonsterHealth_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MonsterHealth_Label.Location = new System.Drawing.Point(376, 57);
            this.MonsterHealth_Label.Name = "MonsterHealth_Label";
            this.MonsterHealth_Label.Size = new System.Drawing.Size(188, 22);
            this.MonsterHealth_Label.TabIndex = 11;
            this.MonsterHealth_Label.Text = "MonsterHealthPercent";
            // 
            // DropInfo_Label
            // 
            this.DropInfo_Label.AutoSize = true;
            this.DropInfo_Label.Location = new System.Drawing.Point(610, 19);
            this.DropInfo_Label.Name = "DropInfo_Label";
            this.DropInfo_Label.Size = new System.Drawing.Size(48, 13);
            this.DropInfo_Label.TabIndex = 12;
            this.DropInfo_Label.Text = "DropInfo";
            // 
            // ExpText_Label
            // 
            this.ExpText_Label.AutoSize = true;
            this.ExpText_Label.Location = new System.Drawing.Point(61, 57);
            this.ExpText_Label.Name = "ExpText_Label";
            this.ExpText_Label.Size = new System.Drawing.Size(25, 13);
            this.ExpText_Label.TabIndex = 3;
            this.ExpText_Label.Text = "Exp";
            // 
            // PlayerHealth_Bar
            // 
            this.PlayerHealth_Bar.Location = new System.Drawing.Point(12, 393);
            this.PlayerHealth_Bar.Name = "PlayerHealth_Bar";
            this.PlayerHealth_Bar.Size = new System.Drawing.Size(840, 45);
            this.PlayerHealth_Bar.TabIndex = 13;
            // 
            // PlayerHealth_Label
            // 
            this.PlayerHealth_Label.AutoSize = true;
            this.PlayerHealth_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerHealth_Label.Location = new System.Drawing.Point(395, 404);
            this.PlayerHealth_Label.Name = "PlayerHealth_Label";
            this.PlayerHealth_Label.Size = new System.Drawing.Size(175, 22);
            this.PlayerHealth_Label.TabIndex = 14;
            this.PlayerHealth_Label.Text = "PlayerHealthPercent";
            // 
            // Farm_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.PlayerHealth_Label);
            this.Controls.Add(this.PlayerHealth_Bar);
            this.Controls.Add(this.DropInfo_Label);
            this.Controls.Add(this.MonsterHealth_Label);
            this.Controls.Add(this.MonsterInfo_Label);
            this.Controls.Add(this.MonsterHealth_Bar);
            this.Controls.Add(this.Exp_Label);
            this.Controls.Add(this.Exp_Bar);
            this.Controls.Add(this.Level_Label);
            this.Controls.Add(this.LevelText_Label);
            this.Controls.Add(this.ExpText_Label);
            this.Controls.Add(this.Gold_Label);
            this.Controls.Add(this.GoldText_Label);
            this.Controls.Add(this.Attack_Button);
            this.Name = "Farm_Form";
            this.Text = "Farm_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Attack_Button;
        private System.Windows.Forms.Label GoldText_Label;
        private System.Windows.Forms.Label Gold_Label;
        private System.Windows.Forms.Label Level_Label;
        private System.Windows.Forms.Label LevelText_Label;
        private System.Windows.Forms.ProgressBar Exp_Bar;
        private System.Windows.Forms.Label Exp_Label;
        private System.Windows.Forms.ProgressBar MonsterHealth_Bar;
        private System.Windows.Forms.Label MonsterInfo_Label;
        private System.Windows.Forms.Label MonsterHealth_Label;
        private System.Windows.Forms.Label DropInfo_Label;
        private System.Windows.Forms.Label ExpText_Label;
        private System.Windows.Forms.ProgressBar PlayerHealth_Bar;
        private System.Windows.Forms.Label PlayerHealth_Label;
    }
}