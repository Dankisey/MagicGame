using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class Character
    {
        private readonly List<ITickable> _tickables = new();
        private readonly AttackSender _attackSender;

        public readonly AttackPerformer _attackPerformer;
        public readonly Health Health;
        public readonly Armor Armor;

        public Character(DamagableCharacteristics characteristics, AttackSender attackSender, AttackPerformer attackPerformer)
        {
            Health = new(characteristics.MaxHealth);
            Armor = new(characteristics.ArmorCharacteristics);
            _attackPerformer = attackPerformer;
            _attackSender = attackSender;
        }

        public event Action<Character> Died;
        public event Action<float> DamageTaken;

        public bool IsAlive => Health.IsAlive;

        public void Tick()
        {
            foreach (var tickable in _tickables)
            {
                if (tickable is TickDamage)
                    TakeDamage(tickable as TickDamage);

                tickable.Tick();
            }
        }

        public void ApplyAttack(Attack attack)
        {
            foreach (var debuff in attack.Debuffs)
            {
                if (TryUpdateTickable(debuff) == false)               
                    AddTickable(debuff);              
            }

            if (TryUpdateTickable(attack.TickDamage) == false)
                AddTickable(attack.TickDamage);

            TakeDamage(attack.Damage);
        }

        private bool TryUpdateTickable(ITickable newTickable)
        {
            if (newTickable is TickDamage)
                return false;
            
            ITickable toUpdate = null;
            bool exist = false;

            foreach (var tickable in _tickables)
            {
                if (tickable.GetType() == newTickable.GetType())
                {
                    toUpdate = tickable;
                    exist = true;
                    break;
                }
            }

            if (exist)
            {
                toUpdate.ForceEnd();
                AddTickable(newTickable);
            }

            return exist;
        }

        private void TakeDamage(Damage damage)
        {
            float modifiedDamage = Armor.GetModifiedDamage(damage);
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

        private void AddTickable(ITickable tickable) 
        {
            tickable.Ended += OnTickableEnded;
            _tickables.Add(tickable);
        }

        private void OnTickableEnded(ITickable tickable)
        {
            tickable.Ended -= OnTickableEnded;
            _tickables.Remove(tickable);
        }
    }

    public readonly struct DamagableCharacteristics
    {
        public readonly int MaxHealth;
        public readonly ArmorCharacteristics ArmorCharacteristics;

        public DamagableCharacteristics(int maxHealth, ArmorCharacteristics armorCharacteristics)
        {
            MaxHealth = maxHealth;
            ArmorCharacteristics = armorCharacteristics;
        }
    }
}