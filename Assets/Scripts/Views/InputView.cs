using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : Element
{
    protected Vector2 movement;
    protected Vector2 rotation;

    protected void OnMovement(PlayerNumber.PlayerNum playerNum, Vector2 movement)
    {
        app.controller.input.MovePlayer(playerNum, movement);
    }

    protected void OnRotate(PlayerNumber.PlayerNum playerNum, Vector2 rotation)
    {
        app.controller.input.RotatePlayer(playerNum, rotation);
    }

    protected void OnMeleeAttack(PlayerNumber.PlayerNum playerNum)
    {
        app.controller.input.PlayerMeleeAttack(playerNum);
    }

    protected void OnThrow(PlayerNumber.PlayerNum playerNum)
    {
        app.controller.input.PlayerThrow(playerNum);

    }

    protected void OnPotion(PlayerNumber.PlayerNum playerNum)
    {

    }
}
