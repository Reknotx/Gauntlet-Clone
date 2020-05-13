using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Element
{
    public void FilterCollision()
    {

    }

    public void OnPlayerWithEnemy(PlayerData playerData, EnemyData enemyData)
    {
        playerData.Health -= enemyData.DamageToPlayer;
    }

    public void OnPlayerWithEnemyProjectile(PlayerData playerData, EnemyData enemyData)
    {
        
    }

    public void OnPlayerWithFood(PlayerData playerData)
    {
        
    }

    public void OnWeaponWithEnemy(PlayerData playerData, EnemyData enemyData)
    {

    }

    public void OnWeaponWithFood(PlayerData playerData, EnemyData enemyData)
    {

    }

    public void OnWeaponWithTerrain(PlayerData playerData, EnemyData enemyData)
    {

    }

    public void OnWeaponWithTreasure(PlayerData playerData)
    {
        //??????????????
    }
}
