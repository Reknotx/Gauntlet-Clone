using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneView : PlayerView
{
    private SpriteRenderer playerSprite;

    private Rigidbody2D playerOneRB;

    public Sprite NorthAttack;
    public Sprite NorthEastAttack;
    public Sprite EastAttack;
    public Sprite SouthEastAttack;
    public Sprite SouthAttack;
    public Sprite SouthWestAttack;
    public Sprite WestAttack;
    public Sprite NorthWestAttack;


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
        }
    }

    public void MeleeAttack()
    {

        //Execute attack animation
        switch (app.data.playerData.playerOne.CurrentDirection)
        {
            case PlayerData.Direction.North:
                playerSprite.sprite = NorthAttack;
                break;

            case PlayerData.Direction.NorthEast:
                playerSprite.sprite = NorthEastAttack;
                break;

            case PlayerData.Direction.East:
                playerSprite.sprite = EastAttack;
                break;

            case PlayerData.Direction.SouthEast:
                playerSprite.sprite = SouthEastAttack;
                break;

            case PlayerData.Direction.South:
                playerSprite.sprite = SouthAttack;
                break;

            case PlayerData.Direction.SouthWest:
                playerSprite.sprite = SouthWestAttack;
                break;

            case PlayerData.Direction.West:
                playerSprite.sprite = WestAttack;
                break;

            case PlayerData.Direction.NorthWest:
                playerSprite.sprite = NorthWestAttack;
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

    }

    
}
