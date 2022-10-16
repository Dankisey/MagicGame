using UnityEngine;
using Game.Model;

namespace Game.Controller
{
    public class FactoriesInitializer : MonoBehaviour
    {
        [SerializeField] private AttackViewFactory _attackViewFactory;

        private Player _player;

        public void Init(Player player)
        {
            _player = player;
            InitFacories();
        }

        public void InitFacories()
        {
            _attackViewFactory.Init(_player.AttackPerformer);
        }
    }
}