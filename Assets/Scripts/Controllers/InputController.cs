using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Controller which filters input from the player to 
 * appropriate view for updating their presence in the world.
 * 
 * Such actions include movement, rotation, attacking, and potion use.</summary>
 * 
 * Currenly only one player is able to play the game at this time
 * but once mulitplayer functionality is acquired the messages will
 * be filtered without issue.
 * 
 * 
 */
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
                app.view.players.playerTwo.Movement(movement);
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                //Move player three
                app.view.players.playerThree.Movement(movement);
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                //Move player four
                app.view.players.playerFour.Movement(movement);
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
                app.view.players.playerTwo.Rotate(rotation);
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.view.players.playerThree.Rotate(rotation);
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.view.players.playerFour.Rotate(rotation);
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
                app.view.players.playerTwo.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.data.playerData.playerThree.IsAttacking = true;
                app.view.players.playerThree.MeleeAttack();
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.data.playerData.playerFour.IsAttacking = true;
                app.view.players.playerFour.MeleeAttack();
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
                app.view.players.playerTwo.Throw();
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.view.players.playerThree.Throw();
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.view.players.playerFour.Throw();
                break;

            default:
                break;
        }
    }

    public void UsePotion(PlayerNumber.PlayerNum player)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                if (app.data.playerData.playerOne.Potions != 0)
                {
                    app.data.objectsInView.KillAllEnemies();
                    app.data.playerData.playerOne.Potions--;
                }
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                if (app.data.playerData.playerTwo.Potions != 0)
                {
                    app.data.objectsInView.KillAllEnemies();
                    app.data.playerData.playerTwo.Potions--;
                }
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                if (app.data.playerData.playerThree.Potions != 0)
                {
                    app.data.objectsInView.KillAllEnemies();
                    app.data.playerData.playerThree.Potions--;
                }
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                if (app.data.playerData.playerFour.Potions != 0)
                {
                    app.data.objectsInView.KillAllEnemies();
                    app.data.playerData.playerFour.Potions--;
                }
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

        playerView.meleeBox.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        playerView.SetCurrentDirectionSprite(playerData, playerView);

        playerData.IsAttacking = false;

        playerView.meleeBox.SetActive(false);
    }
}
