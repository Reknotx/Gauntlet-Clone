using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : Element
{
    protected Vector2 movement;
    protected Vector2 rotation;

    protected void OnMovement(PlayerNumber.PlayerNum player, Vector2 movement)
    {
        app.controller.input.MovePlayer(player, movement);
    }

    protected void OnRotate(PlayerNumber.PlayerNum player, Vector2 rotation)
    {

        app.controller.input.RotatePlayer(player, rotation);
    }

    protected void OnMeleeAttack(PlayerNumber.PlayerNum player)
    {
        app.controller.input.PlayerMeleeAttack(player);
    }

    protected void OnThrow(PlayerNumber.PlayerNum player)
    {
        app.controller.input.PlayerThrow(player);

    }

    protected void OnPotion(PlayerNumber.PlayerNum player)
    {

    }
}
