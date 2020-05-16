using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostView : EnemyView
{
    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        behavior = Rush;
        _currentHealth = app.data.enemyData.ghost.Health;
        thisEnemysData = app.data.enemyData.ghost;

    }

    private void FixedUpdate()
    {
        behavior();
        //ghostRB.MovePosition(Vector2.MoveTowards(transform.position, app.view.players.playerOne.transform.position, 0.1f));
    }
}
