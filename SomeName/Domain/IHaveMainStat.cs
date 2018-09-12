using SomeName.Items.Interfaces;

namespace SomeName.Domain
{
    public interface IHaveMainStat : IEquippment
    {
        MainStat<long> MainStat { get; set; }
    }
}
