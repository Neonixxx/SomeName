using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName.Items.Factories
{
    public class SimpleGlovesFactory : GlovesFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseGlovesGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef() * additionalKoef;
            var item = new SimpleGloves()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetGlovesGoldValue(level, damageValueKoef),
                BaseDefence = GlovesStatsBalance.GetDefence(level, damageValueKoef),
                Bonuses = CalculateBonuses(level, additionalKoef)
            };
            item.Defence = item.BaseDefence;
            return item;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        private ArmorBonuses CalculateBonuses(int level, double additionalKoef)
        {
            var powerValueKoef = RollItemDamageKoef() * additionalKoef;
            var vitalityValueKoef = RollItemDamageKoef() * additionalKoef;
            var critChanceValueKoef = RollItemDamageKoef() * additionalKoef;
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new ArmorBonuses
            {
                Power = GlovesStatsBalance.GetPower(level, powerValueKoef),
                Vitality = GlovesStatsBalance.GetVitality(level, vitalityValueKoef),
                CritChance = GlovesStatsBalance.GetCritChance(level, critChanceValueKoef)
            };
        }
    }
}
