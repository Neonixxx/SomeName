using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Items.Interfaces;
using SomeName.Balance;
using SomeName.Domain;

namespace SomeName.Domain
{
    // TODO : Сделать конвертер Player -> StatsInfo.
    public class Player : IAttackTarget
    {
        public Player() { }

        public int Level { get; set; }

        public long ExpForNextLevel { get; set; }

        public long Exp { get; set; }

        public long Gold { get; set; }

        public long Health { get; set; }

        public bool IsDead { get; private set; }

        public EquippedItems EquippedItems { get; set; }

        public List<Item> Inventory { get; set; }

        public long GetDamage()
            => DamageBalance.CalculateDamage(this);

        public long GetMaxHealth()
            => DamageBalance.CalculateMaxHealth(this);

        public int GetPower()
            => DamageBalance.CalculatePower(this);

        public int GetVitality()
            => DamageBalance.CalculateVitality(this);

        public double GetCritChance()
            => DamageBalance.CalculateCritChance(this);

        public double GetCritDamage()
            => DamageBalance.CalculateCritDamage(this);

        public long TakeDamage(long damage)
        {
            var dealtDamage = GetTakenDamage(damage);
            Health -= dealtDamage;
            if (Health == 0)
                IsDead = true;
            return dealtDamage;
        }

        // TODO : Сделать расчет получаемого урона с учетом защиты.
        public long GetTakenDamage(long damage)
        {
            return Health - damage >= 0
                ? damage
                : Health;
        }

        public void Respawn()
        {
            Health = GetMaxHealth();
            IsDead = false;
        }


        public bool Equip(Item item)
        {
            if (item is Weapon weapon)
            {
                if (EquippedItems.Weapon != null)
                    Inventory.Add(EquippedItems.Weapon);
                Inventory.Remove(item);
                EquippedItems.Weapon = weapon;
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
                ExpForNextLevel = DamageBalance.GetExp(Level);
            }
            Exp = totalExp;
        }

        public void TakeItem(Item item)
            => Inventory.Add(item);

        public void TakeItems(List<Item> items)
            => Inventory.AddRange(items);
    }
}
