using UnityEngine;

namespace Game.Controller
{
    public class PlayerInteractorController : MonoBehaviour
    {
        private IInteractable _current = null;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable interactable))
            {
                _current = interactable;
                _current.ShowInteractable();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IInteractable _))
            {
                _current.StopInteract();
                _current = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _current != null)          
                _current.Interact();            
        }
    }
}