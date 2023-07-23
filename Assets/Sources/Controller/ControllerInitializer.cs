using System.Collections.Generic;
using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class ControllerInitializer : MonoBehaviour
    {
        [SerializeField] private MagicEffectsController _magicEffectsController;
        [SerializeField] private ComboController _comboViewController;
        [SerializeField] private HUDController _hudController;
        [SerializeField] private BattleController _battleController;

        private MagicCombiner _magicCombiner;
        private World _world;

        public void Init(MagicCombiner magicCombiner, World world)
        {
            _magicCombiner = magicCombiner;
            _world = world;
            InitControllers();
        }

        private void InitControllers()
        {
            _magicEffectsController.Init(_magicCombiner);
            _comboViewController.Init(_magicCombiner);
            _hudController.Init(_world);
            _battleController.Init(_world);
        }
    }
}