using UnityEngine;
using Game.Model;
using TMPro;

namespace Game.View
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _healthView;
        [SerializeField] private TMP_Text _nameHolder;

        public Enemy Self { get; private set; }

        public EnemyIDs ID { get; protected set; }

        public void Init(Enemy enemy)
        {
            Self = enemy;
            _healthView.Init(Self.Health);
            _nameHolder.text = Self.Name;
        }
    }
}