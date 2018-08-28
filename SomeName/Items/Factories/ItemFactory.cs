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
        public abstract Item Build(int level, double additionalKoef = 1.0);

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
            => PlayerStatsBalance.GetExp(level);

        /// <summary>
        /// Получить случано сгенерированное значение коэффицента урона предмета.
        /// </summary>
        /// <returns></returns>
        protected double RollItemDamageKoef(double additionalKoef = 1.0)
            => GetItemDamageKoef(Dice.Roll) * additionalKoef;

        /// <summary>
        /// Получить значение коэффицента урона предмета по значению броска кубика.
        /// </summary>
        /// <param name="diceValue">Значение броска кубика (0..1]</param>
        /// <returns></returns>
        protected double GetItemDamageKoef(double diceValue)
            => Math.Pow(diceValue, -0.35);
    }
}
