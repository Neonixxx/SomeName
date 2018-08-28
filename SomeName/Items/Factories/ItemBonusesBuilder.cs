using SomeName.Balance.ItemStats;
using SomeName.Items.Bonuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Factories
{
    public class ItemBonusesBuilder
    {
        public int Level { get; }

        private readonly ItemStatsBalance _itemStatsBalance;

        private readonly ItemBonuses _itemBonuses;
        
        public ItemBonusesBuilder(int level, ItemStatsBalance itemStatsBalance)
        {
            Level = level;
            _itemStatsBalance = itemStatsBalance;
            _itemBonuses = new ItemBonuses();
        }

        public ItemBonuses Build()
            => _itemBonuses;

        public ItemBonusesBuilder CalculatePower(double damageValueKoef)
        {
            _itemBonuses.Power = _itemStatsBalance.GetPower(Level, damageValueKoef);
            return this;
        }

        public ItemBonusesBuilder CalculateVitality(double damageValueKoef)
        {
            _itemBonuses.Vitality = _itemStatsBalance.GetVitality(Level, damageValueKoef);
            return this;
        }

        public ItemBonusesBuilder CalculateCritChance(double damageValueKoef)
        {
            _itemBonuses.CritChance = _itemStatsBalance.GetCritChance(Level, damageValueKoef);
            return this;
        }

        public ItemBonusesBuilder CalculateCritDamage(double damageValueKoef)
        {
            _itemBonuses.CritDamage = _itemStatsBalance.GetCritDamage(Level, damageValueKoef);
            return this;
        }
    }
}
