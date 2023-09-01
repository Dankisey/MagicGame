using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class CharacteristicViewFactory : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _healthBar;
        [SerializeField] private CharacteristicView _manaBar;
        [SerializeField] private LevelView _levelBar;

        public void Init(Player player)
        {
            _healthBar.Init(player.Health);
            _manaBar.Init(player.Mana);
            _levelBar.Init(player.Level);
        }
    }
}