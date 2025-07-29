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

            if (_view.IsEnable == false) Enable();
        }

        private void OnMove(Vector2 direction)
        {
            _model.UpdateVelocity(direction);
        }

        private void OnRotate(Vector2 direction)
        {
            Debug.Log(3);
        }

        public void Enable()
        {
            _view.OnMove += OnMove;
            _view.OnRotate += OnRotate;
        }

        public void Disable()
        {
            _view.OnMove -= OnMove;
            _view.OnRotate -= OnRotate;
        }

        public void Dispose()
        {
            Disable();
        }
    }
}