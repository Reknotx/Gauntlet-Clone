using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : Element
{
    protected Vector2 movement;
    protected Vector2 rotation;

    /**
     * <summary>Sends a message to the input controller to move the player.</summary>
     * 
     * <param name="movement">The direction of movement.</param>
     * <param name="player">The player to move.</param>
     */
    protected void OnMovement(PlayerNumber.PlayerNum player, Vector2 movement)
    {
        app.controller.input.MovePlayer(player, movement);
    }

    /**
     * <summary>Sends a message to the input controller to rotate the player.</summary>
     * 
     * <param name="movement">The direction of rotation.</param>
     * <param name="player">The player to rotate.</param>
     */
    protected void OnRotate(PlayerNumber.PlayerNum player, Vector2 rotation)
    {

        app.controller.input.RotatePlayer(player, rotation);
    }

    /**
     * <summary>Sends a message to the input controller to execute a player melee attack.</summary>
     * 
     * <param name="player">The attacking player.</param>
     */
    protected void OnMeleeAttack(PlayerNumber.PlayerNum player)
    {
        app.controller.input.PlayerMeleeAttack(player);
    }

    /**
     * <summary>Sends a message to the input controller to execute a player throw attack.</summary>
     * 
     * <param name="player">The attacking player.</param>
     */
    protected void OnThrow(PlayerNumber.PlayerNum player)
    {
        app.controller.input.PlayerThrow(player);

    }

    /**
     * <summary>Sends a message to the input controller to use a potion the player holds.</summary>
     * 
     * <param name="player">The player using the potion.</param>
     */
    protected void OnPotion(PlayerNumber.PlayerNum player)
    {
        app.controller.input.UsePotion(player);
    }
}
