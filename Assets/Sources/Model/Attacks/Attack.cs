using System.Data;

namespace Game.Model
{
    public abstract class Attack 
    {
        public Attack(AttackCharachteristics charachteristics)
        {
            Name = charachteristics.Name;
            Damage = charachteristics.Damage;
            ManaCost = charachteristics.ManaCost;
            StaminaCost = charachteristics.StaminaCost;
            ID = charachteristics.ID;
        }

        public readonly TargetType Type;
        public readonly Damage Damage;
        public readonly int StaminaCost;
        public readonly int ManaCost;
        public readonly int ID;
        public readonly string Name;
    }

    public struct AttackCharachteristics
    {
        public readonly TargetType Type;
        public readonly Damage Damage;
        public readonly int StaminaCost;
        public readonly int ManaCost;
        public readonly string Name;
        public readonly int ID;
        
        public AttackCharachteristics(string name, Damage damage, int manaCost, int staminaCost, int id, TargetType type)
        {
            Name = name;
            Damage = damage;
            ManaCost = manaCost;
            StaminaCost = staminaCost;
            ID = id;
            Type = type;
        }
    }

    public interface IAttackPerformer
    {
        void Perform(int attackID);
    }

    public enum TargetType
    {
        Solo,
        Multi
    }

    public enum AttackIDs
    {
        Slice = 1,
        FireBall
    }
}