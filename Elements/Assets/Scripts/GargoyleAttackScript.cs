using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GargoyleAttackScript : MonoBehaviour
{


    public Vector2 speed;
    private Rigidbody2D rigidbody2D;

    public GameObject player;

    public Transform firepoint;

    private float xspeed;
    private float yspeed;
    
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //rigidbody2D.velocity = speed;

        
    }
	
	// Update is called once per frame
	void Update ()
	{



	    rigidbody2D.velocity = speed;
         

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spiller")
        {
            SceneManager.LoadScene("Game_over");
        }
        Destroy(gameObject);
    }
}
