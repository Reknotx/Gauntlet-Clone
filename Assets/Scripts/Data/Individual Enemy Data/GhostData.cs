using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Ghost;
        InitializeStats();
    }
}
