using System;

namespace Game.Interfaces
{
    public interface ILifecycle : IDisposable
    {
        public bool IsEnable { get; }

        public void Enable();

        public void Disable();
    }
}