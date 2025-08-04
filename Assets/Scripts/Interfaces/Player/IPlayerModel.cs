using UnityEngine;

namespace Game.Interfaces
{
    public interface IPlayerModel
    {
        public void UpdateVelocity(Vector2 direction);
        public void UpdateRotation(Vector2 direction);
        public void Jump();
        public void ApplyPhysics();
    }
}