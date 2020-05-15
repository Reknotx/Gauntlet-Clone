using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Every enemy that exists in the world has access to their 
 * enemy data script that contains their base stats.
 * 
 * Every enemy will also contain their own local stats that
 * represents their status in the world in relation to their
 * base stats.
 * 
 * Example: 
 *      Enemy data contains max HP
 *      Enemy view contains current HP
 */

public class EnemyViewContainer : Element
{
    //Are these even needed?
    public List<DeathView> deaths = new List<DeathView>();
    public List<DemonView> demons = new List<DemonView>();
    public List<GruntView> grunts = new List<GruntView>();
    public List<GhostView> ghosts = new List<GhostView>();
    public List<LobberView> lobbers = new List<LobberView>();
    public List<SorcererView> sorcerers = new List<SorcererView>();
    public List<ThiefView> thieves = new List<ThiefView>();

    /**
     * <summary>Add enemy to their associated list when they are
     * spawned.</summary>
     * 
     * <param name="enemy">The enemy that was spawned.</param>
     */
    public void AddEnemyToList(EnemyType.Enemy enemyType, EnemyView enemy)
    {
        switch (enemyType)
        {
            case EnemyType.Enemy.Death:
                DeathView death = enemy.gameObject.GetComponent<DeathView>();
                deaths.Add(death);
                break;

            case EnemyType.Enemy.Demon:
                DemonView demon = enemy.gameObject.GetComponent<DemonView>();
                demons.Add(demon);
                break;

            case EnemyType.Enemy.Grunt:
                GruntView grunt = enemy.gameObject.GetComponent<GruntView>();
                grunts.Add(grunt);
                break;

            case EnemyType.Enemy.Ghost:
                GhostView ghost = enemy.gameObject.GetComponent<GhostView>();
                ghosts.Add(ghost);
                break;

            case EnemyType.Enemy.Lobber:
                LobberView lobber = enemy.gameObject.GetComponent<LobberView>();
                lobbers.Add(lobber);
                break;

            case EnemyType.Enemy.Sorcerer:
                SorcererView sorcerer = enemy.gameObject.GetComponent<SorcererView>();
                sorcerers.Add(sorcerer);
                break;

            case EnemyType.Enemy.Thief:
                ThiefView thief = enemy.gameObject.GetComponent<ThiefView>();
                thieves.Add(thief);
                break;

            default:
                break;
        }
    }

    //public void FindEnemyInList

    /**
     * <summary>Remove the enemy from the list. Called when enemy
     * HP hits zero or when kill conditions are met.</summary>
     * 
     * <param name="enemy">The enemy to remove.</param>
     */
    public void RemoveEnemyFromList(EnemyView enemy)
    {
        int index = 0;

        if (enemy is DeathView)
        {
            foreach (DeathView death in deaths)
            {
                if (enemy.Equals(death))
                {
                    deaths.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is DemonView)
        {
            foreach (DemonView demon in demons)
            {
                if (enemy.Equals(demon))
                {
                    demons.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is GruntView)
        {
            foreach (GruntView grunt in grunts)
            {
                if (enemy.Equals(grunt))
                {
                    grunts.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is GhostView)
        {
            foreach (GhostView ghost in ghosts)
            {
                if (enemy.Equals(ghost))
                {
                    ghosts.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is LobberView)
        {
            foreach (LobberView lobber in lobbers)
            {
                if (enemy.Equals(lobber))
                {
                    lobbers.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is SorcererView)
        {
            foreach (SorcererView sorcerer in sorcerers)
            {
                if (enemy.Equals(sorcerer))
                {
                    sorcerers.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        if (enemy is ThiefView)
        {
            foreach (ThiefView thief in thieves)
            {
                if (enemy.Equals(thief))
                {
                    thieves.RemoveAt(index);
                    return;
                }
                index++;
            }
        }
    }

    /**
     * <summary>Returns the exact enemy from the list of enemies
     * that are currently alive to update their local stats.</summary>
     * 
     * <param name="enemy">The type of enemy to search for.</param>
     * <param name="enemyObj">The reference to the object in the world.</param>
     */
    public EnemyView GetEnemy(EnemyType.Enemy enemy, GameObject enemyObj)
    {
        EnemyView temp = enemyObj.GetComponent<EnemyView>();
        return temp;

        //switch (enemy)
        //{
        //    case EnemyType.Enemy.Death:
                
        //        break;

        //    case EnemyType.Enemy.Demon:
        //        break;

        //    case EnemyType.Enemy.Grunt:
        //        break;

        //    case EnemyType.Enemy.Ghost:
        //        break;

        //    case EnemyType.Enemy.Lobber:
        //        break;

        //    case EnemyType.Enemy.Sorcerer:
        //        break;

        //    case EnemyType.Enemy.Thief:
        //        break;

        //    default:
        //        break;
        //}
    }
}
