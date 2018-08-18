using SomeName.Monsters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Monsters.Impl;
using SomeName.Forms;
using SomeName.Domain;

namespace SomeName
{
    public class FarmController
    {
        public Player Player { get; set; }

        public Farm_Form FarmForm { get; set; }

        private Monster _monster { get; set; }

        public FarmController(Player player, Farm_Form farm_form)
        {
            Player = player;
            FarmForm = farm_form;
        }

        public void Attack()
        {
            var damage = Player.GetDamage();
            var dealtDamage = _monster.DealDamage(damage);
            if (_monster.IsDead)
            {
                var drop = _monster.GetDrop();
                Player.TakeDrop(drop);
                Player.Health = Player.GetMaxHealth();
                FarmForm.UpdateDropInfo(new DropInfo(_monster, drop));
                NewMonster();
            }

            Update();
        }

        public void Update()
        {
            FarmForm.UpdatePlayerLevel(Player.Level);
            FarmForm.UpdatePlayerExp(Player.Exp, Player.ExpForNextLevel);
            FarmForm.UpdatePlayerGold(Player.Gold);
            FarmForm.UpdatePlayerHealth(Player.Health, Player.GetMaxHealth());

            FarmForm.UpdateMonsterHealth(_monster.Health, _monster.MaxHealth);
            FarmForm.MonsterInfo(_monster.Description);
        }

        public void NewMonster()
        {
            _monster = MonsterFacture.GetRandomMonster(Player.Level);
        }

        public void StartFarm()
        {
            Player.Health = Player.GetMaxHealth();
            NewMonster();
            Update();
        }
    }
}
