using System;

namespace Game.Model
{
    public sealed class Player : Character
    {
        public static Player Instance => _instance.Value;
        private static readonly Lazy<Player> _instance = new(() => new Player());

        public readonly AttackPerformer AttackPerformer;
        public readonly Inventory Inventory;
        public readonly Stamina Stamina;
        public readonly Mana Mana;

        private Battle _currentBattle;

        private Player(): base (Config.Characters.Player.DamagableCharacteristics)
        {
            Stamina = new(Config.Characters.Player.MaxStamina);
            Mana = new(Config.Characters.Player.MaxMana);
            AttackPerformer = new(Mana, Stamina);
            Inventory = new();
        }

        public void EnterBattleMod(Battle battle)
        {
            _currentBattle = battle;
            AttackPerformer.InitBattle(battle);
            _currentBattle.Ended += OnBattleEnded;
        }

        private void OnBattleEnded()
        {
            _currentBattle.Ended -= OnBattleEnded;
        }

        public void ResetAttackPerformer()
        {
            AttackPerformer.AddAttack<Slice>(new Slice());
            AttackPerformer.AddAttack<FireBall>(new FireBall());
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