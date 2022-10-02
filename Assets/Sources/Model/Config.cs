namespace Game.Model
{
    public class Config
    {
        public class Characters
        {
            public class Player
            {
                public static readonly int MaxStamina = 100;
                public static readonly int MaxMana = 100;

                private static readonly int _maxHealth = 100;
                private static readonly int _physicalArmor = 10;
                private static readonly int _magicArmor = 15;

                public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _physicalArmor, _magicArmor);
            }

            public class Enemies
            {
                public class Bat
                {
                    private static readonly int _maxHealth = 20;
                    private static readonly int _physicalArmor = 5;
                    private static readonly int _magicArmor = 5;

                    public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _physicalArmor, _magicArmor);

                }
            }
        }

        public class Attacks
        {
            public static class Slice
            {
                private static readonly string _name = nameof(Slice);
                private static readonly int _baseDamage = 5;
                private static readonly int _manaCost = 0;
                private static readonly int _staminaCost = 0;

                public static readonly AttackCharachteristics AttackCharachteristics = new(_name, new PhysicalDamage(_baseDamage), _manaCost, _staminaCost, (int)AttackIDs.Slice, TargetType.Solo);
            }

            public static  class FireBall
            {
                private static readonly string _name = nameof(FireBall);
                private static readonly int _baseDamage = 10;
                private static readonly int _manaCost = 10;
                private static readonly int _staminaCost = 0;

                public static readonly AttackCharachteristics AttackCharachteristics = new(_name, new MagicDamage(_baseDamage), _manaCost, _staminaCost, (int)AttackIDs.FireBall, TargetType.Solo);
            }
        }

        public class RestorePotions
        {

        }
    }
}