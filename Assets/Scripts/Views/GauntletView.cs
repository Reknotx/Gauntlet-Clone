using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletView : Element
{
    public PlayerViewContainer players;
    public WeaponView weapon;

    private void Start()
    {
        if (players == null) players = FindObjectOfType<PlayerViewContainer>();
    }
}
