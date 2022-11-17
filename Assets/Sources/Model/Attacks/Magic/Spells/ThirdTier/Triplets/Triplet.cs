namespace Game.Model
{
    public abstract class Triplet : ThirdTierEffect
    {
        protected Triplet() : base(0) { }
    }

    public enum TripletTypes
    {
        Explotion,         //3 fire
        Tsunami,           //3 water
        Meteorite,         //3 earth
        Tornado            //3 air
    }
}