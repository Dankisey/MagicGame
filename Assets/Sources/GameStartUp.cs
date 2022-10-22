using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class GameStartUp : MonoBehaviour
    {
        [SerializeField] private ViewInitializer _initializer;

        private readonly Player _player = Player.Instance;
        private World _world;

        private void Awake()
        {
            _world = new(Player.Instance);
            _initializer.Init(_world, _player);
            _player.Reset();
            _world.InitiateBattle();
        }
    }
}