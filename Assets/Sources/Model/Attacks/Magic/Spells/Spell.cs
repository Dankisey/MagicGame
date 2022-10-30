namespace Game.Model
{
    public abstract class Spell : ICombineable
    {
        public abstract Spell Combine(ICombineable spell);
    }

    public interface ICombineable
    {
        public Spell Combine(ICombineable spell);
    }

    public interface ITripletReturner
    {
        public Spell GetTriplet();
    }

    public enum ThirdTierElementTypes
    {
        ObsidianSpike,     //lava + water
        MagmaBall,         //lava + air
        GlassShards,       //dust + fire
        EarthSpikes,       //mud + fire
        SnowStorm,         //ice + fire

        Explotion,         //3 fire
        Tsunami,           //3 water
        Meteorite,         //3 earth
        Tornado            //3 air
    }
}