using UnityEngine;

namespace Game.View
{
    public class PointerView : MonoBehaviour
    {
        [SerializeField] private Transform _pointer;

        public void ChangePosition(Transform parent, Transform target)
        {
            _pointer.SetParent(parent);
            _pointer.position = target.position;
        }
    }
}