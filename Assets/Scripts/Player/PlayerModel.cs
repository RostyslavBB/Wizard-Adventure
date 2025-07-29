using Game.Interfaces;
using System;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerModel : IPlayerModel
    {
        [Inject] private readonly CharacterController _characterController;
        [Inject] private readonly PlayerSettings _playerSettings;

        public void UpdateVelocity(Vector2 direction)
        {
            Vector3 move = _characterController.transform.forward * direction.y + _characterController.transform.right * direction.x;

            _characterController.Move(_playerSettings.MoveSpeed * Time.deltaTime * move);
        }

        public void UpdateRotation(Vector2 direction)
        {

        }

        [Serializable]
        public class PlayerSettings
        {
            [field: SerializeField] public float MoveSpeed { get; private set; }
            [field: SerializeField] public float RotationSpeed { get; private set; }
        }
    }
}
