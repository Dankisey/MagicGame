using Game.Model;

namespace Game.Controller
{
    public sealed class EarthButtonInitializer : ButtonInitializer
    {
        protected override void InitSelf()
        {
            base.InitSelf();
            MagicEffect = new Earth();
        }
    }
}