using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerData
{
    int Health { get; set; }

    int Score { get; set; }

    int TokensUsed { get; set; }

    int HealthGain { get; }

    int Armor { get; }

    int Shot { get; }

    int Magic { get; }

    int Melee { get; }

    int MoveSpeed { get; }

    Sprite NorthSprite { get; }

    Sprite NorthEastSprite { get; }

    Sprite EastSprite { get; }

    Sprite SouthEastSprite { get; }

    Sprite SouthSprite { get; }

    Sprite SouthWestSprite { get; }

    Sprite WestSprite { get; }

    Sprite NorthWestSprite { get; }

    GameObject Projectile { get; }
}
