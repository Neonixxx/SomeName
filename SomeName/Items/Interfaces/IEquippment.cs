using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public interface IEquippment : IItem
    {
        ItemBonuses Bonuses { get; set; }

        double DamageValueKoef { get; set; }

        long BaseGoldValue { get; set; }
    }
}
