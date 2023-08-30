namespace Game.Model
{
    public abstract class DamageMultiplier
    {
        public abstract DamageElements Element{ get; }
        public float Value { get; private set; }

        public DamageMultiplier(float value)
        {
            Value = value;
        }
    }

    public sealed class AllMultiplier : DamageMultiplier
    {
        public AllMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.None;
    }

    public sealed class AirMultiplier : DamageMultiplier
    {
        public AirMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.Air;
    }

    public sealed class EarthMultiplier : DamageMultiplier
    {
        public EarthMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.Earth;
    }

    public sealed class FireMultiplier : DamageMultiplier
    {
        public FireMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.Fire;
    }

    public sealed class ThunderMultiplier : DamageMultiplier
    {
        public ThunderMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.Thunder;
    }

    public sealed class WaterMultiplier : DamageMultiplier
    {
        public WaterMultiplier(float value) : base(value) { }

        public override DamageElements Element => DamageElements.Water;
    }
}