using System;

namespace Game.Model
{
    public abstract class Character : IDamageTaker
    {
        public readonly Health Health;
        public readonly Armor PhysicalArmor;
        public readonly Armor MagicArmor;

        public Character(DamagableCharacteristics characteristics)
        {
            Health = new(characteristics.MaxHealth);
            PhysicalArmor = new(characteristics.PhysicalArmor);
            MagicArmor = new(characteristics.MagicArmor);
        }

        public event Action<float> DamageTaken;
        public event Action Died;


        void IDamageTaker.TakeDamage(PureDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(IDamageTaker.TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            ApplyDamage(damageAmount);
        }

        void IDamageTaker.TakeDamage(PhysicalDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(IDamageTaker.TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            float modifiedDamage = PhysicalArmor.GetModifiedDamage(damageAmount);
            ApplyDamage(modifiedDamage);
        }

        void IDamageTaker.TakeDamage(MagicDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(IDamageTaker.TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            float modifiedDamage = MagicArmor.GetModifiedDamage(damageAmount);
            ApplyDamage(modifiedDamage);
        }

        private void ApplyDamage(float modifiedDamage)
        {
            Health.ApplyDamage(modifiedDamage);
            DamageTaken?.Invoke(modifiedDamage);

            if (Health.IsAlive == false)
                TryDie();
        }

        private bool TryDie()
        {
            Died?.Invoke();
            return true;
        }
    }

    public interface IDamageTaker
    {
        protected void TakeDamage(PureDamage damage);

        protected void TakeDamage(PhysicalDamage damage);

        protected void TakeDamage(MagicDamage damage);

        public void TakeDamage(Damage damage)
        {
            TakeDamage((dynamic)damage);
        }
    }

    public struct DamagableCharacteristics
    {
        public readonly int MaxHealth;
        public readonly int PhysicalArmor;
        public readonly int MagicArmor;

        public DamagableCharacteristics(int maxHealth, int physicalArmor, int magicArmor)
        {
            MaxHealth = maxHealth;
            PhysicalArmor = physicalArmor;
            MagicArmor = magicArmor;
        }
    }
}