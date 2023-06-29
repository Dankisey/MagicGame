using System;

namespace Game.Model
{
    public sealed class Player : Character
    {
        public static Player Instance => _instance.Value;

        private static readonly Lazy<Player> _instance = new(() => new Player());
        
        public readonly PlayerAttackPerformer AttackPerformer;
        public readonly PlayerAttackSender AttackSender;
        public readonly MagicCombiner MagicCombiner;
        public readonly Inventory Inventory;
        public readonly Stamina Stamina;
        public readonly Mana Mana;

        private Battle _currentBattle;

        private Player() 
            : base (Config.Characters.Player.DamagableCharacteristics)
        {
            Stamina = new(Config.Characters.Player.MaxStamina);
            Mana = new(Config.Characters.Player.MaxMana);
            MagicCombiner = new();
            Inventory = new();
            AttackSender = new(MagicCombiner);
            AttackPerformer = new(AttackSender, this);
        }

        public void Reset()
        {
            ResetCharacteristics();
        }

        public void EnterBattleMod(Battle battle)
        {        
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
        }

        private void ResetCharacteristics()
        {
            Stamina.Reset();
            Health.Reset();
            Mana.Reset();
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
        }
    }

    public readonly struct PlayerCharacteristics
    {
        public readonly int MaxStamina;
        public readonly int MaxMana;

        public PlayerCharacteristics(int maxStamina, int maxMana)
        {
            MaxStamina = maxStamina;
            MaxMana = maxMana;
        }
    }
}