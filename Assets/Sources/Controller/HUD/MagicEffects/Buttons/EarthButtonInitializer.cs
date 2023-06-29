using Game.Model;

namespace Game.Controller
{
    public sealed class EarthButtonInitializer : ButtonInitializer
    {
        public override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Earth();
        }
    }
}