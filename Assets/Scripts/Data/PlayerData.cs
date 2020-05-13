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

    protected bool _isAttacking = false;

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

    protected Sprite _northAttackSprite;

    protected Sprite _northEastAttackSprite;

    protected Sprite _eastAttackSprite;

    protected Sprite _southEastAttackSprite;

    protected Sprite _southAttackSprite;

    protected Sprite _southWestAttackSprite;

    protected Sprite _westAttackSprite;

    protected Sprite _northWestAttackSprite;

    //Member variables below to access data

    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }

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

    //Movement sprites below

    public Sprite NorthSprite { get { return _northSprite; } }

    public Sprite NorthEastSprite { get { return _northEastSprite; } }

    public Sprite EastSprite { get { return _eastSprite; } }

    public Sprite SouthEastSprite { get { return _southEastSprite; } }

    public Sprite SouthSprite { get { return _southSprite; } }

    public Sprite SouthWestSprite { get { return _southWestSprite; } }

    public Sprite WestSprite { get { return _westSprite; } }

    public Sprite NorthWestSprite { get { return _northWestSprite; } }

    //Attack sprites below

    public GameObject Projectile { get { return _projectile; } }

    public Sprite NorthAttackSprite { get { return _northAttackSprite; } }

    public Sprite NorthEastAttackSprite { get { return _northEastAttackSprite; } }

    public Sprite EastAttackSprite { get { return _eastAttackSprite; } }

    public Sprite SouthEastAttackSprite { get { return _southEastAttackSprite; } }

    public Sprite SouthAttackSprite { get { return _southAttackSprite; } }

    public Sprite SouthWestAttackSprite { get { return _southWestAttackSprite; } }

    public Sprite WestAttackSprite { get { return _westAttackSprite; } }

    public Sprite NorthWestAttackSprite { get { return _northWestAttackSprite; } }

    protected void AssignClassInfo()
    {
        _health = playerClassData.StartingHealth;
        _healthGain = playerClassData.HealthGain;
        _score = 0;
        _tokensUsed = 1;
        _armor = playerClassData.Armor;
        _shotStrength = playerClassData.Shot;
        _magicStrength = playerClassData.Magic;
        _meleeStrength = playerClassData.Melee;
        _moveSpeed = playerClassData.Speed;

        _northSprite = playerClassData.NorthSprite;
        _northEastSprite = playerClassData.NorthEastSprite;
        _eastSprite = playerClassData.EastSprite;
        _southEastSprite = playerClassData.SouthEastSprite;
        _southSprite = playerClassData.SouthSprite;
        _southWestSprite = playerClassData.SouthWestSprite;
        _westSprite = playerClassData.WestSprite;
        _northWestSprite = playerClassData.NorthWestSprite;

        currDirection = Direction.South;

        _projectile = playerClassData.Projectile;

        _northAttackSprite = playerClassData.NorthAttackSprite;
        _northEastAttackSprite = playerClassData.NorthEastAttackSprite;
        _eastAttackSprite = playerClassData.EastAttackSprite;
        _southEastAttackSprite = playerClassData.SouthEastAttackSprite;
        _southAttackSprite = playerClassData.SouthAttackSprite;
        _southWestAttackSprite = playerClassData.SouthWestAttackSprite;
        _westAttackSprite = playerClassData.WestAttackSprite;
        _northWestAttackSprite = playerClassData.NorthWestAttackSprite;
    }
}
