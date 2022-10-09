using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using System;
using TMPro;

namespace Game.View
{
    public sealed class AttackView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        private int _attackID;

        public event Action<int> AttackRequestSent;

        public void Init(AttackIDs id)
        {
            _text.text = id.ToString();
            _attackID = (int)id;
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            AttackRequestSent?.Invoke(_attackID);
        }
    }
}