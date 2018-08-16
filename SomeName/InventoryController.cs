using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Domain;
using SomeName.Forms;
using SomeName.Items.Interfaces;

namespace SomeName
{
    public class InventoryController
    {
        public Inventory_Form InventoryForm { get; set; }

        public Player Player { get; set; }

        public void Start()
        {
            InventoryForm.Initialize(Player.Inventory.Count);
            Update();
        }

        public void Update()
        {
            InventoryForm.UpdateInventory(Player.Inventory);
            InventoryForm.UpdateEquippedItems(Player.EquippedItems);
            InventoryForm.UpdateStatsInfo(GetStatsInfo());
        }

        public void EquipItem(int itemNumber)
        {
            if (Player.Equip(Player.Inventory[itemNumber]))
                Update();
        }

        public void UnequipItem(ItemType itemType)
        {
            Player.Unequip(itemType);
            Update();
        }

        private StatsInfo GetStatsInfo()
        {
            return new StatsInfo
            {
                Level = Player.Level,
                Power = Player.GetPower(),
                Damage = Player.GetDamage(),
                CritChance = Player.GetCritChance(),
                CritDamage = Player.GetCritDamage()
            };
        }
    }
}
