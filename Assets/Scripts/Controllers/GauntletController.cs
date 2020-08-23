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

    /**
     * <summary>Adds an enemy to a list when they are in view of the camera. 
     * Said list is used to destroy the enemies that are on screen only when
     * a potion is used.</summary>
     * 
     * <param name="enemy">The enemy game object on screen.</param>
     */
    public void AddEnemyToCameraList(GameObject enemy)
    {
        app.data.objectsInView.AddToList(enemy);
    }

    /**
     * <summary>Removes an enemy from a list when they are out of view of the camera. 
     * Said list is used to destroy the enemies that are on screen only when
     * a potion is used. The passed enemy will no longer be destroyed.</summary>
     * 
     * <param name="enemy">The enemy game object out of view.</param>
     */
    public void RemoveEnemyFromCameraList(GameObject enemy)
    {
        app.data.objectsInView.RemoveFromList(enemy);
    }

}
