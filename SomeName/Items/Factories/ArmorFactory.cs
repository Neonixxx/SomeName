using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Factories
{
    public abstract class ArmorFactory : ItemFactory
    {
        protected const double ArmorGoldValueKoef = 0.3;

        protected long GetArmorGoldValue(int level, double damageValueKoef)
            => Convert.ToInt64(GetBaseArmorGoldValue(level) * damageValueKoef);

        protected long GetBaseArmorGoldValue(int level)
            => Convert.ToInt64(GetBaseItemGoldValue(level) * ArmorGoldValueKoef);
    }
}
