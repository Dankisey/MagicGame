using UnityEngine.UI;
using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class MagicEffectsController : MonoBehaviour
    {
        [SerializeField] private MagicEffectButton[] _buttons;
        [SerializeField] private Button _endAttackButton;

        private MagicCombiner _combiner;

        public void Init(MagicCombiner combiner)
        {
            _combiner = combiner;
        }

        private void OnEnable()
        {
            foreach (var button in _buttons)
                button.Clicked += OnMagicEffectButtonClick;

            _endAttackButton.onClick.AddListener(OnAttackEnd);
        }

        private void OnMagicEffectButtonClick(MagicEffect effect)
        {
            _combiner.TryAddEffect(effect);
        }

        private void OnAttackEnd()
        {
            _combiner.EndAttack();
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
                button.Clicked -= OnMagicEffectButtonClick;

            _endAttackButton.onClick.RemoveListener(OnAttackEnd);
        }
    }
}