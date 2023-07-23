using Game.Model;

namespace Game.Controller
{
    public sealed class AirButton : MagicEffectButton
    {
        protected override void SetEffect()
        {
            MagicEffect = new Air();
        }
    }
}