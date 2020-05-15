#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerClassStats", menuName = "Create Player Class Stats", order = 51)]
public class PlayerClassStats : ScriptableObject
{
    [SerializeField]
    private int _startingHealth;

    [SerializeField]
    private int _healthGain;

    [SerializeField]
    private int _armor;

    [SerializeField]
    private int _shotStrength;

    [SerializeField]
    private int _magicStrength;

    [SerializeField]
    private int _meleeStrength;

    [SerializeField]
    private int _moveSpeed;

    [SerializeField]
    private Sprite _northSprite;

    [SerializeField]
    private Sprite _northEastSprite;

    [SerializeField]
    private Sprite _eastSprite;

    [SerializeField]
    private Sprite _southEastSprite;

    [SerializeField]
    private Sprite _southSprite;

    [SerializeField]
    private Sprite _southWestSprite;

    [SerializeField]
    private Sprite _westSprite;

    [SerializeField]
    private Sprite _northWestSprite;

    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Sprite _northAttackSprite;

    [SerializeField]
    private Sprite _northEastAttackSprite;

    [SerializeField]
    private Sprite _eastAttackSprite;

    [SerializeField]
    private Sprite _southEastAttackSprite;

    [SerializeField]
    private Sprite _southAttackSprite;

    [SerializeField]
    private Sprite _southWestAttackSprite;

    [SerializeField]
    private Sprite _westAttackSprite;

    [SerializeField]
    private Sprite _northWestAttackSprite;

    public int StartingHealth { get { return _startingHealth; } }
    public int HealthGain { get { return _healthGain; } }
    public int Armor { get { return _armor; } }
    public int Shot { get { return _shotStrength; } }
    public int Magic { get { return _magicStrength; } }
    public int Melee { get { return _meleeStrength; } }
    public int Speed { get { return _moveSpeed; } }

    public Sprite NorthSprite { get { return _northSprite; } }
    public Sprite NorthEastSprite { get { return _northEastSprite; } }
    public Sprite EastSprite { get { return _eastSprite; } }
    public Sprite SouthEastSprite { get { return _southEastSprite; } }
    public Sprite SouthSprite { get { return _southSprite; } }
    public Sprite SouthWestSprite { get { return _southWestSprite; } }
    public Sprite WestSprite { get { return _westSprite; } }
    public Sprite NorthWestSprite { get { return _northWestSprite; } }

    public GameObject Projectile { get { return _projectilePrefab; } }

    public Sprite NorthAttackSprite { get { return _northAttackSprite; } }
    public Sprite NorthEastAttackSprite { get { return _northEastAttackSprite; } }
    public Sprite EastAttackSprite { get { return _eastAttackSprite; } }
    public Sprite SouthEastAttackSprite { get { return _southEastAttackSprite; } }
    public Sprite SouthAttackSprite { get { return _southAttackSprite; } }
    public Sprite SouthWestAttackSprite { get { return _southWestAttackSprite; } }
    public Sprite WestAttackSprite { get { return _westAttackSprite; } }
    public Sprite NorthWestAttackSprite { get { return _northWestAttackSprite; } }
}
