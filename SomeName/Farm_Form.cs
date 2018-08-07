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

        private long _maxExp;

        public long MaxExp
        {
            get => _maxExp;

            set
            {
                _maxExp = value;
                UpdateExp();
            }
        }

        private long _exp;

        public long Exp
        {
            get => _exp;

            set
            {
                _exp = value;
                UpdateExp();
            }
        }

        public long Gold
        {
            get => Gold_Label.Text.ToInt32();

            set => Gold_Label.Text = value.ToString();
        }

        public Farm_Form()
        {
            InitializeComponent();
        }

        public void UpdateExp()
        {
            double exp = 100 * _exp.ToDouble() / _maxExp;

            Exp_Bar.Value = exp.ToInt32();
            Exp_Label.Text = exp.ToString("F2") + "%";
        }

        public void StartFarm()
        {
            FarmController.Update();
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
