﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Domain;
using SomeName.Forms;
using SomeName.Items.Interfaces;

namespace SomeName
{
    public class InventoryController : ICanStart
    {
        public Inventory_Form InventoryForm { get; set; }

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

        public void SellItem(int itemNumber)
            => Player.SellItem(ShopService, Player.Inventory[itemNumber]);

        public void EquipItem(int itemNumber)
            => Player.Equip(Player.Inventory[itemNumber]);

        public void UnequipItem(ItemType itemType)
            => Player.Unequip(itemType);

        public long GetGoldValueOfItem(int itemIndex)
            => ShopService.GetSellItemValue(Player.Inventory[itemIndex]);

        private StatsInfo GetStatsInfo()
        {
            return new StatsInfo
            {
                Level = Player.Level,
                Damage = Player.GetDamageWithoutCrit(),
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
