using TMPro;
using UnityEngine;

namespace Game.Controller
{
    public class InteractableNPC : MonoBehaviour, IInteractable
    {
        [SerializeField] private TMP_Text _interactableText;
        [SerializeField] private TextBubble _textBubble;

        private bool _textBubbleIsOn = false;

        public void StopInteract()
        {
            HidePopup();
            _interactableText.enabled = false;
        }

        public void Interact()
        {
            _interactableText.enabled = false;

            if (_textBubbleIsOn == false)
                ShowPopUp();
            else           
                _textBubble.Interact();           
        }

        public void ShowInteractable()
        {
            _interactableText.enabled = true;
        }

        private void ShowPopUp()
        {
            _textBubble.Enable();
            _textBubbleIsOn = true;
        }

        private void HidePopup()
        {
            _textBubble.Disable();
            _textBubbleIsOn = false;
        }

        private void OnEnable()
        {
            _interactableText.enabled = false;   
        }
    }
}