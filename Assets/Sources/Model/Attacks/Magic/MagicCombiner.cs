using System.Collections.Generic;
using System.Linq;

namespace Game.Model
{
    public class MagicCombiner
    {
        private ICombineable[] _elements;

        public Spell Combine(Element[] elements)
        {
            ConvertToSpells(elements);

            if(CheckForTriplet())
                return GetTriplet();

            return GetCombination();
        }

        private void ConvertToSpells(Element[] elements)
        {
            _elements = new ICombineable[elements.Length];

            for (int i = 0; i < elements.Length; i++)         
                _elements[i] = elements[i].GetSpell();           
        }

        private bool CheckForTriplet()
        {
            if (_elements.Length != Config.Attacks.Magic.MaxElementsInSpell)
                return false;

            HashSet<ICombineable> elements = _elements.ToHashSet();

            return elements.Count == 1;
        }

        private Spell GetCombination()
        {
            ICombineable combination = _elements[0];

            for (int i = 1; i < _elements.Length; i++)           
                combination = combination.Combine(_elements[i]);            

            return combination as Spell;
        }

        private Spell GetTriplet()
        {
            return (_elements[0] as ITripletReturner).GetTriplet();
        }
    }
}