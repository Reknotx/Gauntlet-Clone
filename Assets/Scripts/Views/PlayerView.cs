using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Element
{
    //Create a private helper function that tells if the players current direction,
    //matches the desired one

    private float SpriteChangeThreshold = 0.5f;

    public GameObject meleeBox;

    protected void SendCollisionMessage(GameObject player, GameObject objTwo)
    {
        app.controller.collisions.FilterCollision(player, objTwo);
    }

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
                Debug.Log(newPos);
                break;

            case PlayerData.Direction.East:
                newPos = Vector2.right;
                break;

            case PlayerData.Direction.SouthEast:
                newPos = new Vector2(1f, -1f).normalized;
                Debug.Log(newPos);
                break;

            case PlayerData.Direction.South:
                newPos = Vector2.down;
                break;

            case PlayerData.Direction.SouthWest:
                newPos = new Vector2(-1f, -1f).normalized;
                Debug.Log(newPos);
                break;

            case PlayerData.Direction.West:
                newPos = Vector2.left;
                break;

            case PlayerData.Direction.NorthWest:
                newPos = new Vector2(-1f, 1f).normalized;
                Debug.Log(newPos);
                break;

            default:
                break;
        }


        return newPos;
    }

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
