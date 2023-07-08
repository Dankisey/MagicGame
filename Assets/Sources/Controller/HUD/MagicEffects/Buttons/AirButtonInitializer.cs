using Game.Model;

namespace Game.Controller
{
    public sealed class AirButtonInitializer : ButtonInitializer
    {
        protected override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Air();
        }
    }
}