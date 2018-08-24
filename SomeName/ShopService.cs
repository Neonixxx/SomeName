using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class ShopService
    {
        public long SellItem(Item item)
            => Convert.ToInt64(item.GoldValue * 0.7);
    }
}
