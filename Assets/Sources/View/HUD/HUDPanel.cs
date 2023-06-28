using UnityEngine;

namespace Game.View
{
    public class HUDPanel : MonoBehaviour
    {
        [SerializeField] private HUDPanel[] _toCloseOnOpen;
        [SerializeField] private HUDPanel[] _toOpenOnClose;

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void OpenOthers()
        {
            foreach (var panel in _toOpenOnClose)
                panel.Open();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void CloseOthers()
        {
            foreach (var panel in _toCloseOnOpen)
                panel.Close();
        }
    }
}