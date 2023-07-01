using Game.Model;

namespace Game.View
{
    public sealed class EarthView : ElementView
    {
        protected override void Init()
        {
            DamageElement = DamageElements.Earth;
        }
    }
}