using Game.Model;

namespace Game.Controller
{
    public sealed class FireButtonInitializer : ButtonInitializer
    {
        public override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Fire();
        }
    }
}