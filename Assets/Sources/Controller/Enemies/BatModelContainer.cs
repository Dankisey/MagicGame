using Game.Model;

namespace Game.Controller
{
    public sealed class BatModelContainer : EnemyModelContainer
    {
        public override Enemy GetTargetEnemyInstance(int level) => new Bat(new Level().SetValue(level));
    }
}