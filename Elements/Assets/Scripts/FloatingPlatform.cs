using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{

    private float freezeTime;
    public float freezeDelay = 10;
    public float platformSpeedLocal { get; set; }
    public Rigidbody2D rigidbody2D { get; set; }

    public float yPlatformSpeed;
    public float xPlatformSpeed;

    public GameObject respawnObject;
    private float deathTime;
   


    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        platformSpeedLocal = -1;
        GlobalVar.platformSpeed = xPlatformSpeed;
        GlobalVar.platformFreeze = false;
        GlobalVar.isFrozen = false;
        GlobalVar.platformxIsActive = true;
        rigidbody2D.velocity = new Vector2(GlobalVar.platformSpeed, 0);
        //platformDestroyed = false;

    }

    // Update is called once per frame
    void Update()
    {
        


        if (GlobalVar.freezetime + 5 < Time.fixedTime && GlobalVar.isFrozen)
        {
           
            GlobalVar.isFrozen = false;
            GlobalVar.platformFreeze = false;
            rigidbody2D.velocity = new Vector2(xPlatformSpeed, yPlatformSpeed);
            //GlobalVar.platformSpeed = 1;
        }

        if (!GlobalVar.isFrozen)
        {
            
            if (transform.position.x < -3f)
            {
                //GlobalVar.platformSpeed = 1;

                rigidbody2D.velocity = new Vector2(xPlatformSpeed, yPlatformSpeed);
                //GlobalVar.platformSpeed = platformSpeedLocal;
                //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
            }
            if (transform.position.x > 1.8f)
            {
                //GlobalVar.platformSpeed = -1;

                rigidbody2D.velocity = new Vector2(-xPlatformSpeed, yPlatformSpeed);
                //GlobalVar.platformSpeed = platformSpeedLocal;
                //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0,0);
        }

        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spiller")
        {
            if (GlobalVar.platformFreeze == false)
            {
                GlobalVar.platformxIsActive = false;
                GlobalVar.platformXrespawnTimer = Time.fixedTime;
                Destroy(gameObject);
                
            }


        }



    }
}
