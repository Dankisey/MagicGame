using System;

namespace Game.Model
{
    public abstract class Character
    {
        public Character(DamagableCharacteristics characteristics)
        {
            Health = new(characteristics.MaxHealth);
            PhysicalArmor = new(characteristics.PhysicalArmor);
            MagicArmor = new(characteristics.MagicArmor);
        }

        public event Action<float> DamageTaken;
        public event Action Died;

        public Health Health { get; private set; }
        public Armor PhysicalArmor { get; private set; }
        public Armor MagicArmor { get; private set; }

        public void TakeDamage(PureDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            ApplyDamage(damageAmount);
        }

        public void TakeDamage(PhysicalDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float damageAmount = damage.GetDamage();
            float modifiedDamage = PhysicalArmor.GetModifiedDamage(damageAmount);
            ApplyDamage(modifiedDamage);
        }

        public void TakeDamage(MagicDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

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