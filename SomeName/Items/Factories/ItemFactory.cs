using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Items.Interfaces;

namespace SomeName.Items.Factories
{
    public abstract class ItemFactory
    {
        /// <summary>
        /// Получить ценность предмета, производимого этой фабрикой.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public abstract long GetItemGoldValue(int level);

        /// <summary>
        /// Получить предмет, производимый этой фабрикой.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public abstract Item Build(int level);

        protected int CalculateItemBonusesCount(int level)
            => Dice.GetRange(GetMinItemBonusesCount(level), GetMaxItemBonusesCount(level));

        // TODO : Сделать формулу.
        protected virtual int GetMinItemBonusesCount(int level)
            => 1;

        // TODO : Сделать формулу.
        protected virtual int GetMaxItemBonusesCount(int level)
            => 2;

        /// <summary>
        /// Получить стандартный коэффициент ценности предмета определенного уровня.
        /// </summary>
        /// <param name="level"></param>
        protected static long GetBaseItemGoldValue(int level)
            => DamageBalance.GetExp(level);
    }
}
