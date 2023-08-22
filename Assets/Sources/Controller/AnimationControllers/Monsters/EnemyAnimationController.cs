using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class EnemyAnimationController : CharacterAnimationController
    {
        private const string Attack = nameof(Attack);

        private Enemy _enemy;

        public void Init(Enemy enemy)
        {
            if (_enemy != null)
                Unsubscribe();

            _enemy = enemy;
            base.Init(enemy);
        }

        protected override void Subscribe() 
        {
            base.Subscribe();
            _enemy.Attacked += OnAttacked;
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            _enemy.Attacked -= OnAttacked;
        }
   
        private void OnAttacked()
        {
            Animator.SetTrigger(Attack);
        }
    }
}