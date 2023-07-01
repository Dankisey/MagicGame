using UnityEngine;
using Game.Model;
using System;

namespace Game.View
{
    public sealed class ComboView : MonoBehaviour
    {
        [SerializeField] private Transform[] _viewPositions;

        private ElementView[] _lastCombo;

        public void Clear()
        {
            for (int i = 0; i < _lastCombo.Length; i++)
                Destroy(_lastCombo[i].gameObject);

            _lastCombo = new ElementView[0];
        }

        public void Change(ElementView[] elementViews)
        {
            for (int i = 0; i < elementViews.Length; i++)        
                elementViews[i].transform.position = _viewPositions[i].position;   

            _lastCombo = elementViews;
        }

        private void OnEnable()
        {
            _lastCombo = new ElementView[0];

            if (_viewPositions.Length != Config.Magic.MaxEffectsInSpell)
                throw new ArgumentOutOfRangeException(nameof(_viewPositions.Length));
        }
    }
}