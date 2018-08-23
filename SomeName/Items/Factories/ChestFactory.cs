﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Factories
{
    public abstract class ChestFactory : ItemFactory
    {
        protected const double ChestGoldValueKoef = 0.3;

        protected long GetChestGoldValue(int level, double damageValueKoef)
            => Convert.ToInt64(GetBaseChestGoldValue(level) * damageValueKoef);

        protected long GetBaseChestGoldValue(int level)
            => Convert.ToInt64(GetBaseItemGoldValue(level) * ChestGoldValueKoef);
    }
}
