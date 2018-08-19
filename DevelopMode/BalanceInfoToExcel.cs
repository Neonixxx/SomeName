using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using SomeName.Balance;

namespace DevelopMode
{
    class BalanceInfoToExcel
    {
        private const string _name = "example.xlsx";

        private const string _newName = "temp.xlsx";
        
        private static readonly string _path = Directory.GetCurrentDirectory() + @"\Temp\";

        public static void FillExcel()
        {
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(_path + _name);

            Worksheet workSheet = workbook.Worksheets["Лист1"];

            Fill(workSheet);

            File.Delete(_path + _newName);

            workbook.Close(true, _path + _newName);

            excel.Quit();
        }

        private static void Fill(Worksheet workSheet)
        {
            for (int i = 1; i <= 100; i++)
            {
                workSheet.Cells[i + 3, "E"] = DamageBalance.GetTapsForLevel(i);
                workSheet.Cells[i + 3, "F"] = DamageBalance.GetDefaultDamage(i);
                workSheet.Cells[i + 3, "G"] = MonsterBalance.GetDefaultMonsterHealth(i);
                workSheet.Cells[i + 3, "H"] = DropBalance.GetBaseWeaponGoldValue(i);
                workSheet.Cells[i + 3, "I"] = MonsterBalance.GetDefaultMonsterHealth(i) * DropBalance.DropItemsValueKoef / DropBalance.GetBaseWeaponGoldValue(i); // Шанс дропа оружия с монстра.
            }
        }
    }
}
