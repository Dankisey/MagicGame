using Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controller
{
    public class TestNPCBubble : TextBubble
    {
        [SerializeField] private int AfterDialogeStartSlide;
        [SerializeField] private Button _restoreButton;

        public override void Enable()
        {
            base.Enable();
            _restoreButton.gameObject.SetActive(false);
        }

        protected override void OnLastMessegeShowed()
        {
            base.OnLastMessegeShowed();
            _restoreButton.gameObject.SetActive(true);
            StartSlide = AfterDialogeStartSlide;
        }

        protected override void OnStart()
        {
            base.OnStart();
            _restoreButton.gameObject.SetActive(false);
        }

        protected override void Subscribe()
        {
            base.Subscribe();

            if (AfterDialogeStartSlide >= Texts.Length)
                throw new System.ArgumentOutOfRangeException($"{nameof(AfterDialogeStartSlide)} is more than {nameof(Texts)} elements amount");

            _restoreButton.onClick.AddListener(RestorePlayerCharacteristics);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            _restoreButton.onClick.RemoveListener(RestorePlayerCharacteristics);
        }

        private void RestorePlayerCharacteristics()
        {
            Player.Instance.Stamina.Restore(1000);
            Player.Instance.Health.Restore(1000);
            Player.Instance.Mana.Restore(1000);
            _restoreButton.gameObject.SetActive(false);
        }
    }
}