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

        public class Magic
        {
            public static readonly int MaxEffectsInSpell = 3;
            public static readonly float AugmentedMultiplier = 0.8f;
            public static readonly int PhysicalTickDamage = 0;
            public static readonly int PhysicalTickCount = 0;

            public class Air
            {
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 20;
                public static readonly TargetType TargetType = TargetType.Solo;
                
                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }

            public class Earth
            {
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 20;
                public static readonly TargetType TargetType = TargetType.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }

            public class Fire
            {
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 5;
                public static readonly int Damage = 20;
                public static readonly TargetType TargetType = TargetType.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }

            public class Thunder
            {
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 5;
                public static readonly int Damage = 20;
                public static readonly TargetType TargetType = TargetType.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }

            public class Water
            {
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 20;
                public static readonly TargetType TargetType = TargetType.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }
        }

        public class RestorePotions
        {
            public class Large
            {
                public static readonly int RestoreAmount = 50;
            }

            public class Medium
            {
                public static readonly int RestoreAmount = 25;
            }

            public class Small
            {
                public static readonly int RestoreAmount = 10;
            }
        }
    }
}