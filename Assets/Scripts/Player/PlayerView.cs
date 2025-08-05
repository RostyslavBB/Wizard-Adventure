using Game.Interfaces.Player;
using System;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [Inject] private readonly ViewSettings _viewSettings;

        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnRotate;

        public event Action OnJump;
        public event Action OnApplyPhysics;

        private IPlayerInputHandler _inputHandler;

        public bool IsEnable { get; private set; }

        [Inject]
        private void Construct(IPlayerInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        //Test
        private void Start()
        {
            Cursor.visible = false;
        }

        private void Update()
        {
            OnMove?.Invoke(_inputHandler.GetMovementInput());
            OnRotate?.Invoke(_inputHandler.GetRotationInput());

            OnApplyPhysics?.Invoke();

            if (_inputHandler.GetJumpInput())
            {
                OnJump?.Invoke();
            }
        }

        public bool IsOnGround()
        {
            return Physics.CheckSphere(transform.position, _viewSettings.CheckGroundDistance, _viewSettings.GroundLayer);
        }

        private void OnEnable()
        {
            Enable();
        }

        private void OnDisable()
        {
            Disable();
        }

        public void Enable()
        {
            _inputHandler.Enable();
        }

        public void Disable()
        {
            _inputHandler.Disable();
        }

        public void Dispose()
        {
            _inputHandler.Dispose();
        }

        [Serializable]
        public class ViewSettings
        {
            [field: SerializeField] public LayerMask GroundLayer { get; private set; }
            [field: SerializeField] public float CheckGroundDistance { get; private set; }
        }
    }
}