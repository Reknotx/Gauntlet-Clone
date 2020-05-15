using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletData : Element
{
    public PlayerDataContainer playerData;
    public EnemyDataContainer enemyData;
    public ProjectileList projectiles;

    private void Awake()
    {
        if (playerData == null) playerData = FindObjectOfType<PlayerDataContainer>();
        if (enemyData == null) enemyData = FindObjectOfType<EnemyDataContainer>();
    }
}
