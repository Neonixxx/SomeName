using SomeName.Items.Interfaces;
using SomeName.Items.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Impl
{
    public class SimpleChest : Chest
    {
        public SimpleChest()
        {
            Description = "Кожанный жилет";
            Image = ItemImages.SimpleArmor;
        }
    }
}
