using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject projectile; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Attack()
    {
        var r = (GameObject)Instantiate(projectile);
        r.transform.parent = transform;
        r.transform.parent = null; 
        r.transform.localPosition = new Vector3(2, 0);
        r.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 0); //sends rocket flying 

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponentInParent<Player>();
        if(player != null)
        {
            player.currentWeapon = this; //player picking up weapon 
            this.transform.parent = player.transform;
            this.transform.localPosition = new Vector3(0.5f , 0); 
        }
    }
}
