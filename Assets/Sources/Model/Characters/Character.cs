using System.Collections.Generic;
using System.Linq;
using System;

namespace Game.Model
{
    public abstract class Character
    {
        public readonly DamageBuffsContainer DamageBuffsContainer;
        public readonly Health Health;
        public readonly Armor Armor;
        public readonly Level Level;

        private readonly Dictionary<TickDamage, float> _tickDamages;
        private readonly List<Debuff> _debuffs;
        private readonly List<ITickable> _tickables;
        private readonly List<ITickable> _toDelete;
        private float _tickDamage;

        public Character(DamagableCharacteristics characteristics, Level level)
        {
            Health = new(characteristics.MaxHealth);
            Armor = new(characteristics.ArmorCharacteristics);
            Level = level;
            _tickDamages = new();
            _tickables = new();
            _debuffs = new();
            _toDelete = new();
            _tickDamage = 0;
        }

        public event Action<Character> Died;
        public event Action<float> DamageTaken;

        public bool IsAlive => Health.IsAlive;

        public void Tick()
        {
            if (IsAlive == false)          
                return;     

            if (_tickDamage > 0)
                ApplyDamage(_tickDamage);

            foreach (var tickable in _tickables)
                tickable.Tick();

            RemoveExpireds();
        }

        public void ApplyAttack(Attack attack)
        {
            foreach (var debuff in attack.Debuffs)
            {
                if (TryUpdateDebuff(debuff) == false)               
                    AddDebuff(debuff);              
            }

            AddTickDamages(attack.TickDamages);
            TakeDamage(attack.Damages);
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

        private void TakeDamage(Damage[] damages)
        {
            float modifiedDamage = 0;

            foreach (Damage damage in damages)
                modifiedDamage += Armor.GetModifiedDamage(damage);

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
            ClearTickables();
            RemoveExpireds();
            Died?.Invoke(this);
            return true;
        }

        private void ClearTickables()
        {
            TickDamage[] tickDamages = _tickDamages.Keys.ToArray();

            foreach (var tickDamage in tickDamages)
                tickDamage.ForceEnd();

            foreach (var debuff in _debuffs)
                debuff.ForceEnd();
        }

        private void RemoveExpireds()
        {
            foreach (var tickable in _toDelete)
                _tickables.Remove(tickable);

            _toDelete.Clear();
        }

        private void AddDebuff(Debuff debuff)
        {
            debuff.Ended += OnDebuffEnded;
            _tickables.Add(debuff);
            _debuffs.Add(debuff);
        }

        private void AddTickDamages(TickDamage[] tickDamages)
        {
            foreach (TickDamage tickDamage in tickDamages)
                AddTickDamage(tickDamage);
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