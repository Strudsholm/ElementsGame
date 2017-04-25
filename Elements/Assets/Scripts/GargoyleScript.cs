using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleScript : MonoBehaviour
{

    public GameObject attack;
    public Transform firepoint;
    private float attackTime;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        //Instantiate(attack, firepoint.position, firepoint.rotation);
        attackTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        //Shoot after player not done yet, yspeed and xspeed is wrong.

        /*var xdistance = player.transform.position.x - firepoint.position.x;
        var ydistance = player.transform.position.y - firepoint.position.y;

        var xspeed = xdistance / xdistance;
        var yspeed = ydistance / xdistance;

        Debug.Log("xspeed: " + xdistance);
        Debug.Log("yspeed: " + ydistance);*/
        if (attackTime + 3 < Time.fixedTime)
        {
            Instantiate(attack, firepoint.position, firepoint.rotation);
            attackTime = Time.fixedTime;
        }


    }
}
