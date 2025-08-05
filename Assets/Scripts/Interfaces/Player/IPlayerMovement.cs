using UnityEngine;

namespace Game.Interfaces.Player
{
    public interface IPlayerMovement
    {
        public void Move(Vector2 direction, float moveSpeed);
        public void Jump(float jumpHeight);
        public void ApplyPhysics();
    }
}