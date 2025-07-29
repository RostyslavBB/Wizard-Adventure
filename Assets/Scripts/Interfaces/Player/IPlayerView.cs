using System;
using UnityEngine;

namespace Game.Interfaces
{
    public interface IPlayerView : ILifecycle
    {
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnRotate;
    }
}