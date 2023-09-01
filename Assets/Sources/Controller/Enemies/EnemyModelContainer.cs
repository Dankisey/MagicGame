using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public abstract class EnemyModelContainer : MonoBehaviour
    {
        [SerializeField] private EnemyViewInitializer _viewInitializer;

        public EnemyViewInitializer ViewInitializer => _viewInitializer;

        public abstract Enemy GetTargetEnemyInstance(int level);
    }
}