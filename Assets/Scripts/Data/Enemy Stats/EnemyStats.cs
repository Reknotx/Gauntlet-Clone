using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Create Enemy Stats", order = 52)]
public class EnemyStats : ScriptableObject
{
    [SerializeField]
    private int _damageToPlayer;

    [SerializeField]
    private int _health;

    [SerializeField]
    private int _moveSpeed;

    public int DamageToPlayer { get { return _damageToPlayer; } }
    public int StartingHP { get { return _health; } }
    public int MoveSpeed { get { return _moveSpeed; } }
}
