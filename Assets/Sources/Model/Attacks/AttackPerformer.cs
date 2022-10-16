using Game.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using static Game.Model.Config;

namespace Game.Model
{
    public class AttackPerformer
    {
        private readonly HashSet<Attack> _availableAttacks;
        private readonly List<AttackTrigger> _triggers;
        private readonly Stamina _stamina;
        private readonly Mana _mana;
        private Battle _battle;

        public AttackPerformer(Mana mana, Stamina stamina)
        {
            _availableAttacks = new();
            _triggers = new();
            _stamina = stamina;
            _mana = mana;
        }

        public event Action<int> AttackAdded;

        public void InitBattle(Battle battle)
        {
            _battle = battle;           
        }

        public void AddAttack<T>(T attack) where T : Attack
        {
            _availableAttacks.Add(attack);
            AttackAdded?.Invoke(attack.ID);
        }

        public void AddTrigger(AttackTrigger trigger)
        {
            _triggers.Add(trigger);
            trigger.Activated += Perform;
        }

        private void Perform(int attackID)
        {
            Attack attack = CreateAttack(attackID);

            if (TryAttack(attack))         
                _battle.SendPlayerAttack(attack);         
        }

        private Attack CreateAttack(int id)
        {
            Attack attack = _availableAttacks.FirstOrDefault(attack => attack.ID == id);

            if (attack == null)
                throw new NullReferenceException("attack isnt exist in aviable attacks list");

            return attack;
        }

        private bool TryAttack(Attack attack)
        {
            int staminaCost = attack.StaminaCost;
            int manaCost = attack.ManaCost;

            if (staminaCost > _stamina.Value)
                return false;
            if (manaCost > _mana.Value)
                return false;

            _stamina.TrySpend(staminaCost);
            _mana.TrySpend(manaCost);
            return true;
        }
    }
}