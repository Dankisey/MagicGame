using UnityEngine.UI;
using UnityEngine;
using Game.View;

namespace Game.Controller
{
    public class TextBubble : MonoBehaviour
    {
        [SerializeField] private TextWriter _writer;
        [SerializeField] private Button _interactButton;
        [SerializeField] private Image _image;

        [SerializeField] protected string[] Texts;
        protected int CurrentSlide;
        protected int StartSlide = 0;

        public virtual void Interact()
        {
            if (_writer.TextInProgress)
                _writer.SkipAnimation();
            else if (CurrentSlide + 1 <= Texts.Length - 1)
                ShowNext();
        }

        public virtual void Enable()
        {
            gameObject.SetActive(true);
            _writer.ChangeText(Texts[CurrentSlide]);
            _interactButton.interactable = true;
        }

        public virtual void Disable()
        {
            CurrentSlide = StartSlide;
            gameObject.SetActive(false);
        }

        protected virtual void OnLastMessegeShowed()
        {
            _interactButton.interactable = false;
            _writer.Changed -= OnLastMessegeShowed;
        }

        protected virtual void Subscribe()
        {
            _interactButton.onClick.AddListener(Interact);
        }

        protected virtual void Unsubscribe() 
        {
            _interactButton.onClick.RemoveListener(Interact);
        }

        protected virtual void OnStart()
        {
            CurrentSlide = StartSlide;
            Disable();
        }

        private void ShowNext()
        {
            CurrentSlide++;

            if (CurrentSlide == Texts.Length - 1)
                _writer.Changed += OnLastMessegeShowed;

            _writer.ChangeText(Texts[CurrentSlide]);
        }

        private void Start()
        {
            OnStart();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}