using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using System;

namespace Game.View
{
    public class MagicElementView : MonoBehaviour
    {
        [SerializeField] private Sprite _spriteToSet;
        [SerializeField] private Button _selfButton;
        [SerializeField] private Image _selfImage;

        //private Element _selfElement;

        //public event Action<Element> ButtonClicked;

        //private void OnButtonClick()
        //{
        //    ButtonClicked?.Invoke(_selfElement);
        //}

        //private void OnEnable()
        //{
        //    _selfButton.onClick.AddListener(OnButtonClick);
        //    _selfImage.sprite = _spriteToSet;
        //}

        //private void OnDisable()
        //{
        //    _selfButton.onClick.RemoveListener(OnButtonClick);
        //}
    }
}