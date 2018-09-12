using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Domain;

namespace SomeName.Items.Interfaces
{
    public interface IItem
    {
        int Level { get; set; }

        BaseKoefValue<long> GoldValue { get; set; }

        void UpdateGoldValueKoef();

        string Description { get; set; }

        Image Image { get; set; }
    }
}
