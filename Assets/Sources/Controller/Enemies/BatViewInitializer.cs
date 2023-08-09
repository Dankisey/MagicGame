using Game.Model;

namespace Game.Controller
{
    public sealed class BatViewInitializer : EnemyViewInitializer
    {
        public override Enemy GetTargetEnemyInstance() => new Bat();
    }
}