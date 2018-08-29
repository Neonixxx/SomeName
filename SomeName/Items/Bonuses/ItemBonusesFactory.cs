using SomeName.Balance.ItemStats;
using SomeName.Items.Bonuses;
using SomeName.Items.ItemFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Bonuses
{
    public class ItemBonusesFactory
    {
        private static readonly List<Func<ItemBonusesBuilder, double, ItemBonusesBuilder>> _itemBonusesCalculators = new List<Func<ItemBonusesBuilder, double, ItemBonusesBuilder>>
        {
            (builder, damageValueKoef) => builder.CalculatePower(damageValueKoef),
            (builder, damageValueKoef) => builder.CalculateVitality(damageValueKoef),
            (builder, damageValueKoef) => builder.CalculateCritChance(damageValueKoef),
            (builder, damageValueKoef) => builder.CalculateCritDamage(damageValueKoef)
        };

        public ItemBonuses Build(ItemStatsBalance itemStatsBalance, int level, double additionalKoef)
        {
            var minBonusesCount = itemStatsBalance.GetMinItemBonusesCount(level);
            var maxBonusesCount = itemStatsBalance.GetMaxItemBonusesCount(level);
            var bonusesCount = Dice.GetRange(minBonusesCount, maxBonusesCount);

            var itemBonusesCalculators = GetFuncs(itemStatsBalance)
                .TakeRandom(bonusesCount);
            var itemBonusesBuilder = new ItemBonusesBuilder(itemStatsBalance, level);
            foreach (var bonusesCalculator in itemBonusesCalculators)
                bonusesCalculator.Invoke(itemBonusesBuilder, ItemFactory.RollItemDamageKoef(additionalKoef));

            return itemBonusesBuilder.Build();
        }

        private List<Func<ItemBonusesBuilder, double, ItemBonusesBuilder>> GetFuncs(ItemStatsBalance itemStatsBalance)
        {
            var result = new List<Func<ItemBonusesBuilder, double, ItemBonusesBuilder>>(_itemBonusesCalculators.Count);
            var possibleItemBonuses = itemStatsBalance.PossibleItemBonuses;

            if ((possibleItemBonuses & ItemBonusesEnum.Power) == ItemBonusesEnum.Power)
                result.Add(_itemBonusesCalculators[0]);
            if ((possibleItemBonuses & ItemBonusesEnum.Vitality) == ItemBonusesEnum.Vitality)
                result.Add(_itemBonusesCalculators[1]);
            if ((possibleItemBonuses & ItemBonusesEnum.CritChance) == ItemBonusesEnum.CritChance)
                result.Add(_itemBonusesCalculators[2]);
            if ((possibleItemBonuses & ItemBonusesEnum.CritDamage) == ItemBonusesEnum.CritDamage)
                result.Add(_itemBonusesCalculators[3]);

            return result;
        }
    }
}
