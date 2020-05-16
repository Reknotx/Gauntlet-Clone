﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnerView : Element
{
    enum SpawnedEnemy
    {
        Demon,
        Ghost,
        Grunt,
        Sorcerer,
        Lobber,
    }

    public GameObject enemyToSpawn;

    public int spawnChance;

    public int HitPoints;

    [SerializeField]
    private SpawnedEnemy spawning;

    private void Start()
    {
        HitPoints = app.data.spawnerData.MaxHP;
        switch (spawning)
        {
            case SpawnedEnemy.Demon:
                enemyToSpawn = app.data.spawnerData.demonObj;
                break;

            case SpawnedEnemy.Ghost:
                enemyToSpawn = app.data.spawnerData.ghostObj;
                break;

            case SpawnedEnemy.Grunt:
                enemyToSpawn = app.data.spawnerData.gruntObj;
                break;

            case SpawnedEnemy.Sorcerer:
                enemyToSpawn = app.data.spawnerData.sorcererObj;
                break;

            case SpawnedEnemy.Lobber:
                enemyToSpawn = app.data.spawnerData.lobberObj;
                break;

            default:
                break;
        }

    }

    private void FixedUpdate()
    {
        if (RendererExtensions.IsVisibleFrom(gameObject.GetComponent<SpriteRenderer>(), Camera.main))
        {
            if (IsInvoking("SpawnEnemy")) return;

            InvokeRepeating("SpawnEnemy", 0.5f, 0.25f);
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    public void ReduceHP()
    {
        HitPoints--;

        if (HitPoints == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SpawnEnemy()
    {
        if (Random.Range(0, spawnChance) > 2)
        {
            return;
        }

        GameObject enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity) as GameObject;

        //switch (spawning)
        //{
        //    case SpawnedEnemy.Demon:
        //        app.view.enemies.AddEnemyToList(EnemyType.Enemy.Demon, enemy.GetComponent<EnemyView>());
        //        break;

        //    case SpawnedEnemy.Ghost:
        //        app.view.enemies.AddEnemyToList(EnemyType.Enemy.Ghost, enemy.GetComponent<EnemyView>());
        //        break;

        //    case SpawnedEnemy.Grunt:
        //        app.view.enemies.AddEnemyToList(EnemyType.Enemy.Grunt, enemy.GetComponent<EnemyView>());
        //        break;

        //    case SpawnedEnemy.Sorcerer:
        //        app.view.enemies.AddEnemyToList(EnemyType.Enemy.Sorcerer, enemy.GetComponent<EnemyView>());
        //        break;

        //    case SpawnedEnemy.Lobber:
        //        app.view.enemies.AddEnemyToList(EnemyType.Enemy.Lobber, enemy.GetComponent<EnemyView>());
        //        break;

        //    default:
        //        break;
        //}
    }
}
