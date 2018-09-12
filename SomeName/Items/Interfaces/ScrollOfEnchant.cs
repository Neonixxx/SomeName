using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class ScrollOfEnchant : Item
    {
        public long Value { get; set; }

        public override void UpdateGoldValueKoef()
            => GoldValue.Koef = Value;

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"{NewLine}Value: {Value}";
        }
    }
}
