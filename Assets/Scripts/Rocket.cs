using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 velocity; 
    
	void Start () {
        Destroy(this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();
        velocity = rb.velocity;
	}
	
	void Update () {
	
        if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity; 
        }
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(velocity.x, -velocity.y);
        if (collision.collider.tag == "deadly")
        {
            Destroy(collision.gameObject);
            Explode();
        }
        if (collision.contacts[0].normal.x != 0)
        {
            Explode();
        }
    }
    void Explode()
    {
        Destroy(gameObject);
    }
}
