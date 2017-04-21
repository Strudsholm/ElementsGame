using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{

    public float platformSpeedLocal { get; set; }
    public Rigidbody2D rigidbody2D { get; set; }

    

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        platformSpeedLocal = -1;
        GlobalVar.platformSpeed = - 1;
        GlobalVar.platformFreeze = false;

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(GlobalVar.platformSpeed, 0);
        if (transform.position.x < -3f)
        {
            GlobalVar.platformSpeed = 1;
            //GlobalVar.platformSpeed = platformSpeedLocal;
            //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
        }
        if (transform.position.x > 2.2f)
        {
            GlobalVar.platformSpeed = -1;
            //GlobalVar.platformSpeed = platformSpeedLocal;
            //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
        }
        if (transform.position.y < 1.5f)
        {
            Destroy(gameObject);
        }
       


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spiller")
        {
            if (GlobalVar.platformFreeze == false)
            {
                Destroy(gameObject);
            }


        }



    }
}
