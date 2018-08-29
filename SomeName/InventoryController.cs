using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Domain;
using SomeName.Forms;
using SomeName.Items.Impl;
using SomeName.Items.Interfaces;

namespace SomeName
{
    public class InventoryController : ICanStart
    {
        public InventoryForm InventoryForm { get; set; }

        public Player Player { get; set; }

        public ShopService ShopService { get; set; }

        public void Start()
            => InventoryForm.Start(Player.Inventory.Count);

        public void Update()
        {
            InventoryForm.UpdateInventory(Player.Inventory);
            InventoryForm.UpdateEquippedItems(Player.EquippedItems);
            InventoryForm.UpdateStatsInfo(GetStatsInfo());
            InventoryForm.UpdateGold(Player.Gold);
        }

        public bool EnchantWeapon(Weapon weapon, ScrollOfEnchantWeapon scrollOfEnchantWeapon)
            => Player.EnchantWeapon(weapon, scrollOfEnchantWeapon);

        public void SellItem(int itemIndex)
            => Player.SellItem(ShopService, Player.Inventory[itemIndex]);

        public void EquipItem(int itemIndex)
            => Player.Equip(Player.Inventory[itemIndex]);

        public void UnequipItem(ItemType itemType)
            => Player.Unequip(itemType);

        public long GetGoldValueOfItem(int itemIndex)
            => ShopService.GetSellItemValue(Player.Inventory[itemIndex]);

        public Item GetItem(int itemIndex)
            => Player.Inventory[itemIndex];

        private StatsInfo GetStatsInfo()
        {
            return new StatsInfo
            {
                Level = Player.Level,
                Damage = Player.GetDamage(),
                MaxHealth = Player.GetMaxHealth(),
                Power = Player.GetPower(),
                Vitality = Player.GetVitality(),
                Defence = Player.GetDefence(),
                DefenceKoef = Player.GetDefenceKoef(),
                CritChance = Player.GetCritChance(),
                CritDamage = Player.GetCritDamage()
            };
        }
    }
}
