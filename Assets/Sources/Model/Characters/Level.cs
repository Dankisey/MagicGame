using System;

namespace Game.Model
{
    public class Level
    {
        public Level() 
        {
            Value = 0;
            CurrentExperience = 0;
            SetMaxExperience();
        }

        public int CurrentExperience { get; private set; }
        public int MaxExpirience { get; private set; }
        public int Value { get; private set; }

        public AllMultiplier Multiplier => new(Value * Config.Characters.Level.MultiplierByLevel);

        public event Action<int> LevelUpgraded;
        
        public Level SetValue(int value) 
        {
            Value = value;
            SetMaxExperience();
            return this;
        }

        public void AddExpirience(int amount)
        {
            CurrentExperience += amount;

            if (CurrentExperience >= MaxExpirience)
                TryLevelUp();
        }

        private bool TryLevelUp()
        {
            if (Value >= Config.Characters.Level.MaxValue)
                return false;
            
            Value++;
            CurrentExperience -= MaxExpirience;
            SetMaxExperience();
            LevelUpgraded?.Invoke(Value);

            return true;
        }

        private void SetMaxExperience()
        {
            int baseLevelCost = Config.Characters.Level.BaseLevelCost;
            MaxExpirience = baseLevelCost + Convert.ToInt32(baseLevelCost * Value * Config.Characters.Level.MultiplierByLevel);
        }
    }
}