using System;

namespace Game.Model
{
    public sealed class Player : Character
    {
        public static Player Instance => _instance.Value;

        public readonly AttackFactory AttackFactory;
        public readonly Stamina Stamina;
        public readonly Mana Mana;

        private static readonly Lazy<Player> _instance = new(() => new Player());

        private Player(): base (Config.Characters.Player.DamagableCharacteristics)
        {
            Stamina = new(Config.Characters.Player.MaxStamina);
            Mana = new(Config.Characters.Player.MaxMana);
            AttackFactory = new();
            InitiateAttackFactory();
        }

        private void InitiateAttackFactory()
        {
            
            AttackFactory.AddAttack<Slice>(new Slice());
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