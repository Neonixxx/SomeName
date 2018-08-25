using SomeName.Domain;
using SomeName.Items.Bonuses;
using SomeName.Items.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Weapon : Equippment
    {
        public long BaseDamage { get; set; }

        public long Damage { get; set; }

        public int EnchantmentLevel { get; set; }

        public WeaponBonuses Bonuses { get; set; } = new WeaponBonuses();

        public long BaseGoldValue { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (EnchantmentLevel > 0)
                result.Append($"+{EnchantmentLevel} ");
            result.Append($"{base.ToString()}{NewLine}Damage: {Damage}");
            var bonusesString = Bonuses.ToString();
            if (bonusesString != string.Empty)
                result.Append($"{NewLine}{bonusesString}");
            return result.ToString();
        }

        protected readonly double BaseEnchantmentValue = 0.08;

        protected readonly double EnchantmentValueEnc = 0.02;

        protected readonly double EnchantmentChanceKoef = 0.92;

        // TODO : Надо бы сделать все методы заточки более удобным способом.
        public bool TryEnchant(ScrollOfEnchantWeapon scrollOfEnchant)
        {
            var enchantResult = Dice.TryGetChance(GetEnchantChance(scrollOfEnchant));
            if (enchantResult)
            {
                SetEnchantmentLevel(EnchantmentLevel + 1);
                return true;
            }
            else
                return false;
        }

        public double GetEnchantChance(ScrollOfEnchantWeapon scrollOfEnchant)
        {
            var baseEnchantChance = Convert.ToDouble(scrollOfEnchant.Value) / BaseDamage;
            return baseEnchantChance * Math.Pow(EnchantmentChanceKoef, EnchantmentLevel);
        }

        public void SetEnchantmentLevel(int newEnchantmentLevel)
        {
            EnchantmentLevel = newEnchantmentLevel;
            CalculateDamage();
        }

        protected void CalculateDamage()
        {
            var enchantmentDamageKoef = 1 + EnchantmentLevel * (BaseEnchantmentValue + EnchantmentValueEnc / 2 * (1 + EnchantmentLevel));
            Damage = Convert.ToInt64(BaseDamage * enchantmentDamageKoef);
        }
    }
}
