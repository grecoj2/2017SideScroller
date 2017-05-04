using UnityEngine;
using System.Collections;

public class StunGrenade : Throwable 
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
               StartCoroutine( Stun(e) );
            }
        }

        // set myself (aka the bomb) to NOT-Active. That way the bomb disappears, and cannot be picked up again. 
        collider2D.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

    }

    IEnumerator Stun(Enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>(); 
        var animator = GetComponent<SpriteRenderer>();

        e.enabled = false;
        if(animator != null)
        {
            animator.enabled = false;

        }
        for (int i = 0; i < 8; i++)
        {
            renderer.color = new Color(1, 1, 1, 1 - (i * .1f));
            yield return new WaitForSeconds(.5f);
        }
       
        yield return new WaitForSeconds(5);

        for (int i = 0; i < 8; i++)
        {
            renderer.color = new Color(1, 1, 1, 1 - (i * .1f));
            yield return new WaitForSeconds(.1f);
        }

        if (animator != null)
        {
            animator.enabled = true;

        }
      
        e.enabled = true;
    }

 }


