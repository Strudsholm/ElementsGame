using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{


    public float speed;
    private float freezeTime;
    public float freezeDelay = 1000;
    private Rigidbody2D rigidbody2D;
    public bool freeze = false;
	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
	    if (!GlobalVar.facingright)
	    {
	        speed = -speed;
	    }
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
            if (GlobalVar.charSelected == 4)
            {
                Destroy(other.gameObject);
            }
            
            
        }
        if (other.tag == "Platform" && GlobalVar.charSelected == 3)
        {
            if (freezeTime == 0)
            {
                freezeTime = Time.fixedTime;
                freeze = true;
                GlobalVar.platformSpeed = 0;
            }

            if (freezeTime + freezeDelay > Time.fixedTime)
            {
                freeze = false;
                GlobalVar.platformSpeed = 1;
            }

            GlobalVar.platformFreeze = true;
            
        }

        Destroy(gameObject);
    }
}
