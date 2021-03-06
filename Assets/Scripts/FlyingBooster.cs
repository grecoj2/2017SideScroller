﻿using UnityEngine;
using System.Collections;

public class FlyingBooster : MonoBehaviour {

    float timeStarted = 0;
    Player player;

    public float lastForSeconds = 10;

	 void OnCollisionEnte2D(Collision2D coll)
    {
        player = coll.gameObject.GetComponent<Player>();
        Debug.Log(player);
        if(player != null)
        {
            player.canFly = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            timeStarted = Time.time;
        }
    }

    void Update()
    {
        if(timeStarted != 0 && timeStarted + lastForSeconds < Time.time)
        {
            timeStarted = 0;
            player.canFly = false;

        }
    }
}
