﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;
using static System.Environment;

namespace SomeName.Domain
{
    public class Drop
    {
        public long Gold { get; set; }

        public long Exp { get; set; }

        public List<Item> Items { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder($"Золото: {Gold}" +
                $"{NewLine}Опыт: {Exp}");

            if (Items.Any())
                result.Append($"{NewLine}Предметы: ");

            foreach (var item in Items)
                result.Append($"{NewLine}{item.Description} Level {item.Level}");

            return result.ToString();
        }
    }
}
