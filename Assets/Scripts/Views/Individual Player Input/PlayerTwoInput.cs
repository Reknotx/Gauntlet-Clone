using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoInput : InputView
{
    //PlayerTwoInputSystem inputAction;

    //private void Awake()
    //{
    //    inputAction = new PlayerOneInputSystem();
    //    inputAction.Player.Move.performed += ctxM => movement = ctxM.ReadValue<Vector2>();
    //    inputAction.Player.Look.performed += ctxL => rotation = ctxL.ReadValue<Vector2>();
    //    inputAction.Player.Melee.performed += ctxMA => OnMeleeAttack(app.data.playerData.playerTwo.PlayerNum);
    //    inputAction.Player.Throw.performed += ctxT => OnThrow(app.data.playerData.playerTwo.PlayerNum);
    //}

    //private void LateUpdate()
    //{
    //    if (movement == Vector2.zero && rotation == Vector2.zero) return;

    //    if (movement != Vector2.zero)
    //    {
    //        OnMovement(app.data.playerData.playerOne.PlayerNum, movement);

    //    }

    //    if (rotation != Vector2.zero)
    //    {
    //        OnRotate(app.data.playerData.playerOne.PlayerNum, rotation);
    //    }
    //}

    //private void OnEnable()
    //{
    //    inputAction.Enable();
    //}

    //private void OnDisable()
    //{
    //    inputAction.Disable();
    //}
}
