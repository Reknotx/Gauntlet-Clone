using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : Element
{
    protected int _damageToPlayer;

    protected int _health;

    protected int _moveSpeed;

    public int DamageToPlayer { get { return _damageToPlayer; } }

    public int Health { get { return _health; } set { _health = value; } }

    public int MoveSpeed { get { return _moveSpeed; } }
}
