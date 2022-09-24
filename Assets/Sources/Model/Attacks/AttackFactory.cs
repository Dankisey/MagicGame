using System.Collections.Generic;

namespace Game.Model
{
    public class AttackFactory
    {
        private readonly List<Attack> _availableAttacks;

        public AttackFactory()
        {
            _availableAttacks = new();
        }

        public IReadOnlyCollection<Attack> AvailableAttacks => _availableAttacks;

        public void AddAttack<T>(T attack) where T : Attack
        {
            _availableAttacks.Add(attack);
        }

        public void Perform(IDamageTaker damageTaker)
        {
            _availableAttacks[0].Perform(damageTaker);
        }
    }
}