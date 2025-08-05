using UnityEngine;
using Game.Interfaces.Player;

namespace Game.Handlers
{
    public sealed class PlayerInputHandler : IPlayerInputHandler
    {
        private readonly PlayerrInputActions _playerInput;

        public bool IsEnable { get; private set; }

        public PlayerInputHandler()
        {
            _playerInput = new PlayerrInputActions();
        }

        public Vector2 GetMovementInput()
        {
            return _playerInput.Player.Move.ReadValue<Vector2>();
        }

        public Vector2 GetRotationInput()
        {
            return _playerInput.Player.Look.ReadValue<Vector2>();
        }

        public bool GetJumpInput()
        {
            return _playerInput.Player.Jump.WasPressedThisFrame();
        }

        public bool FirstSkillAttack()
        {
            return true;
        }

        public bool SecondSkillAttack()
        {
            return false;
        }

        public void Enable()
        {
            _playerInput.Enable();

            IsEnable = true;
        }

        public void Disable()
        {
            _playerInput.Disable();

            IsEnable = false;
        }

        public void Dispose()
        {
            _playerInput.Dispose();
        }
    }
}