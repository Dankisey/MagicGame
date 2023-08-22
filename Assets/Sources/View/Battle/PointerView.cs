using UnityEngine;

namespace Game.View
{
    public class PointerView : MonoBehaviour
    {
        [SerializeField] private Transform _baseParent;
        [SerializeField] private Transform _pointer;

        public void ChangePosition(Transform parent, Transform target)
        {
            _pointer.gameObject.SetActive(true);
            _pointer.SetParent(parent);
            _pointer.position = target.position;
        }

        public void Disable()
        {
            _pointer.gameObject.SetActive(false);
            _pointer.SetParent(_baseParent);
        }
    }
}