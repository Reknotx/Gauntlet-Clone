using System.Collections;
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
        Thief,
        //Death?????
    }

    public GameObject enemyToSpawn;

    [SerializeField]
    private SpawnedEnemy spawning;
}
