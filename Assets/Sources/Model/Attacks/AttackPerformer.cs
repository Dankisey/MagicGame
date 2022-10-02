using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Model
{
    public class AttackPerformer : IAttackPerformer
    {
        private readonly HashSet<Attack> _availableAttacks;
        private Battle _battle;

        public AttackPerformer()
        {
            _availableAttacks = new();
        }

        public void Perform(int attackID)
        {
            Attack attack = _availableAttacks.FirstOrDefault(attack => attack.ID == attackID);

            if (attack == null)
                throw new NullReferenceException(nameof(attackID));
            
            _battle.SendPlayerAttack(attack);
        }

        public void InitBattle(Battle battle)
        {
            _battle = battle;
        }

        public void AddAttack<T>(T attack) where T : Attack
        {
            _availableAttacks.Add(attack);
        }
    }
}