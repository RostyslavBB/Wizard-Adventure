using Game.Interfaces;
using System;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerModel : IPlayerModel
    {
        [Inject] private readonly PlayerSettings _playerSettings;

        [Inject] private readonly IPlayerMovement _playerMovement;
        [Inject] private readonly ICameraRotator _cameraRotator;

        public void UpdateVelocity(Vector2 direction)
        {
            _playerMovement.Move(direction, _playerSettings.MoveSpeed);
        }

        public void UpdateRotation(Vector2 direction)
        {
            _cameraRotator.Rotate(direction);
        }

        public void Jump()
        {
            _playerMovement.Jump(_playerSettings.JumpHeight);
        }

        public void ApplyPhysics()
        {
            _playerMovement.ApplyPhysics();
        }

        [Serializable]
        public class PlayerSettings
        {
            [field: SerializeField] public float MoveSpeed { get; private set; }
            [field: SerializeField] public float JumpHeight { get; private set; }
        }
    }
}
