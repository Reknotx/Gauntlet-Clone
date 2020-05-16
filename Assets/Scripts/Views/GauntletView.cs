using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletView : Element
{
    public PlayerViewContainer players;
    public UIView ui;
    //public EnemyViewContainer enemies;

    private void Start()
    {
        if (players == null) players = FindObjectOfType<PlayerViewContainer>();
        if (ui == null) ui = FindObjectOfType<UIView>();
        //if (enemies == null) enemies = FindObjectOfType<EnemyViewContainer>();
    }
}
