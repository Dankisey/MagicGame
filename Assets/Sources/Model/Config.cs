using Game.Model;
using System;
using System.Runtime.ConstrainedExecution;
using Unity.Burst.CompilerServices;

public class Config 
{
    public class Characters
    {
        public class Player
        {
            public static readonly int MaxStamina = 100;
            public static readonly int MaxMana = 100;

            private static readonly int _maxHealth = 100 ;
            private static readonly int _physicalArmor = 10;
            private static readonly int _magicArmor = 15;

            public static readonly DamagableCharacteristics DamagableCharacteristics = new(_maxHealth, _physicalArmor, _magicArmor);
        }
    }

    public class Attacks
    {
        public class Slice
        {
            public static readonly int BaseDamage = 5;
            public static readonly int StaminaCost = 0;
            public static readonly int ManaCost = 0;
        }
    }

    public class RestorePotions
    {

    }
}