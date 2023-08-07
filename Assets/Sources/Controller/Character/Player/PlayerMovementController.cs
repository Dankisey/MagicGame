using UnityEngine;

namespace Game.Controller
{
    public class PlayerMovementController : MovementController
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        protected override void SetAxises()
        {
            _horisontalMovementVector = Input.GetAxis(Horizontal);
            _verticalMovementVector = Input.GetAxis(Vertical);
        }
    }
}