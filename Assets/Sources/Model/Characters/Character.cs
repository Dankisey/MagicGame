using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Game.Model
{
    public abstract class Character
    {
        private readonly List<ITickable> _tickables;
        private readonly List<ITickable> _toDelete;
        private readonly List<TickDamage> _tickDamages;
        private readonly List<Debuff> _debuffs;

        public readonly Health Health;
        public readonly Armor Armor;

        public Character(DamagableCharacteristics characteristics)
        {
            Health = new(characteristics.MaxHealth);
            Armor = new(characteristics.ArmorCharacteristics);
            _debuffs = new();
            _toDelete = new();
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

            foreach (var tickable in _toDelete)          
                _tickables.Remove(tickable);

            _toDelete.Clear();
        }

        public void ApplyAttack(Attack attack)
        {
            foreach (var debuff in attack.Debuffs)
            {
                if (TryUpdateDebuff(debuff) == false)               
                    AddDebuff(debuff);              
            }

            AddTickDamage(attack.TickDamage);
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
                AddDebuff(newDebuff);
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

        private void AddDebuff(Debuff debuff)
        {
            debuff.Ended += OnDebuffEnded;
            _tickables.Add(debuff);
            _debuffs.Add(debuff);
        }

        private void AddTickDamage(TickDamage tickDamage)
        {
            if (tickDamage.TickAmount == 0)
                return;

            tickDamage.Ended += OnTickDamageEnded;
            _tickDamages.Add(tickDamage);
            _tickables.Add(tickDamage);
        }

        private void OnDebuffEnded(Debuff debuff)
        {
            debuff.Ended -= OnDebuffEnded;
            _debuffs.Remove(debuff);
            _toDelete.Add(debuff);
        }

        private void OnTickDamageEnded(TickDamage tickDamage)
        {
            tickDamage.Ended -= OnTickDamageEnded;
            _tickDamages.Remove(tickDamage);
            _toDelete.Add(tickDamage);
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