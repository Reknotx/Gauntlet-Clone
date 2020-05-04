using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerData : Element, IPlayerData
{
    public enum Direction
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    protected Direction currDirection;

    //All the necessary data
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

    protected GameObject _projectile;

    //Member variables below to access data


    public int Health { get { return _health; } set { _health = value; } }
    public int Score { get { return _score; } set { _score = value; } }
    public int TokensUsed { get { return _tokensUsed; } set { _tokensUsed++; } }

    public int HealthGain { get { return _healthGain; } }

    public int Armor { get { return _armor; } }

    public int Shot { get { return _shotStrength; } }

    public int Magic { get { return _magicStrength; } }

    public int Melee { get { return _meleeStrength; } }

    public int MoveSpeed { get { return _moveSpeed; } }

    public Direction CurrentDirection { get { return currDirection; } set { currDirection = value; } }

    public PlayerNumber.PlayerNum PlayerNum { get { return _playerNum; } }

    public Sprite NorthSprite { get { return _northSprite; } }

    public Sprite NorthEastSprite { get { return _northEastSprite; } }

    public Sprite EastSprite { get { return _eastSprite; } }

    public Sprite SouthEastSprite { get { return _southEastSprite; } }

    public Sprite SouthSprite { get { return _southSprite; } }

    public Sprite SouthWestSprite { get { return _southWestSprite; } }

    public Sprite WestSprite { get { return _westSprite; } }

    public Sprite NorthWestSprite { get { return _northWestSprite; } }

    public GameObject Projectile { get { return _projectile; } }
}
