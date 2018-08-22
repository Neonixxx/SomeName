using SomeName.Items.Interfaces;
using SomeName.Items.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Impl
{
    public class SimpleArmor : Armor
    {
        public SimpleArmor()
        {
            Description = "Кожанный жилет";
            Image = ItemImages.SimpleArmor;
        }
    }
}
