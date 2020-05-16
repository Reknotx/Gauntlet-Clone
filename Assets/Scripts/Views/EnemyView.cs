using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : Element
{
    protected Rigidbody2D enemyRB;

    public enum AIBehavior
    {
        Rush,
        Projectile
    }

    protected float projectileRate = 1f, nextProjectile = 0f;

    [SerializeField]
    protected GameObject projectile;

    protected int _currentHealth;

    public delegate void AIAction();

    public AIAction behavior;

    protected EnemyData thisEnemysData;

    protected AIBehavior AI;

    public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }

    /**
     * <summary>Basic AI behavior for enemy to run towards player's position.</summary>
     */
    public void Rush()
    {
        //Vector2 direction = app.view.players.playerOne.transform.position - ;

        enemyRB.MovePosition(Vector2.MoveTowards(transform.position, app.view.players.playerOne.transform.position, 0.1f));
    }

    /**
     * <summary>Basic AI behavior for enemy to fire projectils at the player's
     * current position.</summary>
     * 
     */
    public void FireProjectile()
    {
        //Spawn a projectile in the direction of the player.
        if (Time.time >= nextProjectile)
        {
            nextProjectile = Time.time + projectileRate;

            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

            Vector2 angle = app.view.players.playerOne.transform.position - transform.position;

            proj.GetComponent<Rigidbody2D>().AddForce(angle.normalized * 200f);

        }
    }

    /**
     * <summary>When an enemy is visible they are added to the camera list
     * that holds references to all visible enemy objects.</summary>
     * 
     */
    public void OnBecameVisible()
    {
        app.controller.AddEnemyToCameraList(gameObject);
    }

    /**
     * <summary>When an enemy is no longer visible they are removed from 
     * the camera list that holds references to all visible enemy objects.</summary>
     * 
     */
    public void OnBecameInvisible()
    {
        app.controller.RemoveEnemyFromCameraList(gameObject);
    }
}
