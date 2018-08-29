using System;

namespace SomeName.Items.Bonuses
{
    [Flags]
    public enum ItemBonusesEnum
    {
        Power = 0x1,

        Vitality = 0x2,

        CritChance = 0x4,

        CritDamage = 0x8
    }
}
