﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    protected new Rigidbody2D rigidbody2D;
    protected new Collider2D collider2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }
    void Update()
    {

    }

public virtual void Attack()
    {

    }

    public virtual void GetPickedUp(Player player)
    {
        Debug.Log("GetPickedUp");
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        transform.parent = player.transform;
        //below is scale to change for bomb to stop getting so big
        transform.localScale = new Vector3(.2f, .2f);
        transform.localPosition = new Vector3(.2f, .2f);
        player.AddWeapon(this);
    }
}
