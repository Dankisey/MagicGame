using UnityEngine;

namespace Game.View
{
    public class HUDPanel : MonoBehaviour
    {
        [SerializeField] private HUDPanel[] _toCloseOnOpen;
        [SerializeField] private HUDPanel[] _openWithMe;

        public void Open()
        {
            gameObject.SetActive(true);
            CloseOthers();
            OpenWithMe();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void CloseOthers()
        {
            foreach (var panel in _toCloseOnOpen)
                panel.Close();
        }

        private void OpenWithMe()
        {
            foreach (var panel in _openWithMe)
                panel.Open();
        }
    }
}