using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonView : EnemyView
{
    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        behavior = Rush;
        _currentHealth = app.data.enemyData.demon.Health;
        thisEnemysData = app.data.enemyData.demon;
    }


    private void FixedUpdate()
    {
        behavior();

        if (Vector2.Distance(transform.position, app.view.players.playerOne.transform.position) <= 6f)
        {
            behavior = FireProjectile;
        }
        else
        {
            behavior = Rush;
        }
    }
}
