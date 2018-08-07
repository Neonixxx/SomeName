using SomeName.Monsters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomeName.Balance;
using SomeName.Monsters.Impl;

namespace SomeName
{
    public class FarmController
    {
        private Player _player { get; set; }

        private Monster _monster { get; set; }

        private Farm_Form _farmForm { get; set; }

        public FarmController(Player player, Farm_Form farm_form)
        {
            _player = player;
            _farmForm = farm_form;
        }

        public void Attack()
        {
            var damage = _player.GetDamage();
            var dealtDamage = _monster.DealDamage(damage);
            if (_monster.IsDead)
            {
                _player.TakeDrop(_monster.GetDrop());
                NewMonster();
            }

            Update();
        }

        public void Update()
        {
            _farmForm.Level = _player.Level;
            _farmForm.UpdatePlayerExp(_player.Exp, _player.ExpForNextLevel);
            _farmForm.Gold = _player.Gold;

            _farmForm.UpdateMonsterHealth(_monster.Health, _monster.MaxHealth);
            _farmForm.MonsterInfo = _monster.Description;
        }

        public void NewMonster()
        {
            _monster = MonsterFacture.GetRandomMonster(_player.Level);
        }

        public void StartFarm()
        {
            NewMonster();
            Update();
        }
    }
}
