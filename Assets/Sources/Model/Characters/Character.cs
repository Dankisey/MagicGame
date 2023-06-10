using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class Character
    {
        private List<Effect> _effects = new();

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

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void ApplyAttack(Attack attack)
        {
            throw new NotImplementedException();
        }

        private void TakeDamage(Damage damage)
        {
            TakeDamage((dynamic)damage);
        }

        private void TakeDamage(PureDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            ApplyDamage(damage.Amount);
        }

        private void TakeDamage(PhysicalDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float modifiedDamage = PhysicalArmor.GetModifiedDamage(damage.Amount);
            ApplyDamage(modifiedDamage);
        }

        private void TakeDamage(MagicDamage damage)
        {
            if (Health.IsAlive == false)
                throw new NotImplementedException($"Trying {nameof(TakeDamage)} when {nameof(Health.IsAlive)} equals false");

            float modifiedDamage = MagicArmor.GetModifiedDamage(damage.Amount);
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

    public readonly struct DamagableCharacteristics
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