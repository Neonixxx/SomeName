using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName.Items.Interfaces
{
    public interface IItem
    {
        int Level { get; set; }

        long GoldValue { get; set; }

        string Description { get; set; }

        Image Image { get; set; }
    }
}
