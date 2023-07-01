namespace Game.Model
{
    public sealed class BatAttackFactory : EnemyAttackFactory
    {
        public BatAttackFactory() : base(Config.Characters.Enemies.TEST) { }
    }
}