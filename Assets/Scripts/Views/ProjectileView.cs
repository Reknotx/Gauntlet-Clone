using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : Element
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        app.controller.collisions.FilterCollision(this.gameObject, collision.gameObject);
    }
}
