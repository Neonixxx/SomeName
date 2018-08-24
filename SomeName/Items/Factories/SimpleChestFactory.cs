﻿using SomeName.Balance;
using SomeName.Balance.ItemStats;
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
    public class SimpleChestFactory : ChestFactory
    {
        public override long GetItemGoldValue(int level)
            => GetBaseChestGoldValue(level);

        public override Item Build(int level, double additionalKoef = 1.0)
        {
            var damageValueKoef = RollItemDamageKoef() * additionalKoef;
            var item = new SimpleChest()
            {
                Level = level,
                DamageValueKoef = damageValueKoef,
                GoldValue = GetChestGoldValue(level, damageValueKoef),
                BaseDefence = ChestStatsBalance.GetDefence(level, damageValueKoef),
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
            var itemBonusesCount = CalculateItemBonusesCount(level);

            return new ArmorBonuses
            {
                Power = ChestStatsBalance.GetPower(level, powerValueKoef),
                Vitality = ChestStatsBalance.GetVitality(level, vitalityValueKoef)
            };
        }
    }
}
