#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : Element
{
    [SerializeField]
    private Text _playerOneScore;

    [SerializeField]
    private Text _playerOneHealth;

    [SerializeField]
    private Text _playerTwoScore;

    [SerializeField]
    private Text _playerTwoHealth;

    [SerializeField]
    private Text _playerThreeScore;

    [SerializeField]
    private Text _playerThreeHealth;

    [SerializeField]
    private Text _playerFourScore;

    [SerializeField]
    private Text _playerFourHealth;

    public void UpdatePlayerOneScore()
    {
        _playerOneScore.text = app.data.playerData.playerOne.Score.ToString();
    }

    public void UpdatePlayerOneHealth()
    {
        _playerOneHealth.text = app.data.playerData.playerOne.Health.ToString();
    }

    public void UpdatePlayerTwoScore()
    {
        _playerTwoScore.text = app.data.playerData.playerTwo.Score.ToString();
    }

    public void UpdatePlayerTwoHealth()
    {
        _playerTwoHealth.text = app.data.playerData.playerTwo.Health.ToString();
    }

    public void UpdatePlayerThreeScore()
    {
        _playerThreeScore.text = app.data.playerData.playerThree.Score.ToString();
    }

    public void UpdatePlayerThreeHealth()
    {
        _playerThreeHealth.text = app.data.playerData.playerThree.Health.ToString();
    }

    public void UpdatePlayerFourScore()
    {
        _playerFourScore.text = app.data.playerData.playerFour.Score.ToString();
    }

    public void UpdatePlayerFourHealth()
    {
        _playerFourHealth.text = app.data.playerData.playerFour.Health.ToString();
    }
}
