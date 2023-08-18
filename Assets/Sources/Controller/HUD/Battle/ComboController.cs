using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Game.Model;
using Game.View;
using System;

namespace Game.Controller
{
    [RequireComponent(typeof(ComboView))]

    public sealed class ComboController : MonoBehaviour
    {
        [SerializeField] private ComboView _comboView;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private ElementView[] _viewPrefabs;

        private MagicCombiner _magicCombiner;
        private ElementView[] _lastCombo;

        public event Action<ElementView[]> ComboChanged;

        public void Init(MagicCombiner magicCombiner)
        {
            _magicCombiner = magicCombiner;
            _magicCombiner.ComboChanged += OnComboChanged;
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            PrepareViews();
            InitLastCombo();
        }

        private void InitLastCombo()
        {
            _lastCombo = new ElementView[Config.Magic.MaxEffectsInSpell];

            for (int i = 0; i < _lastCombo.Length; i++)
                _lastCombo[i] = GetView(DamageElements.None);
        }

        private void ResetLastCombo()
        {
            List<DamageElements> noneCombo = new();

            for (int i = 0; i < _lastCombo.Length; i++)
                noneCombo.Add(DamageElements.None);

            _lastCombo = UpdateCombo(noneCombo);
        }

        private void OnAttackCompleted(Attack attack)
        {
            ResetLastCombo();
        }

        private void OnComboChanged(List<DamageElements> damageElements)
        {
            ElementView[] views = UpdateCombo(damageElements);

            _comboView.Change(views);
            _lastCombo = views;
        }

        private ElementView[] UpdateCombo(List<DamageElements> newCombo)
        {
            ElementView[] views = new ElementView[newCombo.Count];

            for (int i = 0; i < views.Length; i++)
            {
                if (newCombo[i] != _lastCombo[i].DamageElement)
                {
                    Destroy(_lastCombo[i].gameObject);
                    views[i] = GetView(newCombo[i]);             
                }
                else
                {
                    views[i] = _lastCombo[i];
                }        
            }

            ComboChanged?.Invoke(views);

            return views;
        }

        private ElementView GetView(DamageElements damageElement)
        {   
            var views = _viewPrefabs.Where(view => view.DamageElement == damageElement);
            ElementView view = Instantiate(views.FirstOrDefault(), _parent);

            return view;
        }

        private void PrepareViews()
        {
            foreach (var view in _viewPrefabs)
                view.Init();
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
            if (_magicCombiner == null)
                return;

            _magicCombiner.ComboChanged -= OnComboChanged;
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
        }
    }
}