using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : Element
{
    //Need different classes for the various weapon types?


    //Each weapon has a tigger on it and this script attached with an enum
    //signifying the damage type?

    //Need to specify the behavior of each weapon, if it is a swing or projectile.

    //Really two main forms of attack, melee and shot
    //also magic


    //Weapon needs to know when what player made the attack
    //Score needds to go to player if enemy is killed

    /* Solutions:
     * 
     * 1. Provide information of player that spawned weapon on spawning.
     * 
     * 2. Have a weapon empty gameobject in View that has four children, one
     * for each player. When player throws projectile the projectile's parent
     * will become the properly labeled child of Weapon.
     * 
     * 3. Projectiles get added to a list which will store the necessary information,
     * such as player number and the weapon itself.
     *      a. Parent of the projectiles will be an empty game object in the
     *      hierarchy which will store the list and it's references to the game objects
     *      
     *      b. When a projectile collides with anything it needs to tell the controller
     *      of the list to remove the projectile from the game world and send the
     *      collision info to the collision controller.
     */

    [SerializeField]
    private WeaponDamageType.DamageType damageType;

    private void Start()
    {
        switch (damageType)
        {
            case WeaponDamageType.DamageType.Melee:
                break;

            case WeaponDamageType.DamageType.Magic:
                break;

            case WeaponDamageType.DamageType.Shot:
                break;

            default:
                break;
        }
    }
}
