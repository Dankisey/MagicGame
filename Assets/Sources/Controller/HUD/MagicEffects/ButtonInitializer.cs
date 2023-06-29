using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controller
{
    [RequireComponent(typeof(MagicEffectButton))]
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]

    public abstract class ButtonInitializer : MonoBehaviour
    {
        private MagicEffectButton _magicEffectButton;
        private Button _button;

        protected MagicEffect MagicEffect;

        public virtual void InitSelf()
        {
            _magicEffectButton = GetComponent<MagicEffectButton>();
            _button = GetComponent<Button>();
        }

        public void InitButton()
        {     
            _magicEffectButton.Init(_button, MagicEffect);
        }
    }
}