using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class ControllerInitializer : MonoBehaviour
    {
        [SerializeField] private CharacteristicViewFactory _characteristicViewFactory;
        [SerializeField] private PortraitAnimationController _portraitAnimator;
        [SerializeField] private MagicEffectsController _magicEffectsController;
        [SerializeField] private SpellParticlesFactory _spellParticlesFactory;
        [SerializeField] private HUDController _hudController;
        [SerializeField] private DamagePopupController _playerDamagePopupController;
        [SerializeField] private ComboController _comboViewController;
        [SerializeField] private BattleController _battleController;
        [SerializeField] private BiomesController _biomesController;

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
            _characteristicViewFactory.Init(_player);
            _playerDamagePopupController.Init(_player);
            _magicEffectsController.Init(_magicCombiner);
            _spellParticlesFactory.Init(_magicCombiner);
            _comboViewController.Init(_magicCombiner);
            _battleController.Init(_world);
            _portraitAnimator.Init(_player, _world);
            _hudController.Init(_world);
            _biomesController.Init(_world);
        }
    }
}