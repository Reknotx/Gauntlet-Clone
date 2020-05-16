using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInCameraView : Element
{
    public List<GameObject> enemies = new List<GameObject>();

    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

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
