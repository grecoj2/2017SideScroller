using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    void OnCOllisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {

        }

    }
}
