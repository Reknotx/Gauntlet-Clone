using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletData : Element
{
    public PlayerDataContainer playerData;
    public EnemyData enemy;

    private void Awake()
    {
        if (playerData == null) playerData = FindObjectOfType<PlayerDataContainer>();
        if (enemy == null) enemy = FindObjectOfType<EnemyData>();
    }
}
