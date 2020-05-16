using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Defines the type of pickup in the world</summary>
 * 
 */ 
public enum PickUpType
{
    Treasure,
    Food,
    Potion,
    Key
}

public class PickUp : Element
{
    [SerializeField]
    private PickUpType _pickUpType;

    public delegate void PickUpBehavior();

    public PickUpBehavior behavior;

    private int health = 2;

    /**
     * <summary>Returns the type of pick up that we have collided with.</summary>
     * 
     * 
     */
    public PickUpType GetPickUpType()
    {
        return _pickUpType;
    }

    /**
     * <summary>Decreases the hp of the pick up if necessary.</summary>
     * 
     * 
     */
    public void DecreaseHP()
    {
        health--;

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
