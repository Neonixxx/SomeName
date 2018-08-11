using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Forms;

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
        }
    }
}
