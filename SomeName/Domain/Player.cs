using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;
using SomeName.Balance;
using SomeName.Domain;
using SomeName.Items.Impl;
using Newtonsoft.Json;

namespace SomeName.Domain
{
    // TODO : Сделать конвертер Player -> StatsInfo.
    public class Player : IAttacker, IAttackTarget
    {
        [JsonIgnore]
        public PlayerStatsCalculator PlayerStatsCalculator { get; set; }

        [JsonIgnore]
        public AttackManager AttackManager { get; set; }

        public Player()
        {
            PlayerStatsCalculator = new PlayerStatsCalculator();
            AttackManager = new AttackManager(this);
        }

        public int Level { get; set; }

        public long ExpForNextLevel { get; set; }

        public long Exp { get; set; }

        public long Gold { get; set; }

        public long Health { get; set; }

        public bool IsDead { get; set; }

        public EquippedItems EquippedItems { get; set; }

        public List<Item> Inventory { get; set; }

        public long GetDamage()
            => PlayerStatsCalculator.CalculateDamage(this);

        public long GetDefence()
            => PlayerStatsCalculator.CalculateDefence(this);

        public double GetDefenceKoef()
            => PlayerStatsCalculator.CalculateDefenceKoef(this);

        public long GetMaxHealth()
            => PlayerStatsCalculator.CalculateMaxHealth(this);

        public int GetPower()
            => PlayerStatsCalculator.CalculatePower(this);

        public int GetVitality()
            => PlayerStatsCalculator.CalculateVitality(this);

        public double GetCritChance()
            => PlayerStatsCalculator.CalculateCritChance(this);

        public double GetCritDamage()
            => PlayerStatsCalculator.CalculateCritDamage(this);

        public void Respawn()
        {
            Health = GetMaxHealth();
            IsDead = false;
        }

        public void SellItem(ShopService shopService, Item item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                Gold += shopService.GetSellItemValue(item);
            }
        }

        // TODO : Перенести все методы заточки в более подходящее место.
        public bool EnchantWeapon(Weapon item, ScrollOfEnchantWeapon scrollOfEnchant)
        {
            if (Inventory.Remove(scrollOfEnchant))
                return item.TryEnchant(scrollOfEnchant);

            throw new InvalidOperationException($"{nameof(scrollOfEnchant)} не содержится в {nameof(Inventory)}");
        }

        public long Attack(IAttackTarget attackTarget)
            => AttackManager.Attack(attackTarget);

        // TODO : Решить, как можно сделать метод более расширяемым к добавлению новых типов предметов.
        public bool Equip(Item item)
        {
            switch (item)
            {
                case Weapon weapon:
                    if (EquippedItems.Weapon != null)
                        Inventory.Add(EquippedItems.Weapon);
                    Inventory.Remove(item);
                    EquippedItems.Weapon = weapon;
                    return true;

                case Chest chest:
                    if (EquippedItems.Armor != null)
                        Inventory.Add(EquippedItems.Armor);
                    Inventory.Remove(item);
                    EquippedItems.Armor = chest;
                    return true;

                case Gloves gloves:
                    if (EquippedItems.Gloves != null)
                        Inventory.Add(EquippedItems.Gloves);
                    Inventory.Remove(item);
                    EquippedItems.Gloves = gloves;
                    return true;
            }

            return false;
        }

        public void Unequip(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    if (EquippedItems.Weapon != null)
                    {
                        Inventory.Add(EquippedItems.Weapon);
                        EquippedItems.Weapon = null;
                    }
                    break;

                case ItemType.Chest:
                    if (EquippedItems.Armor != null)
                    {
                        Inventory.Add(EquippedItems.Armor);
                        EquippedItems.Armor = null;
                    }
                    break;

                case ItemType.Gloves:
                    if (EquippedItems.Gloves != null)
                    {
                        Inventory.Add(EquippedItems.Gloves);
                        EquippedItems.Gloves = null;
                    }
                    break;
            }
        }

        public void TakeDrop(Drop drop)
        {
            TakeExp(drop.Exp);
            Gold += drop.Gold;
            TakeItems(drop.Items);
        }

        public void TakeExp(long exp)
        {
            var totalExp = Exp + exp;
            while (totalExp >= ExpForNextLevel)
            {
                totalExp -= ExpForNextLevel;
                Level++;
                ExpForNextLevel = DropBalance.Standard.GetExp(Level);
            }
            Exp = totalExp;
        }

        public void TakeItem(Item item)
            => Inventory.Add(item);

        public void TakeItems(List<Item> items)
            => Inventory.AddRange(items);
    }
}
