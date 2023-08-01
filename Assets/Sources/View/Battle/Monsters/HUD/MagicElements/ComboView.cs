using UnityEngine;
using Game.Model;
using System;

namespace Game.View
{
    public sealed class ComboView : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _viewPositions;

        public void Change(ElementView[] elementViews)
        {
            for (int i = 0; i < elementViews.Length; i++)            
                elementViews[i].transform.position = _viewPositions[i].position;              
        }

        private void OnEnable()
        {
            if (_viewPositions.Length != Config.Magic.MaxEffectsInSpell)
                throw new ArgumentOutOfRangeException(nameof(_viewPositions.Length));
        }
    }
}