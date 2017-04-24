using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{


    public float speed;
    
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
	   

        /*Debug.Log("Freeze time: " + freezeTime + freezeDelay + " - " + Time.fixedTime);
        if (freezeTime + freezeDelay < Time.fixedTime)
        {
            Debug.Log("jdksl");
            GlobalVar.isFrozen = false;
            //GlobalVar.platformSpeed = 1;
        }*/
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
            /*if (freezeTime == 0)
            {
                Debug.Log("workz?");*/
                GlobalVar.freezetime = Time.fixedTime;
            
                GlobalVar.isFrozen = true;
               // GlobalVar.platformSpeed = 0;
            //}

            

            GlobalVar.platformFreeze = true;
            
        }
        if (other.tag == "PlatformY" && GlobalVar.charSelected == 3)
        {
            /*if (freezeTime == 0)
            {
                Debug.Log("workz?");*/
            GlobalVar.freezetime = Time.fixedTime;

            GlobalVar.YisFrozen = true;
            // GlobalVar.platformSpeed = 0;
            //}



            GlobalVar.YplatformFreeze = true;

        }

        Destroy(gameObject);
    }
}
