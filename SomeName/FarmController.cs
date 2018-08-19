﻿using SomeName.Monsters.Interfaces;
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

namespace SomeName
{
    public class FarmController : IUpdater
    {
        public Player Player { get; set; }

        public Farm_Form FarmForm { get; set; }

        private Monster _monster { get; set; }

        public FarmController(Player player, Farm_Form farm_form)
        {
            Player = player;
            FarmForm = farm_form;
        }

        // TODO : сделать какую нибудь информацию о смерти игрока на форме.
        public void Attack()
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
                StartMonsterAttaking();
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

        // TODO : сделать обновление здоровья игрока после атаки монстра.
        private void StartMonsterAttaking()
        {
            Task.Factory.StartNew(() => _monster.StartAttacking(Player));
        }

        public void StartFarm()
        {
            Player.Respawn();
            NewMonster();
            Update();
            StartMonsterAttaking();
        }

        public void StopFarm()
        {
            _monster.StopAttacking();
        }
    }
}
