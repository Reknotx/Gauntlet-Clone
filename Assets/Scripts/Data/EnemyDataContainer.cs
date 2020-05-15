using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataContainer : Element
{
    public DeathData death;
    public DemonData demon;
    public GhostData ghost;
    public GruntData grunt;
    public LobberData lobber;
    public SorcererData sorcerer;
    public ThiefData thief;

    private void Start()
    {
        if (death == null) death = FindObjectOfType<DeathData>();
        if (demon == null) demon = FindObjectOfType<DemonData>();
        if (ghost == null) ghost = FindObjectOfType<GhostData>();
        if (grunt == null) grunt = FindObjectOfType<GruntData>();
        if (lobber == null) lobber = FindObjectOfType<LobberData>();
        if (sorcerer == null) sorcerer = FindObjectOfType<SorcererData>();
        if (thief == null) thief = FindObjectOfType<ThiefData>();
    }
}
