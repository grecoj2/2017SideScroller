using UnityEngine;
using System.Collections;

public class Bomb : Throwable 
{

    public float blastRadius = 5;
   
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("coll");
        var player = coll.gameObject.GetComponent<Player>();
        if (isActive && player == null)
        {
            Explode();
        }
    }

    
   

    public void Explode()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var e in enemies)
        {
            if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius)
            {
                e.gameObject.SetActive(false);
            }
        }

        // set myself (aka the bomb) to NOT-Active. That way the bomb disappears, and cannot be picked up again. 
        gameObject.SetActive(false);

    }

 }


