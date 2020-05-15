using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneData : PlayerData
{
    void Awake()
    {
        base._playerNum = PlayerNumber.PlayerNum.PlayerOne;

        AssignClassInfo();
    }
}
