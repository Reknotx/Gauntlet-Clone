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
        inputAction.Player.Look.performed += ctxL => OnRotate(app.data.playerData.playerOne.PlayerNum, ctxL.ReadValue<Vector2>());
        inputAction.Player.Melee.performed += ctxMA => OnMeleeAttack(app.data.playerData.playerOne.PlayerNum);
        inputAction.Player.Throw.performed += ctxT => OnThrow(app.data.playerData.playerOne.PlayerNum);
        inputAction.Player.Potion.performed += ctxP => OnPotion(app.data.playerData.playerOne.PlayerNum);
    }

    private void LateUpdate()
    {
        //If attacking the players can't be allowed to move, need to have a way to limit
        //player movement when performing combat actions.

        if (movement == Vector2.zero) return;

        OnMovement(app.data.playerData.playerOne.PlayerNum, movement);
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
