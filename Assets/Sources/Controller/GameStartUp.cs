using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class GameStartUp : MonoBehaviour
    {
        [SerializeField] private ViewInitializer _viewInitializer;
        [SerializeField] private ControllerInitializer _controllerInitializer;

        private Player _player;
        private World _world;

        private void Awake()
        {
            _player = Player.Instance;
            _world = new(_player);
            _viewInitializer.Init(_world, _player);
            _controllerInitializer.Init(_player, _world);
            _player.Reset();
            _world.Start();
            _world.EnterBattle(new(_player, new Enemy[1] { new Bat() }));
        }
    }
}