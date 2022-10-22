using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using System;
using TMPro;
using Game.Controller;

namespace Game.View
{
    public sealed class AttackView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        private AttackTrigger _attackTrigger;
        private int _attackID;

        public void Init(AttackIDs id, AttackPerformer performer)
        {
            _text.text = id.ToString();
            _attackID = (int)id;
            CreateTrigger(performer);          
        }

        private void CreateTrigger(AttackPerformer performer)
        {
            if (_attackTrigger != null)           
                _button.onClick.RemoveListener(_attackTrigger.Activate);
            
            _attackTrigger = new AttackTrigger(_attackID, performer);
            _button.onClick.AddListener(_attackTrigger.Activate);
        }
    }
}