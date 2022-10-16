using System.Collections.Generic;
using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public sealed class AttackViewFactory : MonoBehaviour
    {
        [SerializeField] private AttackView _viewTemplate;
        [SerializeField] private Transform _parent;

        private readonly Dictionary<int, AttackView> _views = new();
        private AttackPerformer _attackPerformer;

        public void Init(AttackPerformer attackPerformer)
        {
            _attackPerformer = attackPerformer;
            _attackPerformer.AttackAdded += OnAttackAdded;
        }

        private void OnAttackAdded(int attackID)
        {
            CreateView(attackID);
        }

        private void OnDisable()
        {
            _attackPerformer.AttackAdded -= OnAttackAdded;
        }

        private void CreateView(int attackID)
        {
            AttackView view = Instantiate(_viewTemplate, _parent);
            view.Init((AttackIDs)attackID, _attackPerformer);
            _views.Add(attackID, view);
        }
    }
}