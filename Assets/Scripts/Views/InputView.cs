using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : Element
{
    protected Vector2 movement;
    protected Vector2 rotation;

    public void OnMovement(PlayerNumber.PlayerNum playerNum, Vector2 movement)
    {
        app.controller.input.MovePlayer(playerNum, movement);
    }

    public void OnRotate(PlayerNumber.PlayerNum playerNum, Vector2 rotation)
    {
        app.controller.input.RotatePlayer(playerNum, rotation);
    }
}
