using Game.Interfaces.Player;
using System;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerMovement : IPlayerMovement
    {
        [Inject] private readonly CharacterController _characterController;
        [Inject] private readonly GravitySettings _gravitySettings;

        private Vector3 _velocity; 

        public void Move(Vector2 direction, float moveSpeed)
        {
            Vector3 move = _characterController.transform.forward * direction.y + _characterController.transform.right * direction.x;

            _characterController.Move(moveSpeed * Time.deltaTime * move);
        }

        public void Jump(float jumpHeight)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravitySettings.Gravity);

            _characterController.Move(_velocity * Time.deltaTime);
        }

        public void ApplyPhysics()
        {
            if(_velocity.y < 0)
                _velocity.y = -_gravitySettings.GravityModifier;

            _velocity.y += _gravitySettings.Gravity * _gravitySettings.GravityModifier * Time.deltaTime;

            _characterController.Move(_velocity * Time.deltaTime);
        }

        [Serializable]
        public class GravitySettings
        {
            [field: SerializeField] public float Gravity { get; private set; }
            [field: SerializeField] public float GravityModifier { get; private set; }
        }
    }
}