using System.Collections.Generic;
using System.Linq;
using System;

namespace Game.Model
{
    public class MagicCombiner
    {
        //private MagicEffect[] _effects;
        //private List<Element> _combo;
        //private Spell _currentSpell;
        //private bool _spellIsInProgress;

        //public event Action<MagicEffects[]> ComboChanged;
        //public event Action<Attack> AttackCompleted;

        //public void EndAttack()
        //{
        //    if (TryGetAttack(out Attack attack))
        //        AttackCompleted.Invoke(attack);
        //}

        //private bool TryGetAttack(out Attack attack)
        //{
        //    Spell spell = GetSpell();
        //    attack = new(spell);

        //    if (_combo.Count == 0)
        //        return false;

        //    _spellIsInProgress = false;

        //    return true;
        //}

        //public bool TryAddElement(Element element)
        //{
        //    if(_spellIsInProgress == false)
        //        PrepareNewSpell();

        //    if (_effects.Length == Config.Magic.MaxEffectsInSpell)
        //        return false;

        //    if (CheckMatchingRules(element) == false)
        //        return false;

        //    AddElement(element);

        //    return true;
        //}

        //private void PrepareNewSpell()
        //{
        //    _effects = new MagicEffect[0];
        //    _spellIsInProgress = true;
        //    _currentSpell = new();
        //    _combo = new();
        //}

        //private Spell GetSpell()
        //{
        //    Spell spell = new();

        //    if (IsTriplet())
        //    {
        //        spell = _combo[0].GetTriplet();

        //        return spell;
        //    }

        //    foreach (var effect in _effects)
        //        spell.AddEffect(effect);

        //    return spell;
        //}

        //private bool CheckMatchingRules(Element elementToCheck)
        //{
        //    bool isMatching = true;

        //    foreach (var element in _effects)
        //        isMatching &= element.CheckMatching(elementToCheck);

        //    return isMatching;
        //}

        //private void AddElement(Element element)
        //{
        //    FirstTierEffect effect = element.GetEffect();
        //    _effects = GetEffects(effect);
        //    _combo.Add(element);

        //    InvokeComboChangedEvent();
        //}

        //private void InvokeComboChangedEvent()
        //{
        //    MagicEffects[] types = new MagicEffects[_effects.Length];

        //    for (int i = 0; i < _effects.Length; i++)
        //        types[i] = _effects[i].Effect;

        //    ComboChanged?.Invoke(types);
        //}

        //private MagicEffect[] GetEffects(FirstTierEffect effect)
        //{
        //    HashSet<MagicEffect> elements = new();

        //    foreach (var item in _effects)
        //    {
        //        MagicEffect[] currentEffects = item.Combine(effect, out AugmentedStatus status);

        //        for (int i = 0; i < currentEffects.Length; i++)
        //            elements.Add(currentEffects[i]);

        //        _currentSpell.Augment((int)status);
        //    }

        //    return elements.ToArray();
        //}

        //private bool IsTriplet()
        //{
        //    if (_combo.Count != Config.Magic.MaxEffectsInSpell)
        //        return false;

        //    for (int i = 1; i < Config.Magic.MaxEffectsInSpell; i++)
        //    {
        //        if (_combo[i].Type != _combo[i-1].Type)
        //            return false;
        //    }

        //    return true;
        //}
    }

    public enum MagicEffects
    {
        //1st Tier

        Air,
        Earth,
        Water,
        Fire,
        Thunder,

        //2nd Tier

        Steam,             //water + fire
        Lava,              //earth + fire

        Mud,               //earth + water
        Cold,              //air + water

        Dust,              //air + earth

        //Triplets

        AirTriplet,
        EarthTriplet,
        WaterTriplet,
        FireTriplet,
        ThunderTriplet,
    }
}