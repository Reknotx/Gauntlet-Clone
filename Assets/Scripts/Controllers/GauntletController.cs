using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletController : Element
{
    public CollisionController collisions;
    public InputController input;

    private void Awake()
    {
        if (collisions == null) collisions = FindObjectOfType<CollisionController>();
        if (input == null) input = FindObjectOfType<InputController>();
    }
}
