using Game.Model;
using System;

namespace Game.Controller
{
    public class AttackTrigger
    {
        private readonly int _attackID; 

        public AttackTrigger(int attackID, AttackPerformer performer)
        {
            _attackID = attackID;
            ConnectWithPerformer(performer);
        }

        public event Action<int> Activated;

        public void Activate()
        {
            Activated?.Invoke(_attackID);
        }

        private void ConnectWithPerformer(AttackPerformer performer)
        {
            performer.AddTrigger(this);
        }
    }
}