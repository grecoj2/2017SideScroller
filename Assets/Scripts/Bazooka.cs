using UnityEngine;
using System.Collections;

public class Bazooka : Weapon {

    public GameObject rocketPrefab;

    public override void Attack()
    {
        var rocket = Instantiate(rocketPrefab);
        rocket.transform.position = this.transform.position;
        rocket.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        base.Attack();
    }
}
