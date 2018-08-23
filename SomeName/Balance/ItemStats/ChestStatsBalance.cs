using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Balance.ItemStats
{
    public class ChestStatsBalance : ArmorStatsBalance
    {
        protected override double DefenceKoef => 1.0;

        protected override double PowerKoef => 1.0;

        protected override double VitalityKoef => 1.0;
    }
}
