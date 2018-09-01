using SomeName.Domain;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Armor : Equippment
    {
        public long BaseDefence { get; set; }

        public long Defence { get; set; }

        public override long BaseStatToEnchant { get => BaseDefence; set => BaseDefence = value; }

        public override long StatToEnchant { get => Defence; set => Defence = value; }

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
