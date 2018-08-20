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
            FormClosing += Farm_Form_FormClosing;
            UpdateTimer.Tick += UpdateTimer_Tick;
            UpdateTimer.Interval = 50;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
            => FarmController.Update();

        private void Farm_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateTimer.Enabled = false;
            FarmController.Stop();
        }

        // TODO : сделать все обновления в один метод с параметром FarmInfo + настроить маппинг.
        #region Методы обновления UI

        public void UpdatePlayerLevel(int level)
            => Level_Label.Text = level.ToString();

        public void UpdatePlayerExp(long exp, long maxExp)
        {
            double percent = exp.ToDouble() / maxExp;

            Exp_Bar.Value = (percent * 100).ToInt32();
            Exp_Label.Text = percent.ToPercentString();
        }

        public void UpdatePlayerGold(long gold)
            => Gold_Label.Text = gold.ToString();

        public void UpdatePlayerHealth(long health, long maxHealth)
        {
            double percent = health.ToDouble() / maxHealth;

            PlayerHealth_Bar.Value = (percent * 100).ToInt32();
            PlayerHealth_Label.Text = percent.ToPercentString();
        }

        public string MonsterInfo(string monsterText)
            => MonsterInfo_Label.Text = monsterText;

        public void UpdateMonsterHealth(long health, long maxHealth)
        {
            double percent = health.ToDouble() / maxHealth;

            MonsterHealth_Bar.Value = (percent * 100).ToInt32();
            MonsterHealth_Label.Text = percent.ToPercentString();
        }

        private string[] _drops = new string[3] { "", "", "" };

        public void UpdateDropInfo(DropInfo dropInfo)
        {
            _drops[2] = _drops[1];
            _drops[1] = _drops[0];
            _drops[0] = dropInfo.ToString();
            var doubleNewLine = Environment.NewLine + Environment.NewLine;
            DropInfo_Label.Text = $"{_drops[0]}" +
                $"{doubleNewLine}{_drops[1]}" +
                $"{doubleNewLine}{_drops[2]}";
        }

        #endregion

        public void Start()
        {
            UpdateTimer.Enabled = true;
            ShowDialog();
        }

        private void Attack_Button_Click(object sender, EventArgs e)
            => FarmController.Attack();
    }
}
