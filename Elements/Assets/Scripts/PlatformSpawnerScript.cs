using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{


    public GameObject respawnObjectY;

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

        if (!GlobalVar.platformyIsActive)
        {

            
            if (GlobalVar.platformYrespawnTimer + 3 < Time.fixedTime)
            {
                Debug.Log("xdxdxdxdxd");
                Instantiate(respawnObjectY, respawnObjectY.transform.position, respawnObjectY.transform.rotation);
     
                GlobalVar.platformyIsActive = true;
            }
        }
    }
}
