using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public class Armor : Item
    {
        public long BaseDefence { get; set; }

        public long Defence { get; set; }

        public ArmorBonuses Bonuses { get; set; } = new ArmorBonuses();

        public override string ToString()
        {
            var result = new StringBuilder($"{base.ToString()}{NewLine}Defence: {Defence}");
            var bonusesString = Bonuses.ToString();
            if (bonusesString != string.Empty)
                result.Append($"{NewLine}{bonusesString}");
            return result.ToString();
        }
    }
}
