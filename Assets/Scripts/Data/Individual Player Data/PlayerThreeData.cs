using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeData : PlayerData, IPlayerData
{
    void Start()
    {
        
        base._playerNum = PlayerNumber.PlayerNum.PlayerThree;

        AssignClassInfo();

    }
}
