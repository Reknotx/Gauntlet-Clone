using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneData : PlayerData
{
    void Start()
    {
        base._playerNum = PlayerNumber.PlayerNum.PlayerOne;

        AssignClassInfo();
    }
}
