using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yFloatingPlatform : MonoBehaviour {


    private float freezeTime;
    public float freezeDelay = 10;
    public float platformSpeedLocal { get; set; }
    public Rigidbody2D rigidbody2D { get; set; }

    public float yPlatformSpeed;
    public float xPlatformSpeed;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        GlobalVar.YisFrozen = false;
        GlobalVar.YplatformFreeze = false;

        rigidbody2D.velocity = new Vector2(xPlatformSpeed, yPlatformSpeed);

    }
	
	// Update is called once per frame
	void Update () {
        if (GlobalVar.freezetime + 5 < Time.fixedTime && GlobalVar.YisFrozen)
        {
            Debug.Log("kkkk" + xPlatformSpeed);
            GlobalVar.YisFrozen = false;
            GlobalVar.YplatformFreeze = false;
            rigidbody2D.velocity = new Vector2(xPlatformSpeed, yPlatformSpeed);
            //GlobalVar.platformSpeed = 1;
        }

        if (!GlobalVar.YisFrozen)
        {

            if (transform.position.y < 5.5f)
            {
                //GlobalVar.platformSpeed = 1;

                rigidbody2D.velocity = new Vector2(xPlatformSpeed, yPlatformSpeed);
                //GlobalVar.platformSpeed = platformSpeedLocal;
                //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
            }
            if (transform.position.y > 8f)
            {
                //GlobalVar.platformSpeed = -1;

                rigidbody2D.velocity = new Vector2(-xPlatformSpeed, -yPlatformSpeed);
                //GlobalVar.platformSpeed = platformSpeedLocal;
                //rigidbody2D.velocity = new Vector2(platformSpeed, 0);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
