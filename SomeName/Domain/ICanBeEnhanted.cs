using SomeName.Items.Interfaces;

namespace SomeName.Domain
{
    public interface ICanBeEnchanted<TScrollOfEnchant> : IEquippment
        where TScrollOfEnchant : ScrollOfEnchant
    {
        long BaseStatToEnchant { get; set; }

        long StatToEnchant { get; set; }

        int EnchantmentLevel { get; set; }
    }
}
