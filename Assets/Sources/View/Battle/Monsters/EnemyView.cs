using UnityEngine;
using Game.Model;
using TMPro;

namespace Game.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _healthView;
        [SerializeField] private TMP_Text _nameHolder;

        private Enemy _self;

        public EnemyIDs ID { get; protected set; }

        public void Init(Enemy enemy)
        {
            _self = enemy;
            _healthView.Init(_self.Health);
            _nameHolder.text = _self.Name;
        }
    }
}