namespace Game.Model
{
    public class Config
    {
        public class Characters
        {
            public static readonly int MaxDefence = 100;
            public static readonly int MinDefence = -MaxDefence;
            public static readonly int BasePureDefence = 0;

            public class Level
            {
                public static readonly int MaxValue = 200;
                public static readonly int BaseLevelCost = 1000;
                public static readonly int PartRecievingByKill = 10;
                public static readonly float MultiplierByLevel = 0.1f;
            }

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
                public class Attacks
                {
                    private class BiteCharacteristics
                    {
                        private static readonly float _damageAmount = 10;
                        private static readonly PhysicalDamage _damage = new(_damageAmount, DamageElements.Physical);

                        private static readonly float _tickDamageAmount = 0;
                        private static readonly int _tickAmount = 0;
                        private static readonly TickDamage _tickDamage = new(_tickDamageAmount, DamageElements.None, _tickAmount);

                        private static readonly TargetTypes _targetType = TargetTypes.Solo;

                        public static readonly Attack Attack = new(_damage, _tickDamage, new EmptyDebuff(), _targetType);
                    }             
                    
                    public static readonly EnemyAttack Bite = new(EnemyAttackRarity.First, BiteCharacteristics.Attack);
                }

                public class Bat
                {
                    private static readonly int _maxHealth = 15;

                    private static readonly int _physicalDefence = 0;
                    private static readonly int _airDefence = 0;
                    private static readonly int _earthDefence = 0;
                    private static readonly int _fireDefence = 0;
                    private static readonly int _thunderDefence = 0;
                    private static readonly int _waterDefence = 0;

                    private static readonly ArmorCharacteristics _armor =
                        new(_physicalDefence, _airDefence, _earthDefence, _fireDefence, _thunderDefence, _waterDefence);

                    public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _armor);
                    public static EnemyAttack[] Attacks = new EnemyAttack[1] { Enemies.Attacks.Bite };
                }
            }
        }

        public class Magic
        {
            public static readonly int ElementsForTriplet = 3;
            public static readonly int MaxEffectsInSpell = 3;
            public static readonly float AugmentedMultiplier = 0.8f;

            public class None
            {
                public static readonly int Cost = 0;
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 0;
                public static readonly TargetTypes TargetType = TargetTypes.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 0;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
                }
            }

            public class Air
            {
                public static readonly int Cost = 5;
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 5;
                public static readonly TargetTypes TargetType = TargetTypes.Solo;
                
                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
                }
            }

            public class Earth
            {
                public static readonly int Cost = 5;
                public static readonly int TickCount = 0;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 5;
                public static readonly TargetTypes TargetType = TargetTypes.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
                }
            }

            public class Fire
            {
                public static readonly int Cost = 5;
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 5;
                public static readonly int Damage = 5;
                public static readonly TargetTypes TargetType = TargetTypes.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
                }
            }

            public class Thunder
            {
                public static readonly int Cost = 5;
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 5;
                public static readonly int Damage = 5;
                public static readonly TargetTypes TargetType = TargetTypes.Multi;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
                }
            }

            public class Water
            {
                public static readonly int Cost = 5;
                public static readonly int TickCount = 3;
                public static readonly int TickDamage = 0;
                public static readonly int Damage = 5;
                public static readonly TargetTypes TargetType = TargetTypes.Solo;

                public class Triplet
                {
                    public static readonly float Multiplier = 3f;
                    public static readonly int TickDamage = 0;
                    public static readonly int TickCount = 0;
                    public static readonly TargetTypes TargetType = TargetTypes.Solo;
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