using System.Collections.Generic;
using System;

namespace Game.Model
{
    public abstract class Character
    {
        public readonly Health Health;
        public readonly Armor Armor;

        private readonly Dictionary<TickDamage, float> _tickDamages;
        private readonly List<Debuff> _debuffs;
        private readonly List<ITickable> _tickables;
        private readonly List<ITickable> _toDelete;
        private float _tickDamage;

        public Character(DamagableCharacteristics characteristics)
        {
            Health = new(characteristics.MaxHealth);
            Armor = new(characteristics.ArmorCharacteristics);
            _tickDamages= new();
            _tickables= new();
            _debuffs = new();
            _toDelete = new();
            _tickDamage = 0;
        }

        public event Action<Character> Died;
        public event Action<float> DamageTaken;

        public bool IsAlive => Health.IsAlive;

        public void Tick()
        {
            if (_tickDamage > 0)
                ApplyDamage(_tickDamage);

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
            float damage = Armor.GetModifiedDamage(tickDamage);
            _tickDamage += damage;
            _tickDamages.Add(tickDamage, damage);
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
            _tickDamages.Remove(tickDamage, out float damage);
            _tickDamage -= damage;
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