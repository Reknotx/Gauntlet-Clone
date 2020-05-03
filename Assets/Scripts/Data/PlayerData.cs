using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerData : Element
{
    protected int _health;

    protected int _healthGain;

    protected int _score;

    protected int _tokensUsed;

    protected int _armor;

    protected int _shotStrength;

    protected int _magicStrength;

    protected int _meleeStrength;

    protected int _moveSpeed;

    [SerializeField]
    protected PlayerClassStats playerClassData;

    protected PlayerNumber.PlayerNum _playerNum;

    protected Sprite _northSprite;

    protected Sprite _northEastSprite;

    protected Sprite _eastSprite;

    protected Sprite _southEastSprite;

    protected Sprite _southSprite;

    protected Sprite _southWestSprite;

    protected Sprite _westSprite;

    protected Sprite _northWestSprite;

}
