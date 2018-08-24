using SomeName.Difficulties;
using SomeName.Domain;
using SomeName.Items.Factories;
using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Balance
{
    public class DropService
    {
        public Tuple<ItemFactory, int>[] ItemFactories { get; }

        public static readonly double DropGoldValueKoef = 0.3;

        public static readonly double DropItemsValueKoef = 1 - DropGoldValueKoef;

        public DropService(params Tuple<ItemFactory, int>[] itemFactories)
            => ItemFactories = itemFactories;

        public Drop Build(int level, long value)
        {
            var goldValue = Convert.ToInt64(value * BattleDifficulty.GetCurrent().GoldMultiplier);
            var expValue = Convert.ToInt64(value * BattleDifficulty.GetCurrent().ExpMultiplier);
            var dropValue = Convert.ToInt64(value * BattleDifficulty.GetCurrent().DropMultiplier);

            return new Drop
            {
                Gold = CalculateGoldDrop(goldValue),
                Exp = expValue,
                Items = CalculateItemsDrop(level, dropValue)
            };
        }

        protected virtual long CalculateGoldDrop(long value)
        {
            var randomKoef = Dice.GetRange(0.5, 1.5);
            return Convert.ToInt64(value * DropGoldValueKoef * randomKoef);
        }

        protected virtual long CalculateExpDrop(long value)
            => value;

        protected virtual List<Item> CalculateItemsDrop(int level, long value)
        {
            var itemDropValue = value * DropItemsValueKoef / ItemFactories.Sum(s => s.Item2);
            var items = new List<Item>();
            foreach (var itemFactory in ItemFactories)
            {
                var currentItemDropValue = itemDropValue * itemFactory.Item2;
                var dropChance = currentItemDropValue / itemFactory.Item1.GetItemGoldValue(level);
                if (Dice.TryGetChance(dropChance))
                    items.Add(itemFactory.Item1.Build(level));
            }
            return items;
        }

        public static readonly DropService Standard = new DropService
        (
            Tuple.Create<ItemFactory, int>(new SimpleSwordFactory(), 100),
            Tuple.Create<ItemFactory, int>(new SimpleChestFactory(), 100),
            Tuple.Create<ItemFactory, int>(new ScrollOfEnchantWeaponFactory(), 30)
        );
    }
}
