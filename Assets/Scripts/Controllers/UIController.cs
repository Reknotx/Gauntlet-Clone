using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Controller class which updates the player's health and 
 * score on the screen.</summary>
 * 
 */
public class UIController : Element
{
    /**
     * <summary>Sends a message to the UI to update the player's health.</summary>
     * 
     * <param name="player">The player whose health needs to be updated.</param>
     */
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


    /**
     * <summary>Sends a message to the UI to update the player's score.</summary>
     * 
     * <param name="player">The player whose score needs to be updated.</param>
     * 
     */
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
