using System.Collections.Generic;
using System.Linq;

namespace Game.Model
{
    public class MagicCombiner
    {
        private MagicEffect[] _effects = new MagicEffect[0];
        private Spell _currentSpell;

        public void CreateSpell()
        {
            _currentSpell = new Spell();
        }

        public Spell GetSpell()
        {
            foreach (var effect in _effects)
                _currentSpell.AddEffect(effect);

            return _currentSpell;
        }

        public bool TryAddElement(Element element)
        {
            if (_effects.Length == Config.Magic.MaxEffectsInSpell)
                return false;

            if (CheckMatchingRules(element) == false)
                return false;

            AddElement(element);

            return true;
        }

        private bool CheckMatchingRules(Element elementToCheck)
        {
            bool isMatching = true;

            foreach (var element in _effects)
                isMatching &= element.CheckMatching(elementToCheck);

            return isMatching;
        }

        private void AddElement(Element element)
        {
            FirstTierEffect effect = element.GetEffect();
            _effects = GetEffectsCombo(effect);
        }

        private MagicEffect[] GetEffectsCombo(FirstTierEffect effect)
        {
            HashSet<MagicEffect> elements = new();

            foreach (var item in _effects)
            {
                MagicEffect[] currentEffects = item.Combine(effect, out AugmentedStatus status);

                for (int i = 0; i < currentEffects.Length; i++)
                    elements.Add(currentEffects[i]);

                _currentSpell.Augment((int)status);
            }

            return elements.ToArray();
        }
    }
}