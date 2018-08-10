using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;

namespace SomeName.Balance
{
    public static class DropBalance
    {
        // TODO : реализовать расчет выпавших вещей.
        /// <summary>
        /// Не реализовано (заглушка).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Drop CalculateDrop(long value)
        {
            return new Drop()
            {
                Gold = value,
                Exp = value,
                Items = new List<Item>()
            };
        }
    }
}
