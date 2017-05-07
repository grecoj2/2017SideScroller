using UnityEngine;
using System.Collections;

public class Hammer : Weapon {

 
        public bool isActive = false;


        public override void Attack()
        {

            collider2D.enabled = true;
            rigidbody2D.isKinematic = false;
            rigidbody2D.velocity = new Vector2(0, 0);
            transform.parent = null;

        }

        public override void GetPickedUp(Player player)
        {
            Debug.Log("Picking up Hammer");
            if (isActive)
            {
                return;
            }
            isActive = true;
            base.GetPickedUp(player);
        }
    }
