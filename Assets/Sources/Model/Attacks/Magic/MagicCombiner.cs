﻿using System.Collections.Generic;
using System;

namespace Game.Model
{
    public sealed class MagicCombiner
    {
        private DamageElements[] _combo;
        private MagicEffect[] _effects;
        private bool _spellIsInProgress;
        private int _currentPosition;

        public MagicCombiner()
        {
            _combo = new DamageElements[Config.Magic.MaxEffectsInSpell];
            _effects = new MagicEffect[Config.Magic.MaxEffectsInSpell];
            _spellIsInProgress = true;
            _currentPosition = 0;
        }

        public event Action<IReadOnlyCollection<DamageElements>> ComboChanged;
        public event Action<Attack> AttackCompleted;

        public void EndAttack()
        {
            if (TryGetAttack(out Attack attack))
            {
                AttackCompleted?.Invoke(attack);
                PrepareNewSpell();
            }
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

            if (_combo.Length == 0)
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
            ResetSpell();         
            ComboChanged?.Invoke(_combo);
        }

        private void ResetSpell()
        {
            ResetEffects();
            ResetCombo();
            _spellIsInProgress = true;
        }

        private void ResetEffects()
        {
            for (int i = 0; i < _effects.Length; i++)
                _effects[i] = new None();
        }

        private void ResetCombo()
        {
            for (int i = 0; i < _combo.Length; i++)
                _combo[i] = DamageElements.None;
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
            _effects[_currentPosition] = effect;
            AddElementToCombo(effect.Element);         
            _currentPosition++;
        }

        private void AddElementToCombo(DamageElements element)
        {
            _combo[_currentPosition] = element;
            ComboChanged?.Invoke(_combo);
        }

        private bool IsTriplet()
        {
            for (int i = 1; i < Config.Magic.ElementsForTriplet; i++)
            {
                if (_combo[i] != _combo[i - 1] || _combo[i] == DamageElements.None)
                    return false;
            }

            return true;
        }
    }
}