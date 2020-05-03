using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFourData : PlayerData, IPlayerData
{
    public int Health { get { return base._health; } set { base._health = value; } }
    public int Score { get { return base._score; } set { base._score = value; } }
    public int TokensUsed { get { return base._tokensUsed; } set { base._tokensUsed++; } }

    public int HealthGain { get { return base._healthGain; } }

    public int Armor { get { return base._armor; } }

    public int Shot { get { return base._shotStrength; } }

    public int Magic { get { return base._magicStrength; } }

    public int Melee { get { return base._meleeStrength; } }

    public int MoveSpeed { get { return base._moveSpeed; } }

    public PlayerNumber.PlayerNum PlayerNum { get { return base._playerNum; } }

    void Start()
    {
        base._health = playerClassData.StartingHealth;
        base._healthGain = playerClassData.HealthGain;
        base._score = 0;
        base._tokensUsed = 1;
        base._armor = playerClassData.Armor;
        base._shotStrength = playerClassData.Shot;
        base._magicStrength = playerClassData.Magic;
        base._meleeStrength = playerClassData.Melee;
        base._moveSpeed = playerClassData.Speed;
        base._playerNum = PlayerNumber.PlayerNum.PlayerFour;
    }
}
