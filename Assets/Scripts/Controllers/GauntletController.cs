using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Main controller that holds access to each individual controller
 * in the system.</summary>
 * 
 */
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

    public void AddEnemyToCameraList(GameObject enemy)
    {
        app.data.objectsInView.AddToList(enemy);
    }

    public void RemoveEnemyFromCameraList(GameObject enemy)
    {
        app.data.objectsInView.RemoveFromList(enemy);
    }

}
