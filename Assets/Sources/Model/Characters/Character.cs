using System;
using System.Collections.Generic;

namespace Game.Model
{
    public abstract class Character
    {
        private readonly List<ITickable> _tickables;
        private readonly List<TickDamage> _tickDamages;
        private readonly List<Debuff> _debuffs;

        public readonly Health Health;
        public readonly Armor Armor;

        public Character(DamagableCharacteristics characteristics)
        {
            Health = new(characteristics.MaxHealth);
            Armor = new(characteristics.ArmorCharacteristics);
            _tickables= new();
            _tickDamages= new();
        }

        public event Action<Character> Died;
        public event Action<float> DamageTaken;

        public bool IsAlive => Health.IsAlive;

        public void Tick()
        {
            foreach (var tickDamage in _tickDamages)
                TakeDamage(tickDamage);

            foreach (var tickable in _tickables)
                tickable.Tick();    
        }

        public void ApplyAttack(Attack attack)
        {
            foreach (var debuff in attack.Debuffs)
            {
                if (TryUpdateDebuff(debuff) == false)               
                    AddTickable(debuff);              
            }

            AddTickable(attack.TickDamage);
            TakeDamage(attack.Damage);
        }

        private bool TryUpdateDebuff(Debuff newDebuff)
        {         
            Debuff toUpdate = null;
            bool exist = false;

            foreach (var debuff in _debuffs)
            {
                if (newDebuff.Type == debuff.Type)
                {
                    toUpdate = debuff;
                    exist = true;
                    break;
                }
            }

            if (exist)
            {
                toUpdate.ForceEnd();
                AddTickable(newDebuff);
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
            _tickables.Add(tickable);
            AddTickable((dynamic) tickable);
        }

        private void AddTickable(Debuff debuff)
        {
            debuff.Ended += OnDebuffEnded;
            _debuffs.Add(debuff);
        }

        private void AddTickable(TickDamage tickDamage)
        {
            tickDamage.Ended += OnTickDamageEnded;
            _tickDamages.Add(tickDamage);
        }

        private void OnDebuffEnded(Debuff debuff)
        {
            debuff.Ended -= OnDebuffEnded;
            _debuffs.Remove(debuff);
            _tickables.Remove(debuff);
        }

        private void OnTickDamageEnded(TickDamage tickDamage)
        {
            tickDamage.Ended -= OnTickDamageEnded;
            _tickDamages.Remove(tickDamage);
            _tickables.Remove(tickDamage);
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