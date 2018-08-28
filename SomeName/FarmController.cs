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
using System.Threading;
using System.ComponentModel;
using System.Activities.Statements;
using System.Windows.Forms;

namespace SomeName
{
    public class FarmController : IUpdater, ICanStart
    {
        public Player Player { get; set; }

        public FarmForm FarmForm { get; set; }

        private Monster _monster { get; set; }

        private object _syncRoot { get; } = new object();

        public FarmController(Player player, FarmForm farm_form)
        {
            Player = player;
            FarmForm = farm_form;
        }

        // TODO : сделать какую нибудь информацию о смерти игрока на форме.
        public void Attack()
        {
            lock (_syncRoot)
            {
                if (Player.IsDead)
                    return;

                var damage = Player.GetDamage();
                var dealtDamage = _monster.TakeDamage(damage);
                if (_monster.IsDead)
                {
                    var drop = _monster.GetDrop();
                    Player.TakeDrop(drop);
                    Player.Health = Player.GetMaxHealth();
                    FarmForm.UpdateDropInfo(new DropInfo(_monster, drop));
                    NewMonster();
                }
            }
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

        private void NewMonster()
        {
            _monster = MonsterFactory.GetRandomMonster(Player.Level);
            StartAttackingByMonster();
        }

        private void StartAttackingByMonster()
            => Task.Factory.StartNew(() => _monster.StartAttacking(Player, _syncRoot));

        public void Start()
        {
            Player.Respawn();
            NewMonster();
            FarmForm.Start();
        }

        public void Stop()
        {
            _monster.StopAttacking();
        }
    }
}
