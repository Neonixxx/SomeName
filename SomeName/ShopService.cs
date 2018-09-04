﻿using SomeName.Domain;
using SomeName.Items.Interfaces;
using SomeName.Items.ItemFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeName
{
    public class ShopService
    {
        public Player Player { get; set; }

        public Tuple<ItemFactory, int>[] SellingItemFactories => new Tuple<ItemFactory, int>[]
        {
            Tuple.Create<ItemFactory, int>(new SimpleSwordFactory(), 100),
            Tuple.Create<ItemFactory, int>(new SimpleChestFactory(), 100),
            Tuple.Create<ItemFactory, int>(new SimpleGlovesFactory(), 100),
            Tuple.Create<ItemFactory, int>(new ScrollOfEnchantWeaponFactory(), 30),
            Tuple.Create<ItemFactory, int>(new ScrollOfEnchantArmorFactory(), 30)
        };

        private List<IItem> _sellingItems = new List<IItem>();

        public List<IItem> GetSellingItems()
            => _sellingItems;

        public ShopService(Player player)
            => Player = player;

        // TODO : Сделать рандомную генерацию списка продаваемых предметов.
        public void RefreshSellingItems(int level)
        {
            _sellingItems.Clear();
            foreach (var itemFactory in SellingItemFactories)
                for (int i = 0; i < 2; i++)
                    _sellingItems.Add(itemFactory.Item1.Build(level));
        }

        public void Buy(IItem item)
        {
            if (!CanBuy(item))
                throw new ArgumentException("Ошибка при покупке предмета.");

            Player.Gold -= item.GoldValue;
            _sellingItems.Remove(item);
            Player.TakeItem(item);
        }

        public bool CanBuy(IItem item)
        {
            if (_sellingItems.Contains(item) && Player.Gold >= item.GoldValue)
                return true;

            return false;
        }
    }
}
