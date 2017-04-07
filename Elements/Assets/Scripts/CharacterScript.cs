using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    private int selectedCharacter;
    GameObject player, character;
    public float speed;
    private Rigidbody2D rigidbody2D;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("hud_1");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Moving Left");
            gameObject.transform.position += new Vector3(-speed * Time.deltaTime , 0, 0);
            //GlobalVariables.placement = gameObject.transform.position;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Moving Right");
            gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            // GlobalVariables.placement = gameObject.transform.position;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedCharacter < 3)
                selectedCharacter++;
            else
                selectedCharacter = 1;
        }
        if (selectedCharacter == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed * 2, 0, 0);
                //GlobalVariables.placement = gameObject.transform.position;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed * 2, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }
        }
        else if (selectedCharacter == 2)
        {

            //grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.2f, groundlayer);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Moving Left");
                character.transform.position += new Vector3(-speed, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Moving Right");
                character.transform.position += new Vector3(speed, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }

            //if (Input.GetKeyDown(KeyCode.UpArrow) & grounded)
            //{
            //   gameObject.transform.position += new Vector3(0, jumpspeedp2, 0);
            //    //rigidbody.AddForce(transform.up * jumpspeedp2 * 100);
            //}

        }
        else if (selectedCharacter == 3)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed, 0, 0);
              //  GlobalVariables.placement = gameObject.transform.position;
            }
        }*/
    }
}
