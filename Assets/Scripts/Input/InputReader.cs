using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action<Vector2> MoveEvent;
    public event Action<bool> PrimaryFireEvent;

    public Vector2 AimPosition {  get; private set; }

    private Controls controls;

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }
        
        controls.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVector = context.ReadValue<Vector2>();

        MoveEvent?.Invoke(moveVector);
    }

    public void OnPrimaryFire(InputAction.CallbackContext context)
    {
        bool isFired;

        if (context.performed)
        {
            isFired = true;
        } else
        {
            isFired = false;
        }

        PrimaryFireEvent?.Invoke(isFired);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        AimPosition = context.ReadValue<Vector2>();
    }
}
