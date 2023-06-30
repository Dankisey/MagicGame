using System.Collections.Generic;
using System.Linq;
using System;

namespace Game.Model
{
    public abstract class EnemyAttackFactory
    {
        private EnemyAttackRarity[] _rarities;
        private EnemyAttack[] _enemyAttacks;
        private int[] _borders;
        private Random _random;
        private int _maxRandomValue;
        private int _rarityLevelsAmount;

        public EnemyAttackFactory(EnemyAttack[] enemyAttacks)
        {
            _random = new Random(DateTime.Now.Millisecond);
            _maxRandomValue = 1000;
            _enemyAttacks = enemyAttacks;
            SortAttacks();
            SetRarities();
            SetBorders();
        }

        public Attack GetAttack()
        {
            EnemyAttackRarity rarity = GetRarity();
            Attack attack = GetAttack(rarity);

            return attack;
        }

        private void SortAttacks()
        {
            _enemyAttacks = _enemyAttacks.OrderBy(enemyAttack => enemyAttack.Rarity).ToArray();
        }

        private void SetRarities()
        {
            HashSet<EnemyAttackRarity> rarities = new();

            foreach (var attack in _enemyAttacks)
                rarities.Add(attack.Rarity);
            
            _rarities = rarities.ToArray();
            _rarityLevelsAmount = _rarities.Count();

            if (_rarityLevelsAmount > 9)    // value for _maxRandomValue == 1000, otherwise the highest border will be equal to maxRandomValue                                  
                throw new ArgumentOutOfRangeException(nameof(_rarityLevelsAmount), " is too high"); // and that level of attacks will neber be chosen
        }

        private void SetBorders()
        {
            _borders = new int[_rarityLevelsAmount];

            int multiplier = 2;
            float partsAmount = MathF.Pow(multiplier, _rarityLevelsAmount);
            float part = _maxRandomValue / partsAmount;
            float filled = partsAmount / multiplier;
            float addToFilled = filled;

            _borders[0] = 0;

            for (int i = 1; i < _rarityLevelsAmount - 1; i++)
            {
                _borders[i] = (int)(filled * part);
                filled += addToFilled / multiplier;
                addToFilled /= multiplier;
            }

            _borders[^1] = _maxRandomValue - (int)part;
        }

        private Attack GetAttack(EnemyAttackRarity rarity)
        {
            EnemyAttack[] selectedAttacks = _enemyAttacks.Where(enemyAttack => enemyAttack.Rarity == rarity).ToArray();

            if (selectedAttacks.Length == 0)
                return _enemyAttacks.FirstOrDefault().Attack;
            
            int index = _random.Next(selectedAttacks.Length);
            Attack attack = selectedAttacks[index].Attack;

            return attack;
        }

        private EnemyAttackRarity GetRarity()
        {
            int randomValue = _random.Next(_maxRandomValue);
            int rarityLevel = GetRarityLevel(randomValue);

            return _rarities[rarityLevel];
        }

        private int GetRarityLevel(int randomValue)
        {
            int rarityLevel = 0;

            if (_rarityLevelsAmount == 1)
                return rarityLevel;

            for (int i = 0; i < _borders.Length; i++)
            {
                if (randomValue < _borders[i])
                    break;
                
                rarityLevel++;
            }

            return rarityLevel;
        }
    }

    public struct EnemyAttack
    {
        public readonly EnemyAttackRarity Rarity;
        public readonly Attack Attack;

        public EnemyAttack(EnemyAttackRarity rarity, Attack attack)
        {
            Rarity = rarity;
            Attack = attack;
        }
    }

    public enum EnemyAttackRarity
    {
        First,
        Second,
        Third
    }
}