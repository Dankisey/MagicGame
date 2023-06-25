using System;

namespace Game.Model
{
    public sealed class Player : Character
    {
        public static Player Instance => _instance.Value;
        private static readonly Lazy<Player> _instance = new(() => new Player());
        private static readonly MagicCombiner _magicCombiner = new();
        private static readonly PlayerAttackSender _playerAttackSender = new(_magicCombiner);
        private static readonly PlayerAttackPerformer _playerAttackPerformer = new(_playerAttackSender);

        public readonly Inventory Inventory;
        public readonly Stamina Stamina;
        public readonly Mana Mana;

        private Battle _currentBattle;

        private Player(): base (Config.Characters.Player.DamagableCharacteristics, _playerAttackSender, _playerAttackPerformer)
        {
            Stamina = new(Config.Characters.Player.MaxStamina);
            Mana = new(Config.Characters.Player.MaxMana);
            Inventory = new();
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

    public struct PlayerCharacteristics
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