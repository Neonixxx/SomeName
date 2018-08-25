using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SomeName.Domain;
using static System.Environment;

namespace SomeName.Items.Interfaces
{
    public abstract class Item
    {
        public int Level { get; set; }

        public long GoldValue { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public Image Image { get; set; }

        public override string ToString()
            => $"{Description}" +
                $"{NewLine}Level: {Level}";
    }
}
