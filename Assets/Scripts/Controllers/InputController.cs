using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Element
{
    public void MovePlayer(PlayerNumber.PlayerNum player, Vector2 movement)
    {
        if (CheckIfPlayerAttacking(player)) return;

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
        if (CheckIfPlayerAttacking(player)) return;

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

    public void PlayerMeleeAttack(PlayerNumber.PlayerNum player)
    {
        if (CheckIfPlayerAttacking(player)) return;

        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.data.playerData.playerOne.IsAttacking = true;
                app.view.players.playerOne.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                app.data.playerData.playerTwo.IsAttacking = true;
                //app.view.players.playerTwo.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.data.playerData.playerThree.IsAttacking = true;
                //app.view.players.playerThree.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.data.playerData.playerFour.IsAttacking = true;
                //app.view.players.playerFour.MeleeAttack();
                break;

            default:
                break;
        }

        StartCoroutine(Attack(player));
    }

    public void PlayerThrow(PlayerNumber.PlayerNum player)
    {
        if (CheckIfPlayerAttacking(player)) return;

        switch (player)
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

    private bool CheckIfPlayerAttacking(PlayerNumber.PlayerNum player)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                if (app.data.playerData.playerOne.IsAttacking) return true;
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                if (app.data.playerData.playerTwo.IsAttacking) return true;
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                if (app.data.playerData.playerThree.IsAttacking) return true;
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                if (app.data.playerData.playerFour.IsAttacking) return true;
                break;

            default:
                break;
        }

        return false;
    }

    IEnumerator Attack(PlayerNumber.PlayerNum player)
    {
        PlayerData playerData = null;
        PlayerView playerView = null;

        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                playerData = app.data.playerData.playerOne;
                playerView = app.view.players.playerOne;
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                playerData = app.data.playerData.playerTwo;
                playerView = app.view.players.playerTwo;
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                playerData = app.data.playerData.playerThree;
                playerView = app.view.players.playerThree;
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                playerData = app.data.playerData.playerFour;
                playerView = app.view.players.playerFour;
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(0.2f);

        playerView.SetCurrentDirectionSprite(playerData, playerView);

        playerData.IsAttacking = false;
    }
}
