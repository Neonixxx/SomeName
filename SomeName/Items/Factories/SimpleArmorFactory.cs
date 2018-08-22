using SomeName.Balance;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Factories
{
    public class SimpleArmorFactory : ArmorFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseArmorGoldValue(level);

        public override Item Build(int level)
        {
            var damageValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var item = new SimpleArmor()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetArmorGoldValue(level, damageValueKoef),
                BaseDefence = DamageBalance.GetArmorDefence(level, damageValueKoef),
                Bonuses = CalculateBonuses(level)
            };
            item.Defence = item.BaseDefence;
            return item;
        }

        // TODO : Реализовать возможность выпадения бонусов шанса и силы крита.
        // TODO : Реализовать шанс выпадения бонусов.
        // TODO : Доделать выпадение разного числа бонусов.
        private ArmorBonuses CalculateBonuses(int level)
        {
            var powerValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var vitalityValueKoef = DamageBalance.GetItemDamageKoef(Dice.Roll);
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new ArmorBonuses
            {
                Power = DamageBalance.GetArmorPower(level, powerValueKoef),
                Vitality = DamageBalance.GetArmorVitality(level, vitalityValueKoef)
            };
        }
    }
}
