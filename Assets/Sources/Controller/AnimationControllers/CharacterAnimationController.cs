using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public abstract class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] protected Animator Animator;

        protected const string DamageTaken = nameof(DamageTaken);
        protected const string IsAlive = nameof(IsAlive);

        protected bool Subscribed { get; private set; } = false;

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
            Subscribed = true;
        }

        protected virtual void Unsubscribe()
        {
            _character.DamageTaken -= OnDamageTaken;
            _character.Died -= OnDied;
            Subscribed = false;
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
            ResetAnimator();         

            if (_character != null && Subscribed == false)
                Subscribe();
        }

        private void OnDisable()
        {
            if (_character != null && Subscribed == true)
            {
                Unsubscribe();
            }
        }
    }
}