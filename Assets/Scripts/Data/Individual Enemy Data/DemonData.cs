using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Demon;
        InitializeStats();
    }
}
