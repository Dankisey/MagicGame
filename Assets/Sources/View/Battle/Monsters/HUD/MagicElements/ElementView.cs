using UnityEngine;
using Game.Model;

namespace Game.View
{
    public abstract class ElementView : MonoBehaviour
    {
        public DamageElements DamageElement { get; protected set; }

        public virtual void Init() { }

        private void OnEnable()
        {
            Init();
        }
    }
}