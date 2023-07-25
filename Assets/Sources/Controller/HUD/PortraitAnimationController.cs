using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class PortraitAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _portraitAnimator;

        private const string AttackCompleted = nameof(AttackCompleted);
        private const string DamageTaken = nameof(DamageTaken);
        private const string BattleEnded = nameof(BattleEnded);
        private const string IsAlive = nameof(IsAlive);

        private MagicCombiner _magicCombiner;
        private Player _player;
        private Battle _currentBattle;
        private World _world;
        private bool _subscribed = false;

        public void Init(Player player, World world)
        {
            _magicCombiner = player.MagicCombiner;
            _player = player;
            _world = world;
            Subscribe();
        }

        private void Subscribe()
        {
            _player.DamageTaken += OnDamageTaken;
            _player.Died += OnDied;
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            _world.BattleInitiated += OnBattleInitiated;
            _subscribed = true;
        }

        private void Unsubscribe()
        {
            _player.DamageTaken -= OnDamageTaken;
            _player.Died -= OnDied;
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
            _world.BattleInitiated -= OnBattleInitiated;
            _subscribed = false;
        }

        private void OnBattleInitiated(Battle battle)
        {
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
        }

        private void OnBattleEnded()
        {
            _portraitAnimator.SetBool(BattleEnded, true);
            _currentBattle.Ended -= OnBattleEnded;
        }

        private void OnAttackCompleted(Attack obj)
        {
            _portraitAnimator.SetTrigger(AttackCompleted);
        }

        private void OnDamageTaken(float obj)
        {
            _portraitAnimator.SetTrigger(DamageTaken);
        }

        private void OnDied(Character obj)
        {
            _portraitAnimator.SetBool(IsAlive, false);
        }

        private void OnEnable()
        {
            _portraitAnimator.SetBool(IsAlive, true);
            _portraitAnimator.SetBool(BattleEnded, false);

            if (_player != null && _subscribed == false)
                Subscribe();
        }

        private void OnDisable()
        {
            if (_player != null && _subscribed == true)
            {
                Unsubscribe();
            }
        }
    }
}