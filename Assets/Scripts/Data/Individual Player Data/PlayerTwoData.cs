using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoData : PlayerData, IPlayerData
{
    void Awake()
    {

        base._playerNum = PlayerNumber.PlayerNum.PlayerTwo;

        AssignClassInfo();
    }
}
