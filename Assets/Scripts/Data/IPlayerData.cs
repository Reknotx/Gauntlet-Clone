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
}
