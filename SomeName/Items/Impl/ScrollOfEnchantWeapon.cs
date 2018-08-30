using SomeName.Items.Interfaces;
using SomeName.Items.Resources;

namespace SomeName.Items.Impl
{
    public class ScrollOfEnchantWeapon : ScrollOfEnchant
    {
        public ScrollOfEnchantWeapon()
        {
            Description = "Свиток заточки оружия";
            Image = ItemImages.ScrollOfEnchantWeapon;
        }
    }
}
