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

        public event Action<Character> Died;
        public event Action<float> DamageTaken;

        public bool IsAlive => Health.IsAlive;

        public void TakeDamage(Damage damage)
        {
            TakeDamage((dynamic)damage);
        }

        private void TakeDamage(PureDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(IDamageTaker.TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            ApplyDamage(damageAmount);
        }

        private void TakeDamage(PhysicalDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(IDamageTaker.TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            float modifiedDamage = PhysicalArmor.GetModifiedDamage(damageAmount);
            ApplyDamage(modifiedDamage);
        }

        private void TakeDamage(MagicDamage damage)
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
            Died?.Invoke(this);
            return true;
        }
    }

    public interface IDamageTaker
    {
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