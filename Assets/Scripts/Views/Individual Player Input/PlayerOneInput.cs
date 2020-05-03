using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneInput : InputView
{
    PlayerOneInputSystem inputAction;

    private void Awake()
    {
        inputAction = new PlayerOneInputSystem();
        inputAction.Player.Move.performed += ctxM => movement = ctxM.ReadValue<Vector2>();
        inputAction.Player.Look.performed += ctxL => rotation = ctxL.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        if (movement == Vector2.zero && rotation == Vector2.zero) return;

        if (movement != Vector2.zero)
        {
            OnMovement(app.data.playerData.playerOne.PlayerNum, movement);

        }

        if (rotation != Vector2.zero)
        {
            OnRotate(app.data.playerData.playerOne.PlayerNum, rotation);
        }
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
}
