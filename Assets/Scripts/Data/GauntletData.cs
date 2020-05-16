using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletData : Element
{
    public PlayerDataContainer playerData;
    public EnemyDataContainer enemyData;
    //public ProjectileList projectiles;
    public EnemySpawnerData spawnerData;
    public ObjectsInCameraView objectsInView;

    private void Awake()
    {
        if (playerData == null) playerData = FindObjectOfType<PlayerDataContainer>();
        if (enemyData == null) enemyData = FindObjectOfType<EnemyDataContainer>();
        //if (projectiles == null) projectiles = FindObjectOfType<ProjectileList>();
        if (spawnerData == null) spawnerData = FindObjectOfType<EnemySpawnerData>();
        if (objectsInView == null) objectsInView = FindObjectOfType<ObjectsInCameraView>();
    }
}
