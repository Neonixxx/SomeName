﻿namespace SomeName.Domain
{
    public interface ICanBeEnchanted : IHaveMainStat
    {
        int EnchantmentLevel { get; set; }
    }
}
