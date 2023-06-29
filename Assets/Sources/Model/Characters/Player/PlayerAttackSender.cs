namespace Game.Model
{
    public sealed class PlayerAttackSender : AttackSender
    {
        private MagicCombiner _magicCombiner;

        public PlayerAttackSender(MagicCombiner magicCombiner)
        {
            _magicCombiner = magicCombiner;
            _magicCombiner.AttackCompleted += SendAttack;
        }

        public void Disable()
        {
            _magicCombiner.AttackCompleted -= SendAttack;
        }
    }
}