﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerOneRB;


    private void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerOneRB = GetComponent<Rigidbody2D>();
        app.controller.ui.UpdatePlayerHealth(app.data.playerData.playerOne.PlayerNum);
        app.controller.ui.UpdatePlayerScore(app.data.playerData.playerOne.PlayerNum);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {    
        //No need to write the same tests in the various player views
        SendCollisionMessage(this.gameObject, collision.gameObject);
    }

    /**
     * <summary>Moves player one's position in the supplied direction.</summary>
     * 
     * <param name="movement">The directin of movement.</param>
     */
    public void Movement(Vector2 movement)
    {
        Vector3 moveV3 = (new Vector3(movement.x, movement.y) * app.data.playerData.playerOne.MoveSpeed * 10f * Time.deltaTime) + transform.position;
        playerOneRB.MovePosition(moveV3);
    }

    /**
     * <summary>Rotates player one's sprite to face one of named directions on the compass. Also
     * will resize the player's hit box and move their melee attack trigger zone. </summary>
     * 
     * <param name="rotation">The direction of rotation.</param>
     */
    public void Rotate(Vector2 rotation)
    {
        Sprite temp = GetPlayerSpriteOnRotation(app.data.playerData.playerOne.PlayerNum, rotation);

        if (temp != null)
        {
            playerSprite.sprite = temp;
            //Adjust the position of the weapon box too
            //Adjust size of player collision box

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 100,
                                                                        gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 100);

            meleeBox.transform.localPosition = GetMeleeBoxPosOnRotate(app.data.playerData.playerOne.PlayerNum) * 1.5f;

            Quaternion newRotation = Quaternion.identity;
            newRotation.eulerAngles = GetNewMeleeBoxRotation(app.data.playerData.playerOne.PlayerNum);

            meleeBox.transform.rotation = newRotation;
        }
    }

    /**
     * <summary>Sets player one's sprite to be their attack sprite base on
     * their currently faced direction.</summary>
     */
    public void MeleeAttack()
    {

        //Execute attack animation
        switch (app.data.playerData.playerOne.CurrentDirection)
        {
            case PlayerData.Direction.North:
                playerSprite.sprite = app.data.playerData.playerOne.NorthAttackSprite;
                break;

            case PlayerData.Direction.NorthEast:
                playerSprite.sprite = app.data.playerData.playerOne.NorthEastAttackSprite;
                break;

            case PlayerData.Direction.East:
                playerSprite.sprite = app.data.playerData.playerOne.EastAttackSprite;
                break;

            case PlayerData.Direction.SouthEast:
                playerSprite.sprite = app.data.playerData.playerOne.SouthEastAttackSprite;
                break;

            case PlayerData.Direction.South:
                playerSprite.sprite = app.data.playerData.playerOne.SouthAttackSprite;
                break;

            case PlayerData.Direction.SouthWest:
                playerSprite.sprite = app.data.playerData.playerOne.SouthWestAttackSprite;
                break;

            case PlayerData.Direction.West:
                playerSprite.sprite = app.data.playerData.playerOne.WestAttackSprite;
                break;

            case PlayerData.Direction.NorthWest:
                playerSprite.sprite = app.data.playerData.playerOne.NorthWestAttackSprite;
                break;

            default:
                break;
        }
    }

    /**
     * <summary>Spawns player one's projectile, applies a force to the rigidbody in their faced
     * direction, and attaches it to the player to provide the player a score value if they kill
     * and enemy.</summary>
     */
    public void Throw()
    {
        GameObject proj = Instantiate(app.data.playerData.playerOne.Projectile, transform.position, Quaternion.identity) as GameObject;

        Vector2 throwDirecton = GetThrowVector(app.data.playerData.playerOne.PlayerNum);

        proj.GetComponent<Rigidbody2D>().AddForce(throwDirecton * 500f);

        proj.GetComponent<ProjectileView>().BelongsTo = app.data.playerData.playerOne.PlayerNum;

        //app.data.projectiles.AddProjectileToList(proj, app.data.playerData.playerOne.PlayerNum);

    }

    
}
