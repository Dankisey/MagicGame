using System.Collections.Generic;

namespace Game.Model
{
    public class DamageBuffsContainer
    {
        private List<DamageMultiplier> _multipliersList;
        private Level _level;

        public DamageBuffsContainer(Level characterLevel)
        {
            _multipliersList = new();
            _level = characterLevel;
        }

        public IReadOnlyCollection<DamageMultiplier> DamageMultipliers => _multipliersList;

        public void AddMultiplier(DamageMultiplier multiplier)
        {
            _multipliersList.Add(multiplier);
        }

        public bool TryRemoveMultiplier(DamageMultiplier multiplier) 
        {
            if (_multipliersList.Contains(multiplier) == false)
                return false;

            return _multipliersList.Remove(multiplier);
        }

        public Attack GetBuffedAttack(Attack attack)
        {
            return attack.MultiplyDamages(_multipliersList).MultiplyAll(_level.Multiplier);
        }
    }
}