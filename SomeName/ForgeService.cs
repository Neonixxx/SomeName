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
    public class ForgeService
    {
        public Player Player { get; set; }

        public EnchantManager EnchantManager { get; set; } = EnchantManager.Standard;

        public ForgeService(Player player)
            => Player = player;

        public bool EnchantItem(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
        {
            if (!CanBeEnchantedWith(itemToEnchant, scrollOfEnchant))
                throw new ArgumentException($"Предмет типа {itemToEnchant.GetType()} нельзя улучшить с помощью {scrollOfEnchant.GetType()}");

            if (!Player.Inventory.Contains(scrollOfEnchant))
                throw new InvalidOperationException($"{nameof(scrollOfEnchant)} не содержится в {nameof(Player.Inventory)}");

            var isItemInInventory = Player.Inventory.Contains(itemToEnchant);
            var isItemEquipped = Player.EquippedItems.Contains(itemToEnchant);

            if (!isItemInInventory && !isItemEquipped)
                throw new InvalidOperationException($"{nameof(itemToEnchant)} не содержится в {nameof(Player.Inventory)} и {nameof(Player.EquippedItems)}");

            Player.Inventory.Remove(scrollOfEnchant);
            var enchantResult = EnchantManager.TryEnchant(itemToEnchant, scrollOfEnchant);

            if (!enchantResult)
            {
                if (isItemInInventory)
                    Player.Inventory.Remove(itemToEnchant);
                else
                    Player.EquippedItems.Remove(itemToEnchant);
            }

            return enchantResult;
        }

        public bool CanBeEnchantedWith(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
        {
            if (scrollOfEnchant is ScrollOfEnchantWeapon && itemToEnchant is Weapon
                || scrollOfEnchant is ScrollOfEnchantArmor && itemToEnchant is Armor)
                return true;

            return false;
        }
    }
}
