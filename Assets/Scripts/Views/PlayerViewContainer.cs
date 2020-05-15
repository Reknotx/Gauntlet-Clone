using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewContainer : Element
{
    public PlayerOneView playerOne;
    public PlayerTwoView playerTwo;
    public PlayerThreeView playerThree;
    public PlayerFourView playerFour;

    private void Start()
    {
        if (playerOne == null) playerOne = FindObjectOfType<PlayerOneView>();
        if (playerTwo == null) playerTwo = FindObjectOfType<PlayerTwoView>();
        if (playerThree == null) playerThree = FindObjectOfType<PlayerThreeView>();
        if (playerFour == null) playerFour = FindObjectOfType<PlayerFourView>();
    }
}
