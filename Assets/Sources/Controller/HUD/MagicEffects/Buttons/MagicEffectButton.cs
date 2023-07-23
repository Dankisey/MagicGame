using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using System;

namespace Game.Controller
{
    public abstract class MagicEffectButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private bool _initialized = false;

        protected MagicEffect MagicEffect;

        public event Action<MagicEffect> Clicked;

        protected abstract void SetEffect();

        private void Init()
        {
            SetEffect();
            _initialized = true;
        }

        private void OnClick()
        {
            Clicked?.Invoke(MagicEffect);
        }

        private void OnEnable()
        {
            if (_initialized == false)           
                Init();
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}