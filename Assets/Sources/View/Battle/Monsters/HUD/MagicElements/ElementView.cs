using UnityEngine;
using Game.Model;

namespace Game.View
{
    public abstract class ElementView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystemPrefab;

        public ParticleSystem ParticleSystemPrefab => _particleSystemPrefab;
        public abstract DamageElements DamageElement { get;}
    }
}