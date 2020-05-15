using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Element
{
    public void UpdatePlayerHealth(PlayerNumber.PlayerNum player)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.view.ui.UpdatePlayerOneHealth();
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                app.view.ui.UpdatePlayerTwoHealth();
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.view.ui.UpdatePlayerThreeHealth();
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.view.ui.UpdatePlayerFourHealth();
                break;

            default:
                break;
        }
    }

    public void UpdatePlayerScore(PlayerNumber.PlayerNum player)
    {
        switch (player)
        {
            case PlayerNumber.PlayerNum.PlayerOne:
                app.view.ui.UpdatePlayerOneScore();
                break;

            case PlayerNumber.PlayerNum.PlayerTwo:
                app.view.ui.UpdatePlayerTwoScore();
                break;

            case PlayerNumber.PlayerNum.PlayerThree:
                app.view.ui.UpdatePlayerThreeScore();
                break;

            case PlayerNumber.PlayerNum.PlayerFour:
                app.view.ui.UpdatePlayerFourScore();
                break;

            default:
                break;
        }
    }
}
