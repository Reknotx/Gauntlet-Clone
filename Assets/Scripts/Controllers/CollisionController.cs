using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Element
{
    private int pickUpMinLayer = 14;
    private int pickUpMaxLayer = 17;
    private int enemyMinLayer = 18;
    private int enemyMaxLayer = 27;
    private int spawnerLayer = 28;
    /**
     * <summary>Filters the collision between two game objects in the world
     * and exectutes the necessary logic based on the layer they
     * occupy.</summary>
     * <param name="objOne">The source object.</param>
     * <param name="objTwo">The object that was collided with.</param>
     */
    public void FilterCollision(GameObject objOne, GameObject objTwo)
    {
        if (objOne.layer >= 8 && objOne.layer <= 11)
        {
            //The source came from a player
            if (objTwo.layer >= enemyMinLayer && objTwo.layer <= enemyMaxLayer)
            {
                //The collided object is an enemy
                OnPlayerWithEnemy(objOne, objTwo);
            }
            else if (objTwo.layer >= pickUpMinLayer && objTwo.layer <= pickUpMaxLayer)
            {
                //The collided object is a pickup
                OnPlayerWithPickUp(objOne, objTwo);
            }
        }
        else if (objOne.layer == 12)
        {
            //The source is from a player melee attack
            if (objTwo.layer >= enemyMinLayer && objTwo.layer <= enemyMaxLayer)
            {
                //The collided object is a enemy
                OnWeaponWithEnemy(objOne, objTwo);
            }
            else if (objTwo.layer >= pickUpMinLayer && objTwo.layer <= pickUpMaxLayer)
            {
                //The collided object is a pickup
                OnWeaponWithPickUp(objOne, objTwo);
            }
            else if (objTwo.layer == spawnerLayer)
            {
                //The collided object is a spawner
                OnWeaponWithSpawner(objOne, objTwo);
            }
        }
        else if (objOne.layer == 13)
        {
            //the source is from a player projectile
            if (objTwo.layer >= enemyMinLayer && objTwo.layer <= enemyMaxLayer)
            {
                //The collided object is a enemy
                OnWeaponWithEnemy(objOne, objTwo);
            }
            else if (objTwo.layer >= pickUpMinLayer && objTwo.layer <= pickUpMaxLayer)
            {
                //The collided object is a pickup
                OnWeaponWithPickUp(objOne, objTwo);
            }
            else if (objTwo.layer == spawnerLayer)
            {
                //The collided object is a spawner
                OnWeaponWithSpawner(objOne, objTwo);
            }
            else if (objTwo.layer == 29 || objTwo.layer == 30)
            {
                //The collided object is a wall or a door
                OnWeaponWithTerrain(objOne);
            }
        }
    }

    private void OnPlayerWithEnemy(GameObject player, GameObject enemy)
    {
        PlayerData playerData = GetPlayerData(player);
        EnemyData enemyData = GetEnemyData(enemy);

        Debug.Log(enemyData.ToString());

        if (enemyData is GhostData)
        {
            playerData.Health -= app.data.enemyData.ghost.DamageToPlayer;
            Destroy(enemy.gameObject);
        }

        app.controller.ui.UpdatePlayerHealth(playerData.PlayerNum);
    }

    private void OnPlayerWithEnemyProjectile(GameObject player, GameObject enemyProjectile)
    {
        //MNight be void 

    }

    private void OnPlayerWithPickUp(GameObject player, GameObject pickUp)
    {
        PlayerData playerData = GetPlayerData(player);
        PickUpType pickUpType = pickUp.GetComponent<PickUp>().GetPickUpType();

        switch (pickUpType)
        {
            case PickUpType.Treasure:
                playerData.Score += 100;
                app.controller.ui.UpdatePlayerHealth(playerData.PlayerNum);
                break;

            case PickUpType.Food:
                playerData.Health += 100;
                app.controller.ui.UpdatePlayerScore(playerData.PlayerNum);
                break;

            case PickUpType.Potion:
                break;

            case PickUpType.Key:
                break;

            default:
                break;
        }
    }

    private void OnWeaponWithEnemy(GameObject weapon, GameObject enemy)
    {
        Element weaponScript = weapon.GetComponent<Element>();
        EnemyData enemyData = GetEnemyData(enemy);
        PlayerData playerData = null;

        if (weaponScript is MeleeWeaponView)
        {
            //Handle all logic for melee weapons here
            /** Notes
             * 1. Ghost's and Death can't be killed with melee attacks
             * 
             * 
             * 
             */

            MeleeWeaponView playerWeapon = weapon.GetComponent<MeleeWeaponView>();
            playerData = GetPlayerData(playerWeapon.BelongsTo);


        }
        else if (weaponScript is ProjectileView)
        {
            //Handle all logic for projectile weapons here
            ProjectileInfo projectileInfo = app.data.projectiles.RetrieveProjectileInfo(weapon);
            playerData = GetPlayerData(projectileInfo.Player);

            if (enemy.layer == 20)
            {
                //Ghost enemy
                Destroy(enemy.gameObject);
            }

            app.data.projectiles.RemoveProjFromList(projectileInfo.Projectile);

            Destroy(weapon);
        }
    }

    private void OnWeaponWithPickUp(GameObject weapon, GameObject pickUp)
    {
        if (weapon.layer == 13)
        {
            //Is a projectile.
        }
    }

    private void OnWeaponWithSpawner(GameObject weapon, GameObject spawnwer)
    {

    }

    /**
     * <summary>Called by projectile hitting a wall.</summary
     */
    private void OnWeaponWithTerrain(GameObject weapon)
    {
        app.data.projectiles.RemoveProjFromList(weapon);
        Destroy(weapon);
    }

    /**
     * <summary>Obtain player data based on layers. Layer 8 is player one
     * and layer 11 is player four.</summary>
     * 
     * <param name="player">The player game object.</param>
     */
    private PlayerData GetPlayerData(GameObject player)
    {
        PlayerData playerData = null;

        switch (player.layer)
        {
            case 8:
                playerData = app.data.playerData.playerOne;
                break;

            case 9:
                playerData = app.data.playerData.playerTwo;
                break;

            case 10:
                playerData = app.data.playerData.playerThree;
                break;

            case 11:
                playerData = app.data.playerData.playerFour;
                break;

            default:
                break;
        }

        return playerData;
    }

    /**
     * <summary>Obtain player data based on player number enum. 
     * This value is stored in weapons indicating the player
     * that they belong to as well as projectile list.</summary>
     * 
     * <param name="player">The player game object.</param>
     */
    private PlayerData GetPlayerData(PlayerNumber.PlayerNum player)
    {
        PlayerData playerData = null;

        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                playerData = app.data.playerData.playerOne;
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                playerData = app.data.playerData.playerTwo;
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                playerData = app.data.playerData.playerThree;
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                playerData = app.data.playerData.playerFour;
                break;

            default:
                break;
        }

        return playerData;
    }

    public EnemyData GetEnemyData(GameObject enemy)
    {
        EnemyView enemyView = enemy.GetComponent<EnemyView>();
        EnemyData enemyData = null;

        if (enemyView is DeathView) return app.data.enemyData.death;

        if (enemyView is DemonView) return app.data.enemyData.demon;

        if (enemyView is GhostView) return app.data.enemyData.ghost;

        if (enemyView is GruntView) return app.data.enemyData.grunt;

        if (enemyView is LobberView) return app.data.enemyData.lobber;

        if (enemyView is SorcererView) return app.data.enemyData.sorcerer;

        if (enemyView is ThiefView) return app.data.enemyData.thief;

        return enemyData;
    }
}
