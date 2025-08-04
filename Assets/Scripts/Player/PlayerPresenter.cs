using Game.Interfaces;
using UnityEngine;

namespace Game.Player
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private readonly IPlayerView _view;
        private readonly IPlayerModel _model;

        public bool IsEnable {  get; private set; }

        public PlayerPresenter(IPlayerView view, IPlayerModel model)
        {
            _view = view;
            _model = model;

            Enable();
        }

        private void OnMove(Vector2 direction)
        {
            _model.UpdateVelocity(direction);
        }

        private void OnRotate(Vector2 direction)
        {
            _model.UpdateRotation(direction);
        }

        private void OnJump()
        {
            if(_view.IsOnGround())
                _model.Jump();
        }

        private void OnApplyPhysics()
        {
            if (!_view.IsOnGround())
                _model.ApplyPhysics();
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