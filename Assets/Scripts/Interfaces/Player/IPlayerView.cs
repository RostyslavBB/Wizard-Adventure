using Game.Interfaces.General;
using System;
using UnityEngine;

namespace Game.Interfaces.Player
{
    public interface IPlayerView : ILifecycle
    {
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnRotate;

        public event Action OnJump;
        public event Action OnApplyPhysics;

        public bool IsOnGround();
    }
}