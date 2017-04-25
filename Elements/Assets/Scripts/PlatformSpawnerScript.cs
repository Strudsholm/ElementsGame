using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{


    public GameObject platform;

    public GameObject respawnObject;

    //private float timer;
    private bool timerSat;
    private float timerx;
    private float timer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalVar.platformxIsActive)
        {

           
            if (GlobalVar.platformXrespawnTimer + 3 < Time.fixedTime)
            {
                Debug.Log("xdxdxdxdxd");
                Instantiate(respawnObject, respawnObject.transform.position, respawnObject.transform.rotation);
                
                GlobalVar.platformxIsActive = true;
            }
        }

        /* if (!GlobalVar.platformyIsActive)
         {

             if (timerSat)
             {
                 timer = Time.fixedTime;
                 timerSat = false;
             }
             if (timer + 3 < Time.fixedTime)
             {
                 Debug.Log("xdxdxdxdxd");
                 Instantiate(respawnObject, respawnObject.transform.position, respawnObject.transform.rotation);
                 timerSat = true;
                 GlobalVar.platformxIsActive = true;
             }
         }*/
    }
}
