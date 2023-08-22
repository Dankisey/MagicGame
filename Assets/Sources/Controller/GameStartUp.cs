using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public sealed class GameStartUp : MonoBehaviour
    {
        [SerializeField] private ControllerInitializer _controllerInitializer;
        [SerializeField] private CanvasGroup[] _disableOnStart;

        private Player _player;
        private World _world;

        private void OnEnable()
        {
            _player = Player.Instance;
            _world = new(_player);
            _controllerInitializer.Init(_player, _world);
            _player.Reset();
            _world.Start();
            DisableCanvasGroups();
        }

        private void DisableCanvasGroups()
        {
            foreach (var canvasGroup in _disableOnStart)
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }
}