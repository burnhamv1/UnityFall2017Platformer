using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    const float DEADZONE_HEIGHT = -5;
    public float maxSpeed = 5;
    public float jumpForce = 50;
    public Weapon currentWeapon;

    private bool isDucking = false;

    private Vector3 startPosition;
    private new Rigidbody2D rigidbody2D;
    

    // Use this for initialization
    void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position; 
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DEADZONE_HEIGHT)
        {
            Die();
        }

        var x_force = Input.GetAxis("Horizontal");
        rigidbody2D.velocity += Vector2.right * x_force;
        rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);

        if (Input.GetButtonDown("Jump") && rigidbody2D.velocity.y == 0)
        {
            rigidbody2D.velocity += Vector2.up * jumpForce;
        }
        if(Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Attack(); 
        }
        // Duck if needed
        if(Input.GetAxisRaw("Vertical") < 0 && !isDucking)
        {
            transform.localScale *= .7f;
            isDucking = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0 && isDucking)
        {
            transform.localScale /= .7f;
            isDucking = false;
        }

        // Flip to look in right direction
        if (rigidbody2D.velocity.x > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0); 
        } else if (rigidbody2D.velocity.x <0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }


    public void Die()
    {
        transform.position = startPosition;
        rigidbody2D.velocity = new Vector2();
        FindObjectOfType<GM>().LifeWasLost();
    }
}
