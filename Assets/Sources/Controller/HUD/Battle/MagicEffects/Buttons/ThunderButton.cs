using Game.Model;

namespace Game.Controller
{
    public sealed class ThunderButton : MagicEffectButton
    {
        protected override void SetEffect()
        {
            MagicEffect = new Thunder();
        }
    }
}