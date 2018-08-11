using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Item
    {
        public int Level { get; set; }

        public long GoldValue { get; set; }

        public double DamageValueKoef { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }

        public override string ToString()
            => $"Level: {Level}" +
                $"{NewLine}{Description}";
    }
}
