using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class HudInitializer : MonoBehaviour
    {
        [SerializeField] private BarView _staminaBar;
        [SerializeField] private BarView _healthBar;
        [SerializeField] private BarView _manaBar;

        public void Init(Player player)
        {
            _staminaBar.Init(player.Stamina);
            _healthBar.Init(player.Health);
            _manaBar.Init(player.Mana);
        }
    }
}