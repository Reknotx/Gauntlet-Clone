using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerOneRB;

    public GameObject meleeBox;

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
        Sprite temp = GetPlayerSpriteOnRotation(app.data.playerData.playerOne.PlayerNum, rotation);

        if (temp != null)
        {
            playerSprite.sprite = temp;
            //Adjust the position of the weapon box too
            //Adjust size of player collision box

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 100,
                                                                        gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / 100);

            Debug.Log(new Vector3(meleeBox.transform.localPosition.x, meleeBox.transform.localPosition.y).magnitude);

            meleeBox.transform.localPosition = GetMeleeBoxPosOnRotate(app.data.playerData.playerOne.PlayerNum) * 1.5f;

            Quaternion newRotation = Quaternion.identity;
            newRotation.eulerAngles = GetNewMeleeBoxRotation(app.data.playerData.playerOne.PlayerNum);

            meleeBox.transform.rotation = newRotation;
        }
    }

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

    public void Throw()
    {
        GameObject proj = Instantiate(app.data.playerData.playerOne.Projectile, transform.position, Quaternion.identity) as GameObject;

        Vector2 throwDirecton = GetThrowVector(app.data.playerData.playerOne.PlayerNum);

        proj.GetComponent<Rigidbody2D>().AddForce(throwDirecton * 500f);

        app.view.projectiles.AddProjectileToList(proj, app.data.playerData.playerOne.PlayerNum);

    }

    
}
