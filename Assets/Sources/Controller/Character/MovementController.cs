using System;
using UnityEngine;

namespace Game.Controller
{
    public abstract class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        protected float _horisontalMovementVector = 0f;
        protected float _verticalMovementVector = 0f;

        private bool _isMoving = true;

        public event Action<Vector2> DirectionChanged;

        public void StopMoving()
        {
            _horisontalMovementVector = 0f;
            _verticalMovementVector = 0f;
            _isMoving = false;
        }

        public void ContinueMoving()
        {
            _isMoving = true;
        }

        protected abstract void SetAxises();

        private Vector2 GetDirection()
        {
            float absHorisontal = Mathf.Abs(_horisontalMovementVector);
            float absVertival = Mathf.Abs(_verticalMovementVector);
            float x, y;

            if (absHorisontal >= absVertival)
            {
                x = _horisontalMovementVector;
                y = 0;
            }
            else
            {
                x = 0;
                y = _verticalMovementVector;
            }

            return new(x, y);
        }

        private void MoveCharacter()
        {
            Vector2 direction = GetDirection();
            DirectionChanged?.Invoke(direction);
            float step = _speed * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + direction * step);
        }

        private void Update()
        {
            if (_isMoving)
                SetAxises();          
        }

        private void FixedUpdate()
        {
            MoveCharacter();
        }
    }
}