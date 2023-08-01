using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class ControllerInitializer : MonoBehaviour
    {
        [SerializeField] private MagicEffectsController _magicEffectsController;
        [SerializeField] private PortraitAnimationController _portraitAnimator;
        [SerializeField] private HUDController _hudController;
        [SerializeField] private ComboController _comboViewController;
        [SerializeField] private BattleController _battleController;

        private MagicCombiner _magicCombiner;
        private Player _player;
        private World _world;

        public void Init(Player player, World world)
        {
            _player = player;
            _magicCombiner = player.MagicCombiner;
            _world = world;
            InitControllers();
        }

        private void InitControllers()
        {
            _magicEffectsController.Init(_magicCombiner);
            _comboViewController.Init(_magicCombiner);
            _battleController.Init(_world);
            _portraitAnimator.Init(_player, _world);
            _hudController.Init(_world);
        }
    }
}