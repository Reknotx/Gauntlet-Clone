using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : Element
{
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = new Vector3
                                (app.view.players.playerOne.transform.position.x,
                                 app.view.players.playerOne.transform.position.y,
                                 transform.position.z
                                 );
    }
}
