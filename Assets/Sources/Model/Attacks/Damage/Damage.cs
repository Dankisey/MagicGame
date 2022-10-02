namespace Game.Model
{
    public abstract class Damage : IDamageReturner
    {
        private readonly float _amount;

        public Damage(float amount) => _amount = amount;

        public virtual float GetDamage()
        {
            return _amount;
        }
    }

    public interface IDamageReturner
    {
        public float GetDamage();
    }
}