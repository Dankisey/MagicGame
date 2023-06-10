using System.Collections.Generic;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    public class MagicElementsController : MonoBehaviour
    {
        [SerializeField] private List<MagicElementView> _elementViews;

        private MagicCombiner _combiner;

        public void Init(MagicCombiner combiner)
        {
            _combiner = combiner;
        }

        //private void OnEnable()
        //{
        //    foreach (var view in _elementViews)
        //        view.ButtonClicked += OnViewButonClick;
        //}

        //private void OnViewButonClick(Element element)
        //{
        //    _combiner.TryAddElement(element);
        //}

        //private void OnDisable()
        //{
        //    foreach (var view in _elementViews)           
        //        view.ButtonClicked -= OnViewButonClick;         
        //}
    }
}