using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{


    public float speed;

    private Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
	    rigidbody2D.rotation = 90;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
