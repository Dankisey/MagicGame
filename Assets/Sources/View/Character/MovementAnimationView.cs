using Game.Controller;
using UnityEngine;

namespace Game.View
{
    public class MovementAnimationView : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private Animator _animator;

        private const string LastHorizontal = nameof(LastHorizontal);
        private const string LastVertical = nameof(LastVertical);
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);
        private const string Speed = nameof(Speed);

        private void SetDefaultValues()
        {
            _animator.SetFloat(LastHorizontal, 0);
            _animator.SetFloat(LastVertical, 0);
            _animator.SetFloat(Horizontal, 0);
            _animator.SetFloat(Vertical, -1);
            _animator.SetFloat(Speed, 0);
        }

        private void OnDirectionChanged(Vector2 movement)
        {
            _animator.SetFloat(Horizontal, movement.x);
            _animator.SetFloat(Vertical, movement.y);
            _animator.SetFloat(Speed, movement.magnitude);

            if (movement.x != 0 || movement.y != 0)
            {
                _animator.SetFloat(LastHorizontal, movement.x);
                _animator.SetFloat(LastVertical, movement.y);
            }
        }

        private void OnEnable()
        {
            SetDefaultValues();
            _movementController.DirectionChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            _movementController.DirectionChanged -= OnDirectionChanged;
        }
    }
}