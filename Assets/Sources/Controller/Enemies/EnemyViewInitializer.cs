using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public sealed class EnemyViewInitializer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationController _animationController;
        [SerializeField] private DamagePopupController _damagePopupController;
        [SerializeField] private EnemyView _view;

        public EnemyView View => _view;

        public void Init(Enemy enemy)
        {
            _view.Init(enemy);
            _damagePopupController.Init(enemy);
            _animationController.Init(enemy);
        }
    }
}