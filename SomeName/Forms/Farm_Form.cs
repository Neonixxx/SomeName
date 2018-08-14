using SomeName.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomeName.Forms
{
    public partial class Farm_Form : Form, ICanStart
    {
        public FarmController FarmController;

        public Farm_Form()
        {
            InitializeComponent();
        }

        // TODO : сделать все обновления в один метод с параметром FarmInfo + настроить маппинг.
        #region Методы обновления UI

        public void UpdatePlayerLevel(int level)
            => Level_Label.Text = level.ToString();

        public void UpdatePlayerExp(long exp, long maxExp)
        {
            double percent = 100 * exp.ToDouble() / maxExp;

            Exp_Bar.Value = percent.ToInt32();
            Exp_Label.Text = percent.ToPercentString();
        }

        public void UpdatePlayerGold(long gold)
            => Gold_Label.Text = gold.ToString();

        public string MonsterInfo(string monsterText)
            => MonsterInfo_Label.Text = monsterText;

        public void UpdateMonsterHealth(long health, long maxHealth)
        {
            double percent = 100 * health.ToDouble() / maxHealth;

            MonsterHealth_Bar.Value = percent.ToInt32();
            MonsterHealth_Label.Text = percent.ToPercentString();
        }

        #endregion

        public void Start()
        {
            FarmController.StartFarm();
            ShowDialog();
        }

        private void Attack_Button_Click(object sender, EventArgs e)
        {
            FarmController.Attack();
        }
    }
}
