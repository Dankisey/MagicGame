namespace Game.Model
{
    public abstract class SecondTierSpell : Spell
    {
        protected SecondTierSpell(SecondTierElementTypes type, bool isAugmented)
        {
            Type = type;
            IsAugmented = isAugmented;
        }

        public SecondTierElementTypes Type { get; private set; }
        public bool IsAugmented { get; private set; }

        public override Spell Combine(ICombineable spell) => GetCombination((dynamic)spell);

        protected abstract Spell GetCombination(FireSpell spell);

        protected abstract Spell GetCombination(WaterSpell spell);

        protected abstract Spell GetCombination(EarthSpell spell);

        protected abstract Spell GetCombination(AirSpell spell);
    }

    public enum SecondTierElementTypes
    {
        Fire,              //2 fire
        Water,             //2 water
        Earth,             //2 earth
        Air,               //2 air

        Steam,             //water + fire
        Lava,              //earth + fire
        Gas,               //air + fire

        Mud,               //earth + water
        Ice,               //air + water

        Dust               //air + earth
    }
}