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
        private static readonly Dictionary<ItemBonusesEnum, Func<ItemBonusesBuilder, double, ItemBonusesBuilder>> _itemBonusesCalculators
            = new Dictionary < ItemBonusesEnum, Func<ItemBonusesBuilder, double, ItemBonusesBuilder>>
            {
                { ItemBonusesEnum.Power, (builder, damageValueKoef) => builder.CalculatePower(damageValueKoef) },
                { ItemBonusesEnum.Vitality, (builder, damageValueKoef) => builder.CalculateVitality(damageValueKoef) },
                { ItemBonusesEnum.CritChance, (builder, damageValueKoef) => builder.CalculateCritChance(damageValueKoef) },
                { ItemBonusesEnum.CritDamage, (builder, damageValueKoef) => builder.CalculateCritDamage(damageValueKoef) }
            };

        public ItemBonuses Build(ItemStatsBalance itemStatsBalance, int level, double additionalKoef)
        {
            var minBonusesCount = itemStatsBalance.GetMinItemBonusesCount(level);
            var maxBonusesCount = itemStatsBalance.GetMaxItemBonusesCount(level);
            var bonusesCount = Dice.GetRange(minBonusesCount, maxBonusesCount);

            var itemBonusesBuilder = new ItemBonusesBuilder(itemStatsBalance, level);
            foreach (var itemBonuseEnum in itemStatsBalance.PossibleItemBonuses.TakeRandom(bonusesCount))
                _itemBonusesCalculators[itemBonuseEnum].Invoke(itemBonusesBuilder, ItemFactory.RollItemDamageKoef(additionalKoef));

            return itemBonusesBuilder.Build();
        }
    }
}
