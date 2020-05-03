using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoView : PlayerView
{
    private void OnCollisionEnter(Collision collision)
    {
        //Use layers to determine collision action
        //If layer isn't the environment then send the rest of the detection towards either
        //the controller or the parent class first which will then send the collision
        //info to the right controller in collision controller.


        //ProcessCollision(PlayerNumber.PlayerNum.PlayerTwo, collision.gameObject.layer);

    }
}
