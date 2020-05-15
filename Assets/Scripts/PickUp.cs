using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public PickUpType GetPickUpType()
    {
        return _pickUpType;
    }
}
