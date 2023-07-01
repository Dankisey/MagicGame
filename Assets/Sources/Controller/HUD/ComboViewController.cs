using System.Collections.Generic;
using UnityEngine;
using Game.Model;
using Game.View;
using System.Linq;

namespace Game.Controller
{
    [RequireComponent(typeof(ComboView))]

    public sealed class ComboViewController : MonoBehaviour
    {
        [SerializeField] private ElementView[] _viewPrefabs;
        [SerializeField] private ComboView _comboView;

        private MagicCombiner _magicCombiner;
        private ElementView[] _lastCombo;

        public void Init(MagicCombiner magicCombiner)
        {
            _magicCombiner = magicCombiner;
            _magicCombiner.ComboChanged += OnComboChanged;
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            _lastCombo = new ElementView[0];
        }

        private void OnAttackCompleted(Attack attack)
        {
            _lastCombo = new ElementView[0];
            _comboView.Clear();
        }

        private void OnComboChanged(List<DamageElements> damageElements)
        {
            bool comboIsNew = _lastCombo.Length > damageElements.Count;

            if (comboIsNew)
                _comboView.Clear();

            ElementView[] views = new ElementView[damageElements.Count];

            for (int i = 0; i< _lastCombo.Length; i++)           
                views[i] = _lastCombo[i];
            
            views[^1] = GetView(damageElements[^1]);

            _comboView.Change(views);
            _lastCombo = views;
        }

        private ElementView GetView(DamageElements damageElement)
        {
            var views = _viewPrefabs.Where(view => view.DamageElement == damageElement);

            return Instantiate(views.FirstOrDefault());
        }

        private void OnEnable()
        {
            if (_magicCombiner == null)
                return;

            _magicCombiner.ComboChanged += OnComboChanged;
            _magicCombiner.AttackCompleted += OnAttackCompleted;
        }

        private void OnDisable() 
        {
            _magicCombiner.ComboChanged -= OnComboChanged;
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
        }
    }
}