using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName
{
    public partial class Farm_Form : Form
    {
        public FarmController FarmController;

        public int Level
        {
            get => Level_Label.Text.ToInt32();

            set => Level_Label.Text = value.ToString();
        }

        public long Gold
        {
            get => Gold_Label.Text.ToInt32();

            set => Gold_Label.Text = value.ToString();
        }

        public string MonsterInfo
        {
            set => MonsterInfo_Label.Text = value;
        }

        public Farm_Form()
        {
            InitializeComponent();
        }

        public void UpdatePlayerExp(long exp, long maxExp)
        {
            double percent = 100 * exp.ToDouble() / maxExp;

            Exp_Bar.Value = percent.ToInt32();
            Exp_Label.Text = percent.ToPercentString();
        }

        public void UpdateMonsterHealth(long health, long maxHealth)
        {
            double percent = 100 * health.ToDouble() / maxHealth;

            MonsterHealth_Bar.Value = percent.ToInt32();
            MonsterHealth_Label.Text = percent.ToPercentString();
        }

        public void StartFarm()
        {
            FarmController.StartFarm();
            ShowDialog();
        }

        public void StopFarm()
        {

        }

        private void Attack_Button_Click(object sender, EventArgs e)
        {
            FarmController.Attack();
        }
    }
}
