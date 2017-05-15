using UnityEngine;
using System.Collections;

public class Hammer : Weapon
{

    public float killRadius = 1;
    public bool isActive = false;



    public override void Attack()
    {

        //collider2D.enabled = true;
        Kill();
        GetComponent<Animator>().SetTrigger("attack");

      
    }   

    public void Kill()
    {
        var enemies = FindObjectsOfType<Enemy>();     
        foreach (var e in enemies)
        {
            if (Vector3.Distance(this.transform.position, e.transform.position) < killRadius)
            {
                e.gameObject.SetActive(false);
            }
        }
    }
}