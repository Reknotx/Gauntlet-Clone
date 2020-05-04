using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneData : PlayerData
{
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
        base._playerNum = PlayerNumber.PlayerNum.PlayerOne;

        base._northSprite = playerClassData.NorthSprite;
        base._northEastSprite = playerClassData.NorthEastSprite;
        base._eastSprite = playerClassData.EastSprite;
        base._southEastSprite = playerClassData.SouthEastSprite;
        base._southSprite = playerClassData.SouthSprite;
        base._southWestSprite = playerClassData.SouthWestSprite;
        base._westSprite = playerClassData.WestSprite;
        base._northWestSprite = playerClassData.NorthWestSprite;

        base.currDirection = Direction.South;

        base._projectile = playerClassData.Projectile;
    }
}
