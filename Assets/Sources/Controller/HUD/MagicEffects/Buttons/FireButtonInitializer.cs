using Game.Model;

namespace Game.Controller
{
    public sealed class FireButtonInitializer : ButtonInitializer
    {
        protected override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Fire();
        }
    }
}