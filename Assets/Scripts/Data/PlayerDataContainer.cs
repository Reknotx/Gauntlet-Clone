using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataContainer : Element
{
    public PlayerOneData playerOne;
    public PlayerTwoData playerTwo;
    public PlayerThreeData playerThree;
    public PlayerFourData playerFour;

    private void Start()
    {
        if (playerOne == null) playerOne = FindObjectOfType<PlayerOneData>();
        if (playerTwo == null) playerTwo = FindObjectOfType<PlayerTwoData>();
        if (playerThree == null) playerThree = FindObjectOfType<PlayerThreeData>();
        if (playerFour == null) playerFour = FindObjectOfType<PlayerFourData>();
    }
}
