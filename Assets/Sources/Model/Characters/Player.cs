using System;

namespace Game.Model
{
    public sealed class Player : Character
    {
        private readonly Player _instance = new Lazy<Player>().Value;
        private readonly AttackFactory _attackFactory;

        private Player(): base (Config.Characters.Player.DamagableCharacteristics)
        {
            Stamina = new(Config.Characters.Player.MaxStamina);
            Mana = new(Config.Characters.Player.MaxMana);
            _attackFactory = new();
            _attackFactory.AddAttack<Slice>(new Slice(null));
        }

        public Player Instance => _instance;

        public Stamina Stamina { get; private set; }
        public Mana Mana { get; private set; }
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