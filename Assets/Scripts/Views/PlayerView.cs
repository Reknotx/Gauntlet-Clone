using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>The base player view class that each player inherits from
 * to allow for generic programming.</summary>
 * 
 */
public class PlayerView : Element
{
    //Create a private helper function that tells if the players current direction,
    //matches the desired one

    private float SpriteChangeThreshold = 0.5f;

    public GameObject meleeBox;

    /**
     * <summary>Send a collision message to the collision controller for filtering
     * purposes.</summary>
     * 
     * <param name="player">The player.</param>
     * <param name="objTwo">The object that was collided with.</param>
     * 
     */
    protected void SendCollisionMessage(GameObject player, GameObject objTwo)
    {
        app.controller.collisions.FilterCollision(player, objTwo);
    }

    /**
     * <summary>Get's the sprite that is relevant to the player's current
     * facing direction.</summary>
     * 
     * <param name="player">The player that rotated.</param>
     * <param name="rotation">The vector2 that represents the direction of rotation.</param>
     */
    protected Sprite GetPlayerSpriteOnRotation(PlayerNumber.PlayerNum player, Vector2 rotation)
    {
        Sprite playerSprite = null;

        PlayerData playerData = GetPlayerData(player);

        if (rotation.x > SpriteChangeThreshold)
        {
            //Moving East
            if (rotation.y > SpriteChangeThreshold)
            {
                //Moving NorthEast
                if (playerData.CurrentDirection == PlayerData.Direction.NorthEast) return null;

                playerData.CurrentDirection = PlayerData.Direction.NorthEast;

                playerSprite = playerData.NorthEastSprite;
            }
            else if (rotation.y < -SpriteChangeThreshold)
            {
                //Moving SouthEast
                if (playerData.CurrentDirection == PlayerData.Direction.SouthEast) return null;

                playerData.CurrentDirection = PlayerData.Direction.SouthEast;

                playerSprite = playerData.SouthEastSprite;
            }
            else
            {
                //Moving East
                if (playerData.CurrentDirection == PlayerData.Direction.East) return null;

                playerData.CurrentDirection = PlayerData.Direction.East;

                playerSprite = playerData.EastSprite;
            }
        }
        else if (rotation.x < -SpriteChangeThreshold)
        {
            //moving west
            if (rotation.y > SpriteChangeThreshold)
            {
                //Moving NorthWest
                if (playerData.CurrentDirection == PlayerData.Direction.NorthWest) return null;

                playerData.CurrentDirection = PlayerData.Direction.NorthWest;

                playerSprite = playerData.NorthWestSprite;
            }
            else if (rotation.y < -SpriteChangeThreshold)
            {
                //Moving SouthWest
                if (playerData.CurrentDirection == PlayerData.Direction.SouthWest) return null;

                playerData.CurrentDirection = PlayerData.Direction.SouthWest;

                playerSprite = playerData.SouthWestSprite;
            }
            else
            {
                //Moving West
                if (playerData.CurrentDirection == PlayerData.Direction.West) return null;

                playerData.CurrentDirection = PlayerData.Direction.West;

                playerSprite = playerData.WestSprite;
            }
        }
        else if (Mathf.Abs(rotation.y) > SpriteChangeThreshold)
        {
            //Moving north or south
            if (rotation.y > 0f)
            {
                //Moving North
                if (playerData.CurrentDirection == PlayerData.Direction.North) return null;

                playerData.CurrentDirection = PlayerData.Direction.North;

                playerSprite = playerData.NorthSprite;
            }
            else
            {
                //Moving South
                if (playerData.CurrentDirection == PlayerData.Direction.South) return null;

                playerData.CurrentDirection = PlayerData.Direction.South;

                playerSprite = playerData.SouthSprite;
            }
        }

        return playerSprite;
    }

    /**
     * <summary>Returns a vector 2 direction for determining where to place the player's
     * melee box when rotating the player's sprite.</summary>
     * 
     * <param name="player">The player whose direction needs to be examined.</param>
     */
    protected Vector2 GetMeleeBoxPosOnRotate(PlayerNumber.PlayerNum player)
    {
        PlayerData playerData = GetPlayerData(player);
        Vector2 newPos = Vector2.zero;

        switch (playerData.CurrentDirection)
        {
            case PlayerData.Direction.North:
                newPos = Vector2.up;
                break;

            case PlayerData.Direction.NorthEast:
                newPos = Vector2.one.normalized;
                break;

            case PlayerData.Direction.East:
                newPos = Vector2.right;
                break;

            case PlayerData.Direction.SouthEast:
                newPos = new Vector2(1f, -1f).normalized;
                break;

            case PlayerData.Direction.South:
                newPos = Vector2.down;
                break;

            case PlayerData.Direction.SouthWest:
                newPos = new Vector2(-1f, -1f).normalized;
                break;

            case PlayerData.Direction.West:
                newPos = Vector2.left;
                break;

            case PlayerData.Direction.NorthWest:
                newPos = new Vector2(-1f, 1f).normalized;
                break;

            default:
                break;
        }


        return newPos;
    }

