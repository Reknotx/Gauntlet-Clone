using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFourData : PlayerData, IPlayerData
{

    void Awake()
    {

        base._playerNum = PlayerNumber.PlayerNum.PlayerFour;

        AssignClassInfo();
    }
}
