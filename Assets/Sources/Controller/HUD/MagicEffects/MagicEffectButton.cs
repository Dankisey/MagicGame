using Game.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controller
{
    public sealed class MagicEffectButton : MonoBehaviour
    {
        private MagicEffect _magicEffect;
        private Button _button;

        public void Init(Button button, MagicEffect magicEffect)
        {
            _magicEffect = magicEffect;
            _button = button;
            _button.onClick.AddListener(OnClick);
        }

        public event Action<MagicEffect> Clicked;

        private void OnClick()
        {
            Clicked?.Invoke(_magicEffect);
        }

        private void OnDisable()
        {
            _button?.onClick.RemoveListener(OnClick);
        }
    }
}