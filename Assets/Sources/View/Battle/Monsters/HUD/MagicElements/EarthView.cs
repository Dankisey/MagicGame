using Game.Model;

namespace Game.View
{
    public sealed class EarthView : ElementView
    {
        public override void Init()
        {
            base.Init();
            DamageElement = DamageElements.Earth;
        }
    }
}