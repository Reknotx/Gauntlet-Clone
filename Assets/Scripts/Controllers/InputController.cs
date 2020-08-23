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
    /**
     * <summary>Sends a message to the appropriate player to update their position
     * in the world based on the supplied value.</summary>
     * 
     * <param name="player">The player to be moved.</param>
     * <param name="movement">The direction of movement.</param>
     */
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

    /**
     * <summary>Sends a message to the appropriate player to change their current sprite to match
     * their desired aiming direction.</summary>
     * 
     * <param name="player">The player to be rotated.</param>
     * <param name="rotation">The direction of rotation, or aiming direction.</param>
     */
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

    /**
     * <summary>Executes the player's melee attack and triggers the attack animation
     * on screen.</summary>
     * 
     * <param name="player">The attacking player.</param>
     */
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

    /**
     * <summary>Executes the player's throwing attack.</summary>
     * 
     * <param name="player">The attacking player.</param>
     * 
     */
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

    /**
     * <summary>Uses a potion that the player currently holds. In current state
     * potions will kill all enemies on screen. Will reduce number of potions
     * held by player by one.</summary>
     * 
     * <param name="player">The player using a potion.</param>
     */
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

    /**
     * <summary>Private helper function which checks if player is already attacking
     * to limit the player to one attack at a time.</summary>
     * 
     * <param name="player">The player that needs to be evaluated.</param>
     */
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

    /**
     * <summary>Private co-routine that carries out the player's melee attack
     * and then resets their sprites to default. Receives references to the
     * PlayerData and PlayerView internally.</summary>
     * 
     * <param name="player">The attacking player.</param>
     * 
     */
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
