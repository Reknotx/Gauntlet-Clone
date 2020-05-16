#pragma warning disable CS0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponView : Element
{
    [SerializeField]
    private PlayerNumber.PlayerNum _belongsTo;

    public PlayerNumber.PlayerNum BelongsTo { get { return _belongsTo; } }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        app.controller.collisions.FilterCollision(this.gameObject, collision.gameObject);
    }
}
