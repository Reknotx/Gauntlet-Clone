using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberData : EnemyData
{
    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Lobber;
        InitializeStats();
    }
}
