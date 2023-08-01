using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class DamagePopupController : MonoBehaviour
    {
        [SerializeField] private DamagePopup _prefab;
        [SerializeField] private Transform _parent;

        private Character _character;

        public void Init(Character character)
        {
            _character = character;
            _character.DamageTaken += OnDamageTaken;
        }

        private void OnDamageTaken(float amount)
        {
            DamagePopup popup = Instantiate(_prefab, _parent);
            popup.SetText(amount.ToString());
        }

        private void OnDisable()
        {
            if (_character != null)
                _character.DamageTaken -= OnDamageTaken;
        }
    }
}