﻿using SomeName.Items.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class ShopManager
    {
        public long GetSellItemValue(IItem item)
            => Convert.ToInt64(item.GoldValue.Value * 0.3);
    }
}
