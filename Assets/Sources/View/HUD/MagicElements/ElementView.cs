using UnityEngine.UI;
using UnityEngine;
using Game.Model;

namespace Game.View
{
    [RequireComponent(typeof(Image))]
    public abstract class ElementView : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteToSet;
        [SerializeField] private Image _image;

        public DamageElements DamageElement { get; protected set; }

        protected abstract void Init();

        private void OnEnable()
        {
            _image.sprite = _spriteToSet;
            Init();
        }
    }
}