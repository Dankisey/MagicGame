﻿namespace Game.Model
{
    public sealed class Air : Effect, IMagicEffect
    {
        public Air() : base(DamageElements.Air, Config.Magic.Air.TargetType) { }

        public Attack GetTripplet()
        {
            float damageAmount = Config.Magic.Air.Damage * Config.Magic.AugmentedMultiplier * Config.Magic.Air.Triplet.Multiplier;
            MagicDamage damage = new(damageAmount, new DamageElements[1] { DamageElements.Air });
            TickDamage tickDamage = new(Config.Magic.Air.TickDamage, new DamageElements[1] { DamageElements.Air }, Config.Magic.Air.Triplet.TickCount);

            return new Attack(damage, tickDamage, new Debuff[0], Config.Magic.Air.Triplet.TargetType);
        }

        protected override void SetDamages()
        {
            Damage = new MagicDamage(Config.Magic.Air.Damage, new DamageElements[1] { DamageElements.Air });
            TickDamage = new TickDamage(Config.Magic.Air.TickDamage, new DamageElements[1] { DamageElements.Air }, Config.Magic.Air.TickCount);
        }
    }
}