using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Element
{
    private int projectileLayer = 13;
    private int pickUpLayer = 14;
    private int enemyMinLayer = 16;
    private int enemyMaxLayer = 21;
    private int enemyProjectileMinLayer = 22;
    private int enemyProjectileMaxLayer = 24;
    private int spawnerLayer = 25;
    
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
                //The collided object is an enemy besides death
                OnPlayerWithEnemy(objOne, objTwo);
            }
            else if (objTwo.layer >= enemyProjectileMinLayer && objTwo.layer <= enemyProjectileMaxLayer)
            {
                //The collided object is an enemy projectile
                OnPlayerWithEnemyProjectile(objOne, objTwo);
            }
            else if (objTwo.layer == pickUpLayer)
            {
                //The collided object is a pickup
                OnPlayerWithPickUp(objOne, objTwo);
            }
            else if (objTwo.layer == 27)
            {
                //The collided object was a door.
                OnPlayerWithDoor(objOne, objTwo);
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
            else if (objTwo.layer == pickUpLayer)
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
        else if (objOne.layer == projectileLayer)
        {
            //the source is from a player projectile
            if (objTwo.layer >= enemyMinLayer && objTwo.layer <= enemyMaxLayer)
            {
                //The collided object is a enemy
                OnWeaponWithEnemy(objOne, objTwo);
            }
            else if (objTwo.layer == pickUpLayer)
            {
                //The collided object is a pickup
                OnWeaponWithPickUp(objOne, objTwo);
            }
            else if (objTwo.layer == spawnerLayer)
            {
                //The collided object is a spawner
                OnWeaponWithSpawner(objOne, objTwo);
            }
            else if (objTwo.layer == 26 || objTwo.layer == 27)
            {
                //The collided object is a wall or a door
                OnProjectileWithTerrain(objOne);
            }
        }
        else if (objOne.layer >= enemyProjectileMinLayer && objOne.layer <= enemyProjectileMaxLayer)
        {
            //Source is from an enemy projectile
            //This is called when the enemy projectile collides with food, treasure,
            //or walls or players
            
            if (objTwo.layer == 26 || objTwo.layer == 27)
            {
                //Collides with terrain
                OnProjectileWithTerrain(objOne);
            }
            else if (objTwo.layer >= 8 && objTwo.layer <= 11)
            {
                GameObject player = objTwo;
                GameObject enemyProjectile = objOne;
                OnPlayerWithEnemyProjectile(player, enemyProjectile);
            }
            else if (objTwo.layer == pickUpLayer)
            {
                //Collides with pickup
                OnWeaponWithPickUp(objOne, objTwo);
            }
            else if (objOne.layer == 23 && (objTwo.layer >= enemyMinLayer && objTwo.layer <= enemyMaxLayer))
            {
                //Demon projectile that collides with enemy
                OnDemonProjectileWithEnemy(objOne, objTwo);
            }
        }
        else if (objOne.layer == 15)
        {
            //The source is from death
            OnDeathWithPlayer(objOne, objTwo);
        }
    }

    /**
     * <summary>Deals damage to player when they collide with an
     * enemy object.</summary>
     * 
     * <param name="player">The player game object.</param>
     * <param name="enemy">The enemy game object</param>
     */
    private void OnPlayerWithEnemy(GameObject player, GameObject enemy)
    {
        PlayerData playerData = GetPlayerData(player);
        EnemyData enemyData = GetEnemyData(enemy);

        playerData.Health -= enemyData.DamageToPlayer;

        if (enemyData is GhostData)
        {
            Destroy(enemy.gameObject);
        }

        UpdatePlayerHUDS(playerData.PlayerNum);
    }


    /**
     * <summary>Deals damage to player when they collide with an
     * enemy projectile object.</summary>
     * 
     * <param name="player">The player game object.</param>
     * <param name="enemyProjectile">The enemy projectile game object</param>
     */
    private void OnPlayerWithEnemyProjectile(GameObject player, GameObject enemyProjectile)
    {
        PlayerData playerData = GetPlayerData(player);
        EnemyData enemyData = null;

        if (enemyProjectile.layer == 22)
        {
            //Lobber projectile
            enemyData = GetEnemyData(EnemyType.Enemy.Lobber);
        }
        else if (enemyProjectile.layer == 23)
        {
            //Demon projectile
            enemyData = GetEnemyData(EnemyType.Enemy.Demon);
        }
        else if (enemyProjectile.layer == 24)
        {
            //Sorcerer projectile
            enemyData = GetEnemyData(EnemyType.Enemy.Sorcerer);
        }

        playerData.Health -= enemyData.DamageToPlayer;

        RemoveProjectile(enemyProjectile);
        UpdatePlayerHUDS(playerData.PlayerNum);
    }

    /**
     * <summary>Collects a game object on player interaction and updates
     * the player's data appropriately.</summary>
     * 
     * <param name="player">The player game object.</param>
     * <param name="pickUp">The pick up game object.</param>
     */
    private void OnPlayerWithPickUp(GameObject player, GameObject pickUp)
    {
        PlayerData playerData = GetPlayerData(player);
        PickUpType pickUpType = pickUp.GetComponent<PickUp>().GetPickUpType();

        switch (pickUpType)
        {
            case PickUpType.Treasure:
                playerData.Score += 100;
                app.controller.ui.UpdatePlayerScore(playerData.PlayerNum);
                break;

            case PickUpType.Food:
                playerData.Health += 100;
                app.controller.ui.UpdatePlayerHealth(playerData.PlayerNum);
                break;

            case PickUpType.Potion:
                playerData.Potions++;
                break;

            case PickUpType.Key:
                playerData.CollectedKeys++;
                break;

            default:
                break;
        }

        Destroy(pickUp);
    }

    /**
     * <summary>When player interacts with a door the door is opened
     * if that player has a key in their inventory.</summary>
     * 
     * <param name="player">The player game object.</param>
     * <param name="door">The door game object.</param>
     * 
     */
    private void OnPlayerWithDoor(GameObject player, GameObject door)
    {
        PlayerData playerData = GetPlayerData(player);

        if (playerData.CollectedKeys > 0)
        {
            Destroy(door);
            playerData.CollectedKeys--;
        }
    }

    /**
     * <summary>Deals damage to an enemy when a player weapon interacts
     * with them. Some enemies can only be killed by certain weapons. Necessary
     * player information that made the attack is automatically acquired.</summary>
     * 
     * <param name="weapon">The player weapon game object.</param>
     * <param name="enemy">The enemy game object.</param>
     */
    private void OnWeaponWithEnemy(GameObject weapon, GameObject enemy)
    {
        Element weaponScript = weapon.GetComponent<Element>();
        EnemyData enemyData = GetEnemyData(enemy);
        EnemyView enemyView = enemy.GetComponent<EnemyView>();
        PlayerData playerData = null;
        PlayerNumber.PlayerNum player = PlayerNumber.PlayerNum.PlayerOne;

        if (weaponScript is MeleeWeaponView)
        {
            //Handle all logic for melee weapons here
            /** Notes
             * 1. Ghost's and Death can't be killed with melee attacks
             */
            MeleeWeaponView playerWeapon = weapon.GetComponent<MeleeWeaponView>();

            player = playerWeapon.BelongsTo;

            playerData = GetPlayerData(player);

            if (enemy.layer == 16 || (enemy.layer >= 18 && enemy.layer <= enemyMaxLayer))
            {
                enemyView.CurrentHealth -= playerData.Melee;
            }
        }
        else if (weaponScript is ProjectileView)
        {
            //Handle all logic for projectile weapons here
            //ProjectileInfo projectileInfo = app.data.projectiles.RetrieveProjectileInfo(weapon);

            //player = projectileInfo.Player;
            ProjectileView playerProjectile = weapon.GetComponent<ProjectileView>();

            playerData = GetPlayerData(playerProjectile.BelongsTo);

            if (enemy.layer >= 16 && enemy.layer <= enemyMaxLayer)
            {
                enemyView.CurrentHealth -= playerData.Shot;
            }

            RemoveProjectile(weapon);
        }


        if (enemyView.CurrentHealth <= 0)
        {
            playerData.Score += enemyData.ScoreOnDeath;
            Destroy(enemy.gameObject);
        }

        UpdatePlayerHUDS(player);
    }

    /**
     * <summary>Handles interactions between a player weapon and a pick up.</summary>
     * 
     * <param name="weapon">The player weapon game object.</param>
     * <param name="pickUp">The pick up game object.</param>
     * 
     */
    private void OnWeaponWithPickUp(GameObject weapon, GameObject pickUp)
    {
        if (pickUp.GetComponent<PickUp>().GetPickUpType() == PickUpType.Key) return;

        if (weapon.layer == projectileLayer || (weapon.layer >= enemyProjectileMinLayer && weapon.layer <= enemyProjectileMaxLayer))
        {
            //was a projectile
            RemoveProjectile(weapon);
        }

        if (pickUp.GetComponent<PickUp>().GetPickUpType() == PickUpType.Food) pickUp.GetComponent<PickUp>().DecreaseHP();
    }

    /**
     * <summary>Called when player weapon collides with an enemy
     * spawner.</summary>
     * 
     * <param name="weapon">The player weapon game object</param>
     * <param name="spawner">The spawner that was hit.</param>
     * 
     */
    private void OnWeaponWithSpawner(GameObject weapon, GameObject spawner)
    {
        spawner.GetComponent<EnemySpawnerView>().ReduceHP();

        if (weapon.layer == projectileLayer)
        {
            RemoveProjectile(weapon);
        }
    }

    /**
     * <summary>Called by projectile hitting a wall.</summary
     * 
     * <param name="weapon">The projectile game object.</param>
     */
    private void OnProjectileWithTerrain(GameObject weapon)
    {
        RemoveProjectile(weapon);
    }

    /**
     * <summary>A demon projectile has struck another enemy in the world and deals
     * damage to them.</summary>
     * 
     * <param name="projectile">The enemy projectile.</param>
     * <param name="enemy">The other enemy game object.</param>
     * 
     */
    private void OnDemonProjectileWithEnemy(GameObject projectile, GameObject enemy)
    {
        EnemyView enemyView = enemy.GetComponent<EnemyView>();
        RemoveProjectile(projectile);

        enemyView.CurrentHealth -= app.data.enemyData.demon.DamageToPlayer;
    }

    /**
     * <summary>Death has collided with a player and starts rapidly draining health.</summary>
     * 
     * <param name="death">The death game object.</param>
     * <param name="player">The player game object.</param>
     */

    private void OnDeathWithPlayer(GameObject death, GameObject player)
    {
        Debug.Log("On Death With Player");

        PlayerData playerData = GetPlayerData(player);

        playerData.Health -= app.data.enemyData.death.DamageToPlayer;

        Debug.Log(playerData.Health.ToString());

        UpdatePlayerHUDS(playerData.PlayerNum);
    }

    /**
     * <summary>Obtain player data based on layers. Layer 8 is player one
     * and layer 11 is player four.</summary>
     * 
     * <param name="player">The player game object.</param>
     * 
     * <returns>A reference to the player data script for the
     * specific player.</returns>
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
     * 
     * <returns>A reference to the player data script for the
     * specific player.</returns>
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

    /**
     * <summary>Obtains enemy data based on the view that is 
     * attached to the game object.</summary>
     * 
     * <param name="enemy">The enemy game object we want data
     * on.</param>
     * 
     * <returns>A reference to the enemy data script for the specific
     * enemy.</returns>
     */
    private EnemyData GetEnemyData(GameObject enemy)
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

    /**
     * <summary>Obtains enemy data based on the provided EnemyType
     * enum value passed in.</summary>
     * 
     * <param name="enemy">The enemy type we want data on.</param>
     * 
     * <returns>A reference to the enemy data script for the specific
     * enemy.</returns>
     */
    private EnemyData GetEnemyData(EnemyType.Enemy enemy)
    {
        EnemyData enemyData = null;

        switch (enemy)
        {
            case EnemyType.Enemy.Death:
                enemyData = app.data.enemyData.death;
                break;

            case EnemyType.Enemy.Demon:
                enemyData = app.data.enemyData.demon;
                break;

            case EnemyType.Enemy.Grunt:
                enemyData = app.data.enemyData.grunt;
                break;

            case EnemyType.Enemy.Ghost:
                enemyData = app.data.enemyData.ghost;
                break;

            case EnemyType.Enemy.Lobber:
                enemyData = app.data.enemyData.lobber;
                break;

            case EnemyType.Enemy.Sorcerer:
                enemyData = app.data.enemyData.sorcerer;
                break;

            case EnemyType.Enemy.Thief:
                enemyData = app.data.enemyData.thief;
                break;

            default:
                break;
        }

        return enemyData;
    }

    /**
     * <summary>Deletes a projectile from the world.</summary>
     * 
     * <param name="projectile">The projectile we want to delete.</param>
     * 
     */
    private void RemoveProjectile(GameObject projectile)
    {
        //app.data.projectiles.RemoveProjFromList(projectile);
        Destroy(projectile);
    }

    /**
     * <summary>Updates the health and score text information
     * in the HUD for the player.</summary>
     * 
     * <param name="player">The player whose info we want
     * to update on screen.</param>
     * 
     */
    private void UpdatePlayerHUDS(PlayerNumber.PlayerNum player)
    {
        app.controller.ui.UpdatePlayerHealth(player);
        app.controller.ui.UpdatePlayerScore(player);
    }
}
