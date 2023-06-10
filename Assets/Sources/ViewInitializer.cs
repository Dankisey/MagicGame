using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class ViewInitializer : MonoBehaviour
    {
        [SerializeField] private CharacteristicViewFactory _characteristicViewFactory;
        [SerializeField] private EnemyViewFactory _enemyViewFactory;

        private Player _player;
        private World _world;

        public void Init(World world, Player player)
        {
            _player = player;
            _world = world;
            InitViews();
        }

        public void InitViews()
        {
            _characteristicViewFactory.Init(_player);
            _enemyViewFactory.Init(_world);
        }
    }
}