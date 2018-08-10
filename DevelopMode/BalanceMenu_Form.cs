using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevelopMode
{
    public partial class BalanceMenu_Form : Form
    {
        public BalanceMenu_Form()
        {
            InitializeComponent();
        }

        private void PrintBalanceInfo_Button_Click(object sender, EventArgs e)
        {
            BalanceInfoToExcel.FillExcel();
            MessageBox.Show("Completed");
        }
    }
}
