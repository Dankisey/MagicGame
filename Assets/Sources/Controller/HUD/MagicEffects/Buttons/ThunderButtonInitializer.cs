using Game.Model;

namespace Game.Controller
{
    public sealed class ThunderButtonInitializer : ButtonInitializer
    {
        protected override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Thunder();
        }
    }
}