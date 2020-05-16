using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathData : EnemyData
{
    public readonly int maxHealthDrain = 200;

    private int[] variablePoints = { 1000, 2000, 1000, 4000, 2000, 6000, 8000 };

    private int variablePointIndex = 0;

    private void Awake()
    {
        base._enemyType = EnemyType.Enemy.Death;
        InitializeStats();
    }

    public void AdvancePointCounter()
    {
        variablePointIndex++;

        if (variablePointIndex == variablePoints.Length)
        {
            variablePointIndex = 0;
        }
    }

    public int GetPoints()
    {
        return variablePoints[variablePointIndex];
    }
}
