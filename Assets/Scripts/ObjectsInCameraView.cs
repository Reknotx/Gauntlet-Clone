using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInCameraView : Element
{
    public List<GameObject> enemies = new List<GameObject>();

    /**
     * <summary>Adds enemies to a list when they are in
     * the view of the camera.</summary>
     * 
     */
    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    /**
     * <summary>Removes an enemy from a list when they are 
     * no longer in the view of the camera.</summary>
     * 
     */
    public void RemoveFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    /**
     * <summary>Destroys all enemies that are currently
     * viewable on the screen. Only called when player uses a potion.</summary>
     * 
     */
    public void KillAllEnemies()
    {
        List<GameObject> deleteEnemies = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            deleteEnemies.Add(enemy);
        }

        foreach (GameObject enemy in deleteEnemies)
        {
            enemies.Remove(enemy);
            Destroy(enemy);
        }
    }
}
