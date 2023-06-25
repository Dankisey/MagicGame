using System.Collections.Generic;
using System;

namespace Game.Model
{
    public sealed class MagicCombiner
    {
        private MagicEffect[] _effects;
        private List<DamageElements> _combo;
        private bool _spellIsInProgress;

        public event Action<IReadOnlyCollection<DamageElements>> ComboChanged;
        public event Action<Attack> AttackCompleted;

        public void EndAttack()
        {
            if (TryGetAttack(out Attack attack))
                AttackCompleted?.Invoke(attack);
        }

        public bool TryAddEffect(MagicEffect effect)
        {
            if (_spellIsInProgress == false)
                PrepareNewSpell();

            if (_effects.Length == Config.Magic.MaxEffectsInSpell)
                return false;

            AddEffect(effect);

            return true;
        }

        private bool TryGetAttack(out Attack attack)
        {
            attack = new();

            if (_combo.Count == 0)
                return false;

            if (TryGetTriplet(out attack))
                return true;

            Spell spell = GetSpell();
            attack = spell.ToAttack();

            _spellIsInProgress = false;

            return true;
        }

        private void PrepareNewSpell()
        {
            _effects = new MagicEffect[0];
            _combo = new();
            _spellIsInProgress = true;
        }

        private Spell GetSpell()
        {
            return new Spell(_effects);
        }

        private bool TryGetTriplet(out Attack attack)
        {
            attack = new();

            if (IsTriplet())
            {
                attack = _effects[0].GetTriplet();

                return true;
            }

            return false;
        }

        private void AddEffect(MagicEffect effect)
        {
            MagicEffect[] effects = new MagicEffect[_effects.Length + 1];

            for (int i = 0; i < _effects.Length; i++)
                effects[i] = _effects[i];

            effects[^1] = effect; 
            _effects = effects;

            AddElementToCombo(effect.Element);         
        }

        private void AddElementToCombo(DamageElements element)
        {
            _combo.Add(element);
            ComboChanged?.Invoke(_combo);
        }

        private bool IsTriplet()
        {
            if (_combo.Count != Config.Magic.ElementsForTriplet)
                return false;

            for (int i = 1; i < Config.Magic.ElementsForTriplet; i++)
            {
                if (_combo[i] != _combo[i - 1])
                    return false;
            }

            return true;
        }
    }
}