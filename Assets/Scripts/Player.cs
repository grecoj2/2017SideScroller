using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -3;
    public bool canFly = false;

    public Weapon currentWeapon;
    private List<Weapon> weapons = new List<Weapon>();

    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    private Animator anim;
    public bool Air;
    private SpriteRenderer sr; 


    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        Air = true;
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //apply movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if(v.x != 0)
        {
            anim.SetBool("Running", true);
        }

        else
        {
            anim.SetBool("Running", false);
        }
           

        if (v.x > 0)
        {
            sr.flipX = false;
        }
               
        else if (v.x < 0)
        {
            sr.flipX = true;
        }
                

        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly) )
        {
            v.y = jumpSpeed; 
        }

        if (v.y !=0)
        {
            anim.SetBool("Air", true);
       }
        else
        {
            anim.SetBool("Air", false);
        }

        rigidbody.velocity = v;

        //attack with a weapon if you have one
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Attack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }
       
        //check for out
        if (transform.position.y < deadZone)
        {
            Debug.Log("Current Position" + transform.position.y + " is lower than " + deadZone);
            GetOut(); 
        }
     
        
        // rigidbody.AddForce(new Vector2(x * speed, 0)); this is an alternate way to make him move without falling
	
	}

    public void GetOut()
    {
        _GM.SetLives(_GM.GetLives() - 1 );
        transform.position = startingPosition;
        Debug.Log("You're Out");
    }

    public void Powerup()
    {
        anim.SetTrigger("powered");
    }

    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }

    public void SetCurrentWeapon(Weapon w)
    {
        if(currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = w;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if (weapon != null )
        {
            weapon.GetPickedUp(this);
          
        }
            if (coll.transform.tag == "MovingPlatform")
            {
                transform.parent = coll.transform;
            }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        Air = true;

        if (coll.transform.tag == "MovingPlatform")
        {
            transform.parent = coll.transform;
        }
    }
}
