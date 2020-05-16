using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerThreeRB;


    private void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerThreeRB = GetComponent<Rigidbody2D>();
        app.controller.ui.UpdatePlayerHealth(app.data.playerData.playerThree.PlayerNum);
        app.controller.ui.UpdatePlayerScore(app.data.playerData.playerThree.PlayerNum);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //No need to write the same tests in the various player views
        SendCollisionMessage(this.gameObject, collision.gameObject);
    }

    public void Movement(Vector2 movement)
    {
        Vector3 moveV3 = (new Vector3(movement.x, movement.y) * app.data.playerData.playerThree.MoveSpeed * 10f * Time.deltaTime) + transform.position;
        playerThreeRB.MovePosition(moveV3);
    }

    public void Rotate(Vector2 rotation)
    {
        Sprite temp = GetPlayerSpriteOnRotation(app.data.playerData.playerThree.PlayerNum, rotation);

        if (temp != null)
        {
            playerSprite.sprite = temp;
            //Adjust the position of the weapon box too
            //Adjust size of player collision box

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 100,
                                                                        gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 100);

            meleeBox.transform.localPosition = GetMeleeBoxPosOnRotate(app.data.playerData.playerThree.PlayerNum) * 1.5f;

            Quaternion newRotation = Quaternion.identity;
            newRotation.eulerAngles = GetNewMeleeBoxRotation(app.data.playerData.playerThree.PlayerNum);

            meleeBox.transform.rotation = newRotation;
        }
    }

    public void MeleeAttack()
    {

        //Execute attack animation
        switch (app.data.playerData.playerThree.CurrentDirection)
        {
            case PlayerData.Direction.North:
                playerSprite.sprite = app.data.playerData.playerThree.NorthAttackSprite;
                break;

            case PlayerData.Direction.NorthEast:
                playerSprite.sprite = app.data.playerData.playerThree.NorthEastAttackSprite;
                break;

            case PlayerData.Direction.East:
                playerSprite.sprite = app.data.playerData.playerThree.EastAttackSprite;
                break;

            case PlayerData.Direction.SouthEast:
                playerSprite.sprite = app.data.playerData.playerThree.SouthEastAttackSprite;
                break;

            case PlayerData.Direction.South:
                playerSprite.sprite = app.data.playerData.playerThree.SouthAttackSprite;
                break;

            case PlayerData.Direction.SouthWest:
                playerSprite.sprite = app.data.playerData.playerThree.SouthWestAttackSprite;
                break;

            case PlayerData.Direction.West:
                playerSprite.sprite = app.data.playerData.playerThree.WestAttackSprite;
                break;

            case PlayerData.Direction.NorthWest:
                playerSprite.sprite = app.data.playerData.playerThree.NorthWestAttackSprite;
                break;

            default:
                break;
        }
    }

    public void Throw()
    {
        GameObject proj = Instantiate(app.data.playerData.playerThree.Projectile, transform.position, Quaternion.identity) as GameObject;

        Vector2 throwDirecton = GetThrowVector(app.data.playerData.playerThree.PlayerNum);

        proj.GetComponent<Rigidbody2D>().AddForce(throwDirecton * 500f);

        proj.GetComponent<ProjectileView>().BelongsTo = app.data.playerData.playerThree.PlayerNum;

        //app.data.projectiles.AddProjectileToList(proj, app.data.playerData.playerThree.PlayerNum);

    }
}
