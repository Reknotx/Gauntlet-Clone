using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Sorcerer;
        InitializeStats();
    }
}
