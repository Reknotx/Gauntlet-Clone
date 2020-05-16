using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileView : Element
{
    private void Start()
    {
        //activate the lobber projectile logic if on that layer

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        app.controller.collisions.FilterCollision(this.gameObject, collision.gameObject);
    }
}
