using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletController : Element
{
    public CollisionController collisions;
    public InputController input;
    public UIController ui;

    private void Awake()
    {
        if (collisions == null) collisions = FindObjectOfType<CollisionController>();
        if (input == null) input = FindObjectOfType<InputController>();
        if (ui == null) ui = FindObjectOfType<UIController>();
    }
}
