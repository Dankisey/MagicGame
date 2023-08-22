using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public abstract class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] protected Animator Animator;

        protected const string DamageTaken = nameof(DamageTaken);
        protected const string IsAlive = nameof(IsAlive);

        private Character _character;

        protected void Init(Character character)
        {
            _character = character;
            Subscribe();
        }

        protected virtual void Subscribe()
        {
            _character.DamageTaken += OnDamageTaken;
            _character.Died += OnDied;
        }

        protected virtual void Unsubscribe()
        {
            _character.DamageTaken -= OnDamageTaken;
            _character.Died -= OnDied;
        }

        protected virtual void ResetAnimator()
        {
            Animator.SetBool(IsAlive, true);
        }

        private void OnDamageTaken(float obj)
        {
            Animator.SetTrigger(DamageTaken);
        }

        private void OnDied(Character obj)
        {
            Animator.SetBool(IsAlive, false);
        }

        private void OnEnable()
        {
            if (_character != null)
                Subscribe();

            ResetAnimator();         
        }

        private void OnDisable()
        {
            if (_character != null)
                Unsubscribe();
        }
    }
}