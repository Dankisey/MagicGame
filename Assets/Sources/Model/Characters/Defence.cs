using System;

namespace Game.Model
{
    public abstract class Defence
    {
        public Defence(int value, DamageElements element)
        {
            ModifyingElement = element;
            Value = value;
        }

        public DamageElements ModifyingElement { get; private set; }
        public int Value { get; private set; }

        public virtual float ModifyDamage(Damage damage)
        {
            float resultDamage = damage.Amount - (damage.Amount / Config.Characters.MaxDefence * Value);

            return MathF.Round(resultDamage, 2);
        }
    }

    public class WaterDefence : Defence
    {
        public WaterDefence(int value) : base(value, DamageElements.Water) { }
    }

    public class ThunderDefence : Defence
    {
        public ThunderDefence(int value) : base(value, DamageElements.Thunder) { }
    }

    public class FireDefence : Defence
    {
        public FireDefence(int value) : base(value, DamageElements.Fire) { }
    }

    public class EarthDefence : Defence
    {
        public EarthDefence(int value) : base(value, DamageElements.Earth) { }
    }

    public sealed class PhysicalDefence : Defence
    {
        public PhysicalDefence(int value) : base(value, DamageElements.Physical) { }
    }

    public sealed class AirDefence : Defence
    {
        public AirDefence(int value) : base(value, DamageElements.Air) { }
    }

    public sealed class PureDefence : Defence
    {
        public PureDefence() : base(Config.Characters.BasePureDefence, DamageElements.Pure) { }
    }
}