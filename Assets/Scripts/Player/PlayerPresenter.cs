using Game.Interfaces.Camera;
using Game.Interfaces.Player;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly IPlayerView _view;
        private readonly IPlayerMovement _movement;
        private readonly ICameraRotator _rotator;

        private readonly PlayerModel _model;

        public bool IsEnable {  get; private set; }

        public PlayerPresenter(IPlayerView view, PlayerModel model, IPlayerMovement movement, ICameraRotator rotator)
        {
            _view = view;
            _model = model;
            _movement = movement;
            _rotator = rotator;

            Enable();
        }

        private void OnMove(Vector2 direction)
        {
            _movement.Move(direction, _model.PlayerSetting.MoveSpeed);
        }

        private void OnRotate(Vector2 direction)
        {
            _rotator.Rotate(direction);
        }

        private void OnJump()
        {
            if(_view.IsOnGround())
                _movement.Jump(_model.PlayerSetting.JumpHeight);
        }

        private void OnApplyPhysics()
        {
            if (!_view.IsOnGround())
                _movement.ApplyPhysics();
        }

        public void Enable()
        {
            _view.OnMove += OnMove;
            _view.OnRotate += OnRotate;
            _view.OnJump += OnJump;
            _view.OnApplyPhysics += OnApplyPhysics;
        }

        public void Disable()
        {
            _view.OnMove -= OnMove;
            _view.OnRotate -= OnRotate;
            _view.OnJump -= OnJump;
            _view.OnApplyPhysics -= OnApplyPhysics;
        }

        public void Dispose()
        {
            Disable();
        }
    }
}