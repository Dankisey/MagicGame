using UnityEngine;

namespace Game.Controller
{
    public class CameraFollowingController : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _speedByDistance;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _maxSpeed;

        private float _offsetMagnitude => _offset.magnitude;

        private Vector3 GetDirection()
        {
            Vector2 difference = _target.position - _camera.position;
            float absX = Mathf.Abs(difference.x);
            float absY = Mathf.Abs(difference.y);

            float x = absX > _offset.x ? difference.x : 0;
            float y = absY > _offset.y ? difference.y : 0;

            return new Vector3(x, y);
        }

        private void Move()
        {
            Vector3 direction = GetDirection();
            float distance = direction.magnitude - _offsetMagnitude;
            direction.Normalize();

            Vector3 movement = _maxSpeed * _speedByDistance.Evaluate(distance) * direction;

            _camera.position += movement * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}