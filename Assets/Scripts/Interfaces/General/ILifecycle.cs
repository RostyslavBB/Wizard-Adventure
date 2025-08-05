using System;

namespace Game.Interfaces.General
{
    public interface ILifecycle : IDisposable
    {
        public bool IsEnable { get; }

        public void Enable();

        public void Disable();
    }
}