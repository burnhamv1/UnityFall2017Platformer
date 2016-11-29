using UnityEngine;
using System.Collections;

public class RunningMovement : MonoBehaviour
{

    new Rigidbody2D rigidbody2D;
    public float speed = 2f;
    public float distance = 10;
    private float startingX;

	// Use this for initialization
	void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        startingX = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (transform.position.x < startingX - distance)
        { 
            speed = -speed;
        }

        if (transform.position.x > startingX)
        {
            speed = -speed;
        }

        var v = rigidbody2D.velocity;
        v.x = -speed;
        rigidbody2D.velocity = v; 

    }
}
