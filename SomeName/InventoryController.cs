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

        public ShopManager ShopManager { get; set; }

        public ForgeService ForgeService { get; set; }

        public ShopService ShopService { get; set; }

        public void Start()
        {
            ShopService.RefreshSellingItems(Player.Level);
            InventoryForm.Start(Player.Inventory.Count);
        }

        public void Update()
        {
            InventoryForm.UpdateInventory(Player.Inventory);
            InventoryForm.UpdateEquippedItems(Player.EquippedItems);
            InventoryForm.UpdateStatsInfo(GetStatsInfo());
            InventoryForm.UpdateGold(Player.Gold);
            InventoryForm.UpdateSellingItems(ShopService.GetSellingItems());
        }

        // TODO : Обобщить для интерфейса ICanBeEnchanted<TScrollOfEnchant>.
        public bool EnchantWeapon(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
            => ForgeService.EnchantItem(itemToEnchant, scrollOfEnchant);

        public double GetItemEnchantChance(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
            => ForgeService.EnchantManager.GetEnchantChance(itemToEnchant, scrollOfEnchant);

        public bool CanBeEnchantedWith(ICanBeEnchanted itemToEnchant, ScrollOfEnchant scrollOfEnchant)
            => ForgeService.CanBeEnchantedWith(itemToEnchant, scrollOfEnchant);

        public void SellItem(int itemIndex)
            => Player.SellItem(ShopManager, Player.Inventory[itemIndex]);

        public void EquipItem(int itemIndex)
            => Player.Equip(Player.Inventory[itemIndex]);

        public void UnequipItem(ItemType itemType)
            => Player.Unequip(itemType);

        public bool CanBuyItem(IItem item)
            => ShopService.CanBuy(item);

        public void BuyItem(IItem item)
            => ShopService.Buy(item);

        public long GetSellGoldValueOfItem(int itemIndex)
            => ShopManager.GetSellItemValue(Player.Inventory[itemIndex]);

        public IItem GetItem(int itemIndex)
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
                Accuracy = Player.GetAccuracy(),
                Evasion = Player.GetEvasion(),
                Defence = Player.GetDefence(),
                DefenceKoef = Player.GetDefenceKoef(),
                CritChance = Player.GetCritChance(),
                CritDamage = Player.GetCritDamage()
            };
        }
    }
}
