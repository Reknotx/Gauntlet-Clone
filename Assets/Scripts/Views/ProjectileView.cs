using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileView : Element
{
    private PlayerNumber.PlayerNum _belongsTo;

    public PlayerNumber.PlayerNum BelongsTo { get { return _belongsTo; } set { _belongsTo = value; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        app.controller.collisions.FilterCollision(this.gameObject, collision.gameObject);
    }
}
