using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathView : EnemyView
{
    private int totalDrainedHealth = 0;
    private float rateOfDrain = 0.15f, nextDrain = 0f;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        behavior = Rush;
        _currentHealth = app.data.enemyData.death.Health;
        thisEnemysData = app.data.enemyData.death;
    }


    private void FixedUpdate()
    {
        behavior();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer > 11) return;

        if (collision.gameObject.layer >= 8 && collision.gameObject.layer <= 11)
        {
            if (Time.time >= nextDrain)
            {
                Debug.Log("Death touching player");
                nextDrain = Time.time + rateOfDrain;
                app.controller.collisions.FilterCollision(gameObject, collision.gameObject);
                totalDrainedHealth += app.data.enemyData.death.DamageToPlayer;

                if (totalDrainedHealth >= app.data.enemyData.death.maxHealthDrain)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
