using Game.Model;

namespace Game.Controller
{
    public sealed class WaterButton : MagicEffectButton
    {
        protected override void SetEffect()
        {
            MagicEffect = new Water();
        }
    }
}