using System.Collections.Generic;
using UnityEngine;
using Game.Model;
using Game.View;
using System;

namespace Game.Controller
{
    public class SpellParticlesFactory : MonoBehaviour
    {
        [SerializeField][Range(0f, 3f)] private float _timeToReachTarget;
        [SerializeField] private BattleController _battleController;
        [SerializeField] private EnemyViewFactory _enemyViewFactory;
        [SerializeField] private ComboController _comboController;
        [SerializeField] private SpellView _particlesContainerPrefab;
        [SerializeField] private Transform _startPosition;

        private List<ParticleSystem> _currentParticlesPrefabs;
        private List<Transform> _currentEnemiesPositions;
        private Transform _currentTargetPosition;
        private MagicCombiner _magicCombiner;

        public void Init(MagicCombiner magicCombiner)
        {
            if (_magicCombiner != null)
                Unsubscribe();

            _currentParticlesPrefabs = new();
            _currentEnemiesPositions = new();
            _magicCombiner = magicCombiner;     
        }

        private void OnComboChanged(ElementView[] views)
        {
            _currentParticlesPrefabs.Clear();

            for (int i = 0; i < views.Length; i++)
            {
                if (views[i].DamageElement != DamageElements.None)
                    _currentParticlesPrefabs.Add(views[i].ParticleSystemPrefab);
            }
        }

        private void OnAttackCompleted(Attack attack)
        {
            if (attack.TargetType == TargetTypes.Solo)
            {
                InstantiateSpellView(_currentTargetPosition);
            }
            else
            {
                foreach (var target in _currentEnemiesPositions)
                    InstantiateSpellView(target);              
            }    
        }

        private void InstantiateSpellView(Transform target)
        {
            SpellView spellView = Instantiate(_particlesContainerPrefab, _startPosition);

            foreach (var particlePrefab in _currentParticlesPrefabs)           
                Instantiate(particlePrefab, spellView.gameObject.transform);
            
            spellView.Init(target, _timeToReachTarget);
        }

        private void OnEnemiesSpawned(EnemyView[] enemyViews)
        {
            _currentEnemiesPositions.Clear();

            foreach (var view in enemyViews)
            {
                _currentEnemiesPositions.Add(view.TargetPosition);
                view.ModelDied += OnEnemyDeath;
            }
        }

        private void OnEnemyDeath(EnemyView view)
        {
            view.ModelDied -= OnEnemyDeath;
            _currentEnemiesPositions.Remove(view.TargetPosition);
        }

        private void OnNewTargetSetted(EnemyView enemyView)
        {
            _currentTargetPosition = enemyView.TargetPosition;
        }

        private void Subscribe()
        {
            _magicCombiner.AttackCompleted += OnAttackCompleted;
            _comboController.ComboChanged += OnComboChanged;
            _enemyViewFactory.EnemiesSpawned += OnEnemiesSpawned;
            _battleController.NewTargetSetted += OnNewTargetSetted;
        }

        private void Unsubscribe() 
        {
            _magicCombiner.AttackCompleted -= OnAttackCompleted;
            _comboController.ComboChanged -= OnComboChanged;
            _enemyViewFactory.EnemiesSpawned -= OnEnemiesSpawned;
            _battleController.NewTargetSetted -= OnNewTargetSetted;
        }

        private void OnEnable()
        {
            if (_magicCombiner != null)
                Subscribe();
        }

        private void OnDisable()
        {
            if(_magicCombiner != null)
                Unsubscribe();
        }
    }
}