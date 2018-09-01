using SomeName.Domain;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class EnchantManager
    {
        protected static readonly double BaseEnchantmentValue = 0.08;

        protected static readonly double EnchantmentValueEnc = 0.02;

        protected static readonly double EnchantmentChanceKoef = 0.9;


        public bool TryEnchant(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
        {
            var enchantResult = Dice.TryGetChance(GetEnchantChance(itemToEnchant, scrollOfEnchant));
            if (enchantResult)
            {
                SetEnchantmentLevel(itemToEnchant, itemToEnchant.EnchantmentLevel + 1);
                return true;
            }
            else
                return false;
        }

        public double GetEnchantChance(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
        {
            var baseEnchantChance = Convert.ToDouble(scrollOfEnchant.Value) / itemToEnchant.BaseStatToEnchant;
            var enchantChance = baseEnchantChance * Math.Pow(EnchantmentChanceKoef, itemToEnchant.EnchantmentLevel);
            if (enchantChance > 1.0)
                enchantChance = 1.0;
            return enchantChance;
        }

        public void SetEnchantmentLevel(ICanBeEnchanted itemToEnchant, int newEnchantmentLevel)
        {
            itemToEnchant.EnchantmentLevel = newEnchantmentLevel;
            CalculateDamage(itemToEnchant);
        }

        protected void CalculateDamage(ICanBeEnchanted itemToEnchant)
        {
            var enchantmentDamageKoef = 1 + itemToEnchant.EnchantmentLevel * (BaseEnchantmentValue + EnchantmentValueEnc / 2 * (1 + itemToEnchant.EnchantmentLevel));
            itemToEnchant.StatToEnchant = Convert.ToInt64(itemToEnchant.BaseStatToEnchant * enchantmentDamageKoef);
        }

        public static readonly EnchantManager Standard = new EnchantManager();
    }
}
