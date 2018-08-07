using SomeName.Monsters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
        }

        public void Update()
        {
            _farmForm.Level = _player.Level;
            _farmForm.MaxExp = Balance.GetExp(_player.Level);
            _farmForm.Exp = _player.Exp;
            _farmForm.Gold = _player.Gold;
        }
    }
}
