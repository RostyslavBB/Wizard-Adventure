using Game.Interfaces;
using System;
using UnityEngine;
using Zenject;

public class PlayerView : MonoBehaviour, IPlayerView
{
    public event Action<Vector2> OnMove;
    public event Action<Vector2> OnRotate;

    public event Action OnJump;

    private IPlayerInputHandler _inputHandler;

    public bool IsEnable { get; private set; }

    [Inject]
    private void Construct(IPlayerInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    private void Update()
    {
        OnMove?.Invoke(_inputHandler.GetMovementInput());
        OnRotate?.Invoke(_inputHandler.GetRotationInput());

        if (_inputHandler.GetJumpInput())
        {
            Debug.Log(1);
            OnJump?.Invoke();
        }
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

}
