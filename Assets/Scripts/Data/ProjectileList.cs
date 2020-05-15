using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo
{
    private GameObject _projectile;
    private PlayerNumber.PlayerNum _player;

    public GameObject Projectile { get { return _projectile; } }
    public PlayerNumber.PlayerNum Player { get { return _player; } }

    public ProjectileInfo(GameObject projectile, PlayerNumber.PlayerNum player)
    {
        this._projectile = projectile;
        this._player = player;
    }

    public override string ToString()
    {
        return "Projectile: " + _projectile.name + "\nBelongs to: " + _player.ToString();
    }

}

public class ProjectileList : Element
{
    private List<ProjectileInfo> projectileList = new List<ProjectileInfo>();


    public void AddProjectileToList(GameObject projectile, PlayerNumber.PlayerNum player)
    {
        ProjectileInfo proj = new ProjectileInfo(projectile, player);
        projectileList.Add(proj);


        foreach(ProjectileInfo info in projectileList)
        {
            Debug.Log(info.ToString());
        }
    }

    public int FindProjInList(GameObject projectile)
    {
        int index = 0;

        foreach (ProjectileInfo proj in projectileList)
        {
            if (proj.Projectile.Equals(projectile))
            {
                return index;
            }
            index++;
        }
        return 0;
    }

    public ProjectileInfo RetrieveProjectileInfo(GameObject projectile)
    {
        foreach (ProjectileInfo proj in projectileList)
        {
            if (proj.Projectile.Equals(projectile))
            {
                return proj;
            }
        }
        return null;
    }

    //Call after handling collisions
    public void RemoveProjFromList(int index)
    {
        projectileList.RemoveAt(index);
    }
    

    public void RemoveProjFromList(GameObject projectile)
    {
        int index = 0;

        foreach (ProjectileInfo proj in projectileList)
        {
            if (proj.Projectile.Equals(projectile))
            {
                projectileList.RemoveAt(index);
                return;
            }
            index++;
        }
    }

}
