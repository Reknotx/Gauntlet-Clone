using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerOneRB;

    private float SpriteChangeThreshold = 0.5f;

    private void Awake()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerOneRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Use layers to determine collision actions
        //If layer isn't the environment then send the rest of the detection towards either
        //the controller or the parent class first which will then send the collision
        //info to the right controller in collision controller.

        //If  collision.gameObject.layer != walls
        //then send message to parent to deal with

        //No need to write the same tests in the various player views

        //ProcessCollision(PlayerNumber.PlayerNum.PlayerOne, collision.gameObject.layer);
    }

    public void Movement(Vector2 movement)
    {
        //Debug.Log(movement.ToString());

        
        Vector3 moveV3 = (new Vector3(movement.x, movement.y) * app.data.playerData.playerOne.MoveSpeed * 10f * Time.deltaTime) + transform.position;
        playerOneRB.MovePosition(moveV3);
    }

    public void Rotate(Vector2 rotation)
    {
        if (rotation.x > SpriteChangeThreshold)
        {
            //Moving East
            if (rotation.y > SpriteChangeThreshold)
            {
                //Moving NorthEast
                if (playerSprite.sprite.name == app.data.playerData.playerOne.NorthEastSprite.name) return;
                Debug.Log("Load warrior NorthEast");
                playerSprite.sprite = app.data.playerData.playerOne.NorthEastSprite;
            }
            else if (rotation.y < -SpriteChangeThreshold)
            {
                //Moving SouthEast
                if (playerSprite.sprite.name == app.data.playerData.playerOne.SouthEastSprite.name) return;
                Debug.Log("Load warrior SouthEast");
                playerSprite.sprite = app.data.playerData.playerOne.SouthEastSprite;
            }
            else
            {
                //Moving East
                if (playerSprite.sprite.name == app.data.playerData.playerOne.EastSprite.name) return;
                Debug.Log("Load warrior East");
                playerSprite.sprite = app.data.playerData.playerOne.EastSprite;
            }
        }
        else if (rotation.x < -SpriteChangeThreshold)
        {
            //moving west
            if (rotation.y > SpriteChangeThreshold)
            {
                //Moving NorthWest
                if (playerSprite.sprite.name == app.data.playerData.playerOne.NorthWestSprite.name) return;
                Debug.Log("Load warrior NorthWest");
                playerSprite.sprite = app.data.playerData.playerOne.NorthWestSprite;
            }
            else if (rotation.y < -SpriteChangeThreshold)
            {
                //Moving SouthWest
                if (playerSprite.sprite.name == app.data.playerData.playerOne.SouthWestSprite.name) return;
                Debug.Log("Load warrior SouthWest");
                playerSprite.sprite = app.data.playerData.playerOne.SouthWestSprite;
            }
            else
            {
                //Moving West
                if (playerSprite.sprite.name == app.data.playerData.playerOne.WestSprite.name) return;
                Debug.Log("Load warrior West");
                playerSprite.sprite = app.data.playerData.playerOne.WestSprite;
            }
        }
        else if (Mathf.Abs(rotation.y) > SpriteChangeThreshold)
        {
            //Moving north or south
            if (rotation.y > 0f)
            {
                //Moving North
                if (playerSprite.sprite.name == app.data.playerData.playerOne.NorthSprite.name) return;
                Debug.Log("Load warrior North");
                playerSprite.sprite = app.data.playerData.playerOne.NorthSprite;
            }
            else
            {
                //Moving South
                if (playerSprite.sprite.name == app.data.playerData.playerOne.SouthSprite.name) return;
                Debug.Log("Load warrior South");
                playerSprite.sprite = app.data.playerData.playerOne.SouthSprite;
            }
        }
    }
}
