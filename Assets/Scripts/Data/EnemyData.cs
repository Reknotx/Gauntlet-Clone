using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : Element
{
    protected int _damageToPlayer;

    protected int _health;

    protected int _moveSpeed;

    protected int _scoreOnDeath;

    protected EnemyType.Enemy _enemyType;

    public int DamageToPlayer { get { return _damageToPlayer; } }

    public int Health { get { return _health; } }

    public int MoveSpeed { get { return _moveSpeed; } }

    public int ScoreOnDeath { get { return _scoreOnDeath; } }

    public EnemyType.Enemy Enemy { get { return _enemyType; } }

    [SerializeField]
    protected EnemyStats stats;

    protected void InitializeStats()
    {
        _damageToPlayer = stats.DamageToPlayer;
        _health = stats.StartingHP;
        _moveSpeed = stats.MoveSpeed;
        _scoreOnDeath = stats.ScoreOnDeath;
    }
}
