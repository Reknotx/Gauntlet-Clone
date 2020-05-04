using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Element
{
    public void MovePlayer(PlayerNumber.PlayerNum player, Vector2 movement)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                //Move player one
                app.view.players.playerOne.Movement(movement);
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                //Move player two
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                //Move player three
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                //Move player four
                break;

            default:
                break;
        }
    }

    public void RotatePlayer(PlayerNumber.PlayerNum player, Vector2 rotation)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.view.players.playerOne.Rotate(rotation);
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                break;

            default:
                break;
        }
    }

    public void PlayerMeleeAttack(PlayerNumber.PlayerNum playerNum)
    {
        switch (playerNum)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.view.players.playerOne.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                break;

            default:
                break;
        }
    }

    public void PlayerThrow(PlayerNumber.PlayerNum playerNum)
    {
        switch (playerNum)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.view.players.playerOne.Throw();
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                break;

            default:
                break;
        }
    }
}
