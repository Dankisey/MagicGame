using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class CharacteristicViewFactory : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _staminaBar;
        [SerializeField] private CharacteristicView _healthBar;
        [SerializeField] private CharacteristicView _manaBar;

        public void Init(Player player)
        {
            _staminaBar.Init(player.Stamina);
            _healthBar.Init(player.Health);
            _manaBar.Init(player.Mana);
        }
    }
}