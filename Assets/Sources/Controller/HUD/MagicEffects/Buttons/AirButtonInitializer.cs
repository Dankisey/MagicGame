using Game.Model;

namespace Game.Controller
{
    public sealed class AirButtonInitializer : ButtonInitializer
    {
        public override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Air();
        }
    }
}