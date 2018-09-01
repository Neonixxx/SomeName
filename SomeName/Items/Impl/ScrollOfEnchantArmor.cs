using SomeName.Items.Interfaces;
using SomeName.Items.Resources;

namespace SomeName.Items.Impl
{
    public class ScrollOfEnchantArmor : ScrollOfEnchant
    {
        public ScrollOfEnchantArmor()
        {
            Description = "Свиток заточки брони";
            Image = ItemImages.ScrollOfEnchantArmor;
        }
    }
}
