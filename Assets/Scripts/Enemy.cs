using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("collided");
        if (!enabled)
        {
            return;
        }
        Debug.Log("you are out");
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.GetOut();
        }

    }
}
