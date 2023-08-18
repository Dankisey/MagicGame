using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using System;
using TMPro;

namespace Game.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _healthView;
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private Transform _pointerPosition;
        [SerializeField] private TMP_Text _nameHolder;
        [SerializeField] private Button _selectButton;

        public Transform PointerPosition => _pointerPosition;
        public Transform TargetPosition => _targetPosition;
        public Enemy Self { get; private set; }

        public event Action<Enemy> Selected;

        public void Init(Enemy enemy)
        {
            Self = enemy;
            _healthView.Init(Self.Health);
            _nameHolder.text = Self.Name;
        }

        private void OnButtonClicked()
        {
            Selected?.Invoke(Self);
        }

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(OnButtonClicked);
        }
    }
}