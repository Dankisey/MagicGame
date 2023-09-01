using UnityEngine;
using Game.Model;
using TMPro;

namespace Game.View
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private CharacteristicView _experienceView;
        [SerializeField] private TMP_Text _levelLabel;

        private Level _level;

        public void Init(Level level)
        {
            if (_level != null)
                Unsubscribe();

            _experienceView.Init(level.Experience);
            _level = level;
            Subscribe();
            level.InvokeEvents();
        }

        private void OnLevelUpgraded(int levelValue)
        {
            _levelLabel.text = $"Lvl. {levelValue}";
        }

        private void Subscribe()
        {
            _level.LevelUpgraded += OnLevelUpgraded;
        }

        private void Unsubscribe()
        {
            _level.LevelUpgraded -= OnLevelUpgraded;
        }
    }
}