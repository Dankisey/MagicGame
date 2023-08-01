using Game.Model;
using Game.View;
using UnityEngine;

namespace Game.Controller
{
    public abstract class EnemyInitializer : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationController _animationController;
        [SerializeField] private DamagePopupController _damagePopupController;
        [SerializeField] private EnemyView _view;

        public void Init(Enemy enemy)
        {
            _damagePopupController.Init(enemy);
            _animationController.Init(enemy);
            _view.Init(enemy);
        }

        public virtual EnemyIDs ID => EnemyIDs.None;
    }
}