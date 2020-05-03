using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFourView : PlayerView
{
    private void OnCollisionEnter(Collision collision)
    {
        //Use layers to determine collision actions
        //If layer isn't the environment then send the rest of the detection towards either
        //the controller or the parent class first which will then send the collision
        //info to the right controller in collision controller.

        //ProcessCollision(PlayerNumber.PlayerNum.PlayerFour, collision.gameObject.layer);

    }
}
