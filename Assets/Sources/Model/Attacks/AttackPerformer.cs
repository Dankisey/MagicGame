using Game.Controller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Model
{
    public class AttackPerformer
    {
        private readonly MagicCombiner _magicCombiner;
        private readonly Stamina _stamina;
        private readonly Mana _mana;
        private Battle _battle;

        //public AttackPerformer(Mana mana, Stamina stamina)
        //{
        //    _magicCombiner = new ();
        //    _magicCombiner.AttackCompleted += OnMagicAttackCompleted;
        //    _stamina = stamina;
        //    _mana = mana;
        //}

        public event Action<int> AttackAdded;

        public void InitBattle(Battle battle)
        {
            _battle = battle;           
        }

        public void OnMagicAttackCompleted(Attack attack)
        {
            _battle.SendPlayerAttack(attack);
        }

        private bool TryAttack(Attack attack)
        {
            return true;
        }
    }
}