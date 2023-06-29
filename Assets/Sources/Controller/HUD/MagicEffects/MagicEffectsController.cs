using System.Collections.Generic;
using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class MagicEffectsController : MonoBehaviour
    {
        [SerializeField] private List<MagicEffectButton> _buttons;

        private MagicCombiner _combiner;

        public void Init(MagicCombiner combiner)
        {
            _combiner = combiner;
        }

        private void OnEnable()
        {
            foreach (var button in _buttons)
                button.Clicked += OnMagicEffectButtonClick;
        }

        private void OnMagicEffectButtonClick(MagicEffect effect)
        {
            _combiner.TryAddEffect(effect);
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
                button.Clicked -= OnMagicEffectButtonClick;
        }
    }
}