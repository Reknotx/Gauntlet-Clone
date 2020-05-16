using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefView : EnemyView
{
    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        behavior = Rush;
        _currentHealth = app.data.enemyData.thief.Health;
        thisEnemysData = app.data.enemyData.thief;
    }


    private void FixedUpdate()
    {
        behavior();
    }
}
