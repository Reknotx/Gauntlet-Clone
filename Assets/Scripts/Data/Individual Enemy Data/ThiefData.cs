using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Thief;
        InitializeStats();
    }
}
