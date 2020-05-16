using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Follows player one around the world. Doesn't yet
 * have smoothing on it.</summary>
 * 
 */
public class CameraFollower : Element
{

    private void Update()
    {
        transform.position = new Vector3
                                (app.view.players.playerOne.transform.position.x,
                                 app.view.players.playerOne.transform.position.y,
                                 transform.position.z
                                 );
    }
}
