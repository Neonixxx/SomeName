using SomeName.Items.Interfaces;
using SomeName.Items.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Impl
{
    // UNDONE : Реализовать возможность заточки оружия.
    public class ScrollOfEnchantWeapon : ScrollOfEnchant
    {
        public long Value { get; set; }

        public ScrollOfEnchantWeapon()
        {
            Description = "Свиток заточки оружия";
            Image = ItemImages.ScrollOfEnchantWeapon;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"{NewLine}Value: {Value}";
        }
    }
}
