namespace SomeName.Domain
{
    public interface IAttackTarget : ICanDie
    {
        long Health { get; set; }

        double GetDefenceKoef();

        int GetEvasion();
    }
}
