using Game.Model;

namespace Game.Controller
{
    public sealed class WaterButtonInitializer : ButtonInitializer
    {
        public override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Water();
        }
    }
}