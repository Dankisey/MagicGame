using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class ViewInitializer : MonoBehaviour
    {
        [SerializeField] private AttackViewFactory _attackViewFactory;
        [SerializeField] private HudInitializer _hudInitializer;

        private Player _player;

        public void Init(Player player)
        {
            _player = player;
            InitViews();
        }

        public void InitViews()
        {
            _attackViewFactory.Init(_player.AttackPerformer);
            _hudInitializer.Init(_player);
        }
    }
}