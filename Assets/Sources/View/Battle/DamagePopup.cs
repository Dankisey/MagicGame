using UnityEngine;
using TMPro;

namespace Game.View
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private GameObject _parent;

        public void SetText(string text)
        {
            _textMesh.SetText(text);
        }

        public void Destroy()
        {
            Destroy(_parent);
        }
    }
}