using System;

namespace Game.Model
{
    public class Level 
    {
        public Level()
        {
            Value = 0;
            Experience = new(Config.Characters.Level.BaseLevelCost);
            Experience.MaxValueReached += OnMaxExperienceReached;
        }

        ~Level()
        {
            Experience.MaxValueReached -= OnMaxExperienceReached;
        }

        public Experience Experience { get; private set; }
        public int Value { get; private set; }

        public AllMultiplier Multiplier => new(Value * Config.Characters.Level.MultiplierByLevel);

        public event Action<int> LevelUpgraded;
        
        public Level SetValue(int value) 
        {
            Value = value;
            SetMaxExperience();

            return this;
        }

        public int GetRewardExperience() => Experience.GetRewardValue();

        public void AddExpirience(int amount)
        {
            Experience.Add(amount);
        }

        public void InvokeEvents()
        {
            LevelUpgraded?.Invoke(Value);
            Experience.Add(0);
        }

        private bool TryLevelUp()
        {
            if (Value >= Config.Characters.Level.MaxValue)
                return false;
            
            Value++;
            int restExperience = (int)Experience.Value - Experience.MaxValue;
            Experience.Reset();
            SetMaxExperience();
            Experience.Add(restExperience);
            LevelUpgraded?.Invoke(Value);

            return true;
        }

        private void OnMaxExperienceReached()
        {
            TryLevelUp();
        }

        private void SetMaxExperience()
        {
            int baseLevelCost = Config.Characters.Level.BaseLevelCost;
            int maxExpirience = baseLevelCost + Convert.ToInt32(baseLevelCost * Value * Config.Characters.Level.MultiplierByLevel);
            Experience.UpdateMaxValue(maxExpirience);
        }
    }

    public class Experience : ShowableCharacteristic
    {
        public Experience(int maxValue) : base(maxValue) { }

        public event Action MaxValueReached;

        public void UpdateMaxValue(int maxValue)
        {
            MaxValue = maxValue;
        }

        public void Add(int amount)
        {
            Value += amount;

            if (Value >= MaxValue)
                MaxValueReached?.Invoke();

            InvokeValueChangedEvent();
        }

        public int GetRewardValue() => MaxValue / Config.Characters.Level.PartRecievingByKill;
    }
}