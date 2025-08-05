using Game.Interfaces.General;
using UnityEngine;

namespace Game.Interfaces.Player
{
    public interface IPlayerInputHandler : ILifecycle
    {
        public Vector2 GetMovementInput();
        public Vector2 GetRotationInput();

        public bool GetJumpInput();
        public bool FirstSkillAttack();
        public bool SecondSkillAttack();
    }
}