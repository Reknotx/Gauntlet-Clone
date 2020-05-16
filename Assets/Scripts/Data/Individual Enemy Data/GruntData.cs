using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Grunt;
        InitializeStats();
    }
}
