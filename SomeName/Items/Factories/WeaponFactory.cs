using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance.ItemStats;
using SomeName.Items.Interfaces;

namespace SomeName.Items.Factories
{
    // TODO : возможно реализовать другие виды оружия.
    public abstract class WeaponFactory : ItemFactory
    {
        protected readonly WeaponStatsBalance WeaponStatsBalance = new WeaponStatsBalance();

        protected const double WeaponGoldValueKoef = 0.5;

        protected long GetWeaponGoldValue(int level, double damageValueKoef)
            => Convert.ToInt64(GetBaseWeaponGoldValue(level) * damageValueKoef);

        protected long GetBaseWeaponGoldValue(int level)
            => Convert.ToInt64(GetBaseItemGoldValue(level) * WeaponGoldValueKoef);
    }
}
