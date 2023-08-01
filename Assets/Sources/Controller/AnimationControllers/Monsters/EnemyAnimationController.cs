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
            _enemy = enemy;
            base.Init(enemy);
        }

        protected override void Subscribe() 
        {
            _enemy.Attacked += OnAttacked;
            base.Subscribe();
        }

        protected override void Unsubscribe()
        {
            _enemy.Attacked -= OnAttacked;
            base.Unsubscribe();
        }
   
        private void OnAttacked()
        {
            Animator.SetTrigger(Attack);
        }
    }
}