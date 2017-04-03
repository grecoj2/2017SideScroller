using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -3;

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;


    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //apply movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (Input.GetButtonDown("Jump"))
        {
            v.y = jumpSpeed; 
        }

        rigidbody.velocity = v;

        //check for out
        if(transform.position.y < deadZone)
        {
          
        }
     
        
        // rigidbody.AddForce(new Vector2(x * speed, 0)); this is an alternate way to make him move without falling
	
	}

    public void GetOut()
    {
        _GM.SetLives(_GM.GetLives() - 1 );
        transform.position = startingPosition;
        Debug.Log("You're Out");
    }
}