    /**
     * <summary>Provides a rotation for the player's melee box when rotating the player. Will obtain
     * a reference to the player's data.</summary>
     * 
     * <param name="player">The player whose melee box is being rotated.</param>
     * 
     * <returns>A vector 3 detailing the player's melee box rotation.</returns>
     */
    public Vector3 GetNewMeleeBoxRotation(PlayerNumber.PlayerNum player)
    {
        PlayerData playerData = GetPlayerData(player);
        Vector3 rotation = new Vector3(0f, 0f, 0f);

        switch (playerData.CurrentDirection)
        {
            case PlayerData.Direction.North:
                rotation.z = 90f;
                break;

            case PlayerData.Direction.NorthEast:
                rotation.z = 45f;
                break;

            case PlayerData.Direction.East:
                rotation.z = 0f;
                break;

            case PlayerData.Direction.SouthEast:
                rotation.z = 315f;
                break;

            case PlayerData.Direction.South:
                rotation.z = 270f;
                break;

            case PlayerData.Direction.SouthWest:
                rotation.z = 215f;
                break;

            case PlayerData.Direction.West:
                rotation.z = 180f;
                break;

            case PlayerData.Direction.NorthWest:
                rotation.z = 135f;
                break;

            default:
                break;
        }

        return rotation;
    }

    /**
     * <summary>Returns a vector 2 to apply to the player's projectile to throw it in the
     * appropriate direction.</summary>
     * 
     * <param name="player">The player whose direction needs to be evaluated.</param>
     * 
     * <returns>A vector 2 describing the projectiles direction of movement.</returns>
     */
    protected Vector2 GetThrowVector(PlayerNumber.PlayerNum player)
    {
        Vector2 throwDirection = Vector2.zero;

        PlayerData.Direction temp = PlayerData.Direction.North;

        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                temp = app.data.playerData.playerOne.CurrentDirection;
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                temp = app.data.playerData.playerTwo.CurrentDirection;
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                temp = app.data.playerData.playerThree.CurrentDirection;
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                temp = app.data.playerData.playerFour.CurrentDirection;
                break;

            default:
                break;
        }

        switch (temp)
        {
            case PlayerData.Direction.North:
                throwDirection = Vector2.up;
                break;

            case PlayerData.Direction.NorthEast:
                throwDirection = new Vector2(1, 1).normalized;
                break;

            case PlayerData.Direction.East:
                throwDirection = Vector2.right;
                break;

            case PlayerData.Direction.SouthEast:
                throwDirection = new Vector2(1, -1).normalized;
                break;

            case PlayerData.Direction.South:
                throwDirection = Vector2.down;
                break;

            case PlayerData.Direction.SouthWest:
                throwDirection = new Vector2(-1, -1).normalized;
                break;

            case PlayerData.Direction.West:
                throwDirection = Vector2.left;
                break;

            case PlayerData.Direction.NorthWest:
                throwDirection = new Vector2(-1, 1).normalized;
                break;
        }

        return throwDirection;
    }


    /**
     * <summary>Sets the player's sprite to the appropriate one for their currently
     * faced direction.</summary>
     * 
     * <param name="playerData">The data of the player we are adjusting.</param>
     * <param name="playerview">The view of the player we are adjusting. Used to set the
     * sprite for the player.</param>
     */
    public void SetCurrentDirectionSprite(PlayerData playerData, PlayerView playerview)
    {
        Sprite temp = null;

        switch (playerData.CurrentDirection)
        {
            case PlayerData.Direction.North:
                temp = playerData.NorthSprite;
                break;

            case PlayerData.Direction.NorthEast:
                temp = playerData.NorthEastSprite;
                break;

            case PlayerData.Direction.East:
                temp = playerData.EastSprite;
                break;

            case PlayerData.Direction.SouthEast:
                temp = playerData.SouthEastSprite;
                break;

            case PlayerData.Direction.South:
                temp = playerData.SouthSprite;
                break;

            case PlayerData.Direction.SouthWest:
                temp = playerData.SouthWestSprite;
                break;

            case PlayerData.Direction.West:
                temp = playerData.WestSprite;
                break;

            case PlayerData.Direction.NorthWest:
                temp = playerData.NorthWestSprite;
                break;

            default:
                break;
        }

        playerview.GetComponent<SpriteRenderer>().sprite = temp;
    }

    /**
     * <summary>Get's the player data file for the player.</summary>
     * 
     * <param name="player">The player whose data we need.</param>
     * 
     * <returns>A reference to the player data script associated with the
     * player.</returns>
     */
    private PlayerData GetPlayerData(PlayerNumber.PlayerNum player)
    {
        PlayerData playerData = null;

        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                playerData = app.data.playerData.playerOne;
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                playerData = app.data.playerData.playerTwo;
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                playerData = app.data.playerData.playerThree;
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                playerData = app.data.playerData.playerFour;
                break;

            default:
                break;
        }

        return playerData;
    }
}
