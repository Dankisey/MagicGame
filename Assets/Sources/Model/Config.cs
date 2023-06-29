namespace Game.Model
{
    public class Config
    {
        public class Characters
        {
            public static readonly int MaxDefence = 100;
            public static readonly int MinDefence = -MaxDefence;
            public static readonly int BasePureDefence = 0;

            public class Player
            {
                public static readonly int MaxStamina = 100;
                public static readonly int MaxMana = 100;
                private static readonly int _maxHealth = 100;

                private static readonly int _physicalDefence = 5;
                private static readonly int _airDefence = 5;
                private static readonly int _earthDefence = 5;
                private static readonly int _fireDefence = 5;
                private static readonly int _thunderDefence = 5;
                private static readonly int _waterDefence = 5;

                private static readonly ArmorCharacteristics _basicArmor =
                    new(_physicalDefence, _airDefence, _earthDefence, _fireDefence, _thunderDefence, _waterDefence);

                public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _basicArmor);
            }

            public class Enemies
            {
                public class Bat
                {
                    private static readonly int _maxHealth = 20;

                    private static readonly int _physicalDefence = 0;
                    private static readonly int _airDefence = 0;
                    private static readonly int _earthDefence = 0;
                    private static readonly int _fireDefence = 0;
                    private static readonly int _thunderDefence = 0;
                    private static readonly int _waterDefence = 0;

                    private static readonly ArmorCharacteristics _armor =
                        new(_physicalDefence, _airDefence, _earthDefence, _fireDefence, _thunderDefence, _waterDefence);

                    public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _armor);
                }
            }
        }

        public class Magic
        {
            public static readonly int ElementsForTriplet = 3;
            public static readonly int MaxEffectsInSpell = 3;
            public static readonly float AugmentedMultiplier = 0.8f;
            public static readonly int PhysicalTickDamage = 0;
            public static readonly int PhysicalTickCount = 0;

            public class None
            {
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 0;
                public static readonly TargetType TargetType = TargetType.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 0;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetType TargetType = TargetType.Solo;
                }
            }

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