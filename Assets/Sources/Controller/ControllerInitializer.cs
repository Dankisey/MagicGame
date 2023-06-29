using System.Collections.Generic;
using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class ControllerInitializer : MonoBehaviour
    {
        [SerializeField] private MagicEffectsController _magicEffectsController;
        [SerializeField] private List<ButtonInitializer> _buttonInitializers;

        private MagicCombiner _magicCombiner;

        public void Init(MagicCombiner magicCombiner)
        {
            _magicCombiner = magicCombiner;
            InitControllers();
        }

        private void InitControllers()
        {
            InitButtons();
            _magicEffectsController.Init(_magicCombiner);
        }

        private void InitButtons()
        {
            foreach (var buttonInitializer in _buttonInitializers)
            {
                buttonInitializer.InitSelf();
                buttonInitializer.InitButton();
            }
        }
    }
}