using Game.Interfaces;
using Game.Player;
using System;
using UnityEngine;
using Zenject;

namespace Game.Camera
{
    public class CameraRotator : ICameraRotator
    {
        [Inject(Id = "Camera")] private readonly Transform _camera;

        [Inject] private readonly PlayerView _playerView;
        [Inject] private readonly CameraSettings _settings;

        private float _rotation;

        public void Rotate(Vector2 direction)
        {
            float mouseX = direction.x * _settings.MouseSpeedX * Time.deltaTime;
            float mouseY = direction.y * _settings.MouseSpeedY * Time.deltaTime;

            _rotation -= mouseY;
            _rotation = Mathf.Clamp(_rotation, -_settings.LimitY, _settings.LimitY);

            _camera.localRotation = Quaternion.Euler(_rotation, 0f, 0f);

            _playerView.transform.Rotate(Vector3.up * mouseX);
        }

        [Serializable]
        public class CameraSettings
        {
            [field: SerializeField] public float MouseSpeedX {  get; private set; }
            [field: SerializeField] public float MouseSpeedY {  get; private set; }
            [field: SerializeField] public float LimitY {  get; private set; }
        }
    }
}