using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerTwoRB;

    private void Start()
    {
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        playerTwoRB = GetComponent<Rigidbody2D>();
        app.controller.ui.UpdatePlayerHealth(app.data.playerData.playerTwo.PlayerNum);
        app.controller.ui.UpdatePlayerScore(app.data.playerData.playerTwo.PlayerNum);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //No need to write the same tests in the various player views
        SendCollisionMessage(this.gameObject, collision.gameObject);
    }

    public void Movement(Vector2 movement)
    {
        Vector3 moveV3 = (new Vector3(movement.x, movement.y) * app.data.playerData.playerTwo.MoveSpeed * 10f * Time.deltaTime) + transform.position;
        playerTwoRB.MovePosition(moveV3);
    }

    public void Rotate(Vector2 rotation)
    {
        Sprite temp = GetPlayerSpriteOnRotation(app.data.playerData.playerTwo.PlayerNum, rotation);

        if (temp != null)
        {
            playerSprite.sprite = temp;
            //Adjust the position of the weapon box too
            //Adjust size of player collision box

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 100,
                                                                        gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 100);

            meleeBox.transform.localPosition = GetMeleeBoxPosOnRotate(app.data.playerData.playerTwo.PlayerNum) * 1.5f;

            Quaternion newRotation = Quaternion.identity;
            newRotation.eulerAngles = GetNewMeleeBoxRotation(app.data.playerData.playerTwo.PlayerNum);

            meleeBox.transform.rotation = newRotation;
        }
    }

    public void MeleeAttack()
    {

        //Execute attack animation
        switch (app.data.playerData.playerTwo.CurrentDirection)
        {
            case PlayerData.Direction.North:
                playerSprite.sprite = app.data.playerData.playerTwo.NorthAttackSprite;
                break;

            case PlayerData.Direction.NorthEast:
                playerSprite.sprite = app.data.playerData.playerTwo.NorthEastAttackSprite;
                break;

            case PlayerData.Direction.East:
                playerSprite.sprite = app.data.playerData.playerTwo.EastAttackSprite;
                break;

            case PlayerData.Direction.SouthEast:
                playerSprite.sprite = app.data.playerData.playerTwo.SouthEastAttackSprite;
                break;

            case PlayerData.Direction.South:
                playerSprite.sprite = app.data.playerData.playerTwo.SouthAttackSprite;
                break;

            case PlayerData.Direction.SouthWest:
                playerSprite.sprite = app.data.playerData.playerTwo.SouthWestAttackSprite;
                break;

            case PlayerData.Direction.West:
                playerSprite.sprite = app.data.playerData.playerTwo.WestAttackSprite;
                break;

            case PlayerData.Direction.NorthWest:
                playerSprite.sprite = app.data.playerData.playerTwo.NorthWestAttackSprite;
                break;

            default:
                break;
        }
    }

    public void Throw()
    {
        GameObject proj = Instantiate(app.data.playerData.playerTwo.Projectile, transform.position, Quaternion.identity) as GameObject;

        Vector2 throwDirecton = GetThrowVector(app.data.playerData.playerTwo.PlayerNum);

        proj.GetComponent<Rigidbody2D>().AddForce(throwDirecton * 500f);

        proj.GetComponent<ProjectileView>().BelongsTo = app.data.playerData.playerTwo.PlayerNum;

        //app.data.projectiles.AddProjectileToList(proj, app.data.playerData.playerTwo.PlayerNum);

    }
}
