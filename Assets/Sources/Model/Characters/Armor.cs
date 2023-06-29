using System;
using System.Linq;

namespace Game.Model
{
    public sealed class Armor
    {
        private Defence[] _defences;

        public Armor(ArmorCharacteristics armorCharacteristics)
        {
            PhysicalDefence = new(armorCharacteristics.PhysicalDefence);
            AirDefence = new(armorCharacteristics.AirDefence);
            EarthDefence = new(armorCharacteristics.EarthDefence);
            FireDefence = new(armorCharacteristics.FireDefence);
            ThunderDefence = new(armorCharacteristics.ThunderDefence);
            WaterDefence = new(armorCharacteristics.WaterDefence);
            PureDefence = new();

            UpdateDefences();
        }

        public PhysicalDefence PhysicalDefence { get; private set; }
        public AirDefence AirDefence { get; private set; }
        public EarthDefence EarthDefence { get; private set; }
        public FireDefence FireDefence { get; private set; }
        public ThunderDefence ThunderDefence { get; private set; }
        public WaterDefence WaterDefence { get; private set; }
        public PureDefence PureDefence { get; private set; }

        public float GetModifiedDamage(Damage damage) 
        {
            float modifiedDamage = 0;

            if (damage.Elements.Count > 1)
            {
                for (int i = 0; i < damage.Elements.Count; i++)
                    modifiedDamage += ModifyDamage(damage, damage.Elements[i]);

                modifiedDamage /= damage.Elements.Count;
            }
            else
               modifiedDamage = ModifyDamage(damage, damage.Elements.FirstOrDefault());

            return modifiedDamage;
        }  

        private float ModifyDamage(Damage damage, DamageElements element) 
        {
            float modifiedDamage = 0;

            Defence defence = _defences.Where(defence => defence.ModifyingElement == element).FirstOrDefault();
            modifiedDamage = defence.ModifyDamage(damage);

            return modifiedDamage;
        }

        private void UpdateDefences()
        {
            _defences = new Defence[] { PhysicalDefence, AirDefence, EarthDefence, FireDefence, ThunderDefence, WaterDefence, PureDefence };
        }
    }

    public readonly struct ArmorCharacteristics
    {
        public readonly int PhysicalDefence;
        public readonly int AirDefence;
        public readonly int EarthDefence;
        public readonly int FireDefence;
        public readonly int ThunderDefence;
        public readonly int WaterDefence;

        public ArmorCharacteristics(int physicalDefence, int airDefence, int earthDefence, int fireDefence, int thunderDefence, int waterDefence)
        {
            PhysicalDefence = physicalDefence;
            AirDefence = airDefence;
            EarthDefence = earthDefence;
            FireDefence = fireDefence;
            ThunderDefence = thunderDefence;
            WaterDefence = waterDefence;

            ValidateDefences();
        }

        private void ValidateDefences()
        {
            Validate(PhysicalDefence);
            Validate(AirDefence);
            Validate(EarthDefence);
            Validate(FireDefence);
            Validate(ThunderDefence);
            Validate(WaterDefence);
        }

        private void Validate(int defence)
        {
            if (defence < Config.Characters.MinDefence)
                throw new ArgumentOutOfRangeException(nameof(defence));

            else if (defence > Config.Characters.MaxDefence)
                throw new ArgumentOutOfRangeException(nameof(defence));
        }
    }
}