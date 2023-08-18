using Game.Model;

namespace Game.Controller
{
    public sealed class EarthButton : MagicEffectButton
    {
        protected override void SetEffect()
        {
            MagicEffect = new Earth();
        }
    }
}