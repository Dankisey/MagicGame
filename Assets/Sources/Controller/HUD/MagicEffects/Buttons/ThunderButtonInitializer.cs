using Game.Model;

namespace Game.Controller
{
    public sealed class ThunderButtonInitializer : ButtonInitializer
    {
        public override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Thunder();
        }
    }
}