using Game.Model;

namespace Game.Controller
{
    public sealed class FireButton : MagicEffectButton
    {
        protected override void SetEffect()
        {
            MagicEffect = new Fire();
        }
    }
}