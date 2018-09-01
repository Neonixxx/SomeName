using SomeName.Items.Interfaces;

namespace SomeName.Domain
{
    public interface ICanBeEnchanted : IEquippment
    {
        long BaseStatToEnchant { get; set; }

        long StatToEnchant { get; set; }

        int EnchantmentLevel { get; set; }
    }
}
