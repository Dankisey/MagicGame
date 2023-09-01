namespace Game.Model
{
    public sealed class Player : Character
    {    
        public readonly PlayerAttackPerformer AttackPerformer;
        public readonly PlayerAttackSender AttackSender;
        public readonly MagicCombiner MagicCombiner;
        public readonly Inventory Inventory;
        public readonly Mana Mana;

        private BattleState _currentBattle;

        public Player() 
            : base (Config.Characters.Player.DamagableCharacteristics, new Level())
        {
            Mana = new(Config.Characters.Player.MaxMana);
            MagicCombiner = new(Mana);
            Inventory = new();
            AttackSender = new(MagicCombiner, DamageBuffsContainer);
            AttackPerformer = new(AttackSender, this);
        }

        public void Reset()
        {
            ResetCharacteristics();
        }

        public void EnterBattle(BattleState battle)
        {        
            _currentBattle = battle;
            _currentBattle.Ended += OnBattleEnded;
            AttackPerformer.InitBattle(_currentBattle);
        }

        private void ResetCharacteristics()
        {
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