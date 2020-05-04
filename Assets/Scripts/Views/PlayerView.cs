using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Element
{
    private float SpriteChangeThreshold = 0.5f;

    protected void ProcessCollision(PlayerNumber.PlayerNum player, LayerMask layer)
    {

    }

    protected Sprite GetPlayerSpriteOnRotation(PlayerNumber.PlayerNum player, Vector2 rotation)
    {
        Sprite playerSprite = null;

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
}
