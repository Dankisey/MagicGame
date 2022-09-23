namespace Game.Model
{
    public abstract class Damage : IDamageGetter
    {
        private readonly float _amount;

        public Damage(float amount) => _amount = amount;

        public virtual float GetDamage()
        {
            return _amount;
        }
    }

    public interface IDamageGetter
    {
        public float GetDamage();
    }
}