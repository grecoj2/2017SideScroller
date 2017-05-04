using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    void OnCOllisionEnter2D(Collision2D coll)
    {
        if (!enabled)
        {
            return;
        }
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.GetOut();
        }

    }
}
