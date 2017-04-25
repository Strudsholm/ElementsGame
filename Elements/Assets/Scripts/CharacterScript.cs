using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public int selectedCharacter;
    GameObject player, character;
    public float speed, jumpforce;
    private Rigidbody2D rigidbody2D;
    private bool gameover;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("hud_1");
        rigidbody2D = GetComponent<Rigidbody2D>();
        selectedCharacter = 1;
        

    }
	
    // 1. jord, 2. luft, 3. ild, 4. Vand.

	// Update is called once per frame
	void Update () {

        /*if (Input.GetKey(KeyCode.LeftArrow))
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
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedCharacter < 4)
                selectedCharacter++;
            else
                selectedCharacter = 1;
        }
        if (selectedCharacter == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed * 0.7f * Time.deltaTime, 0, 0);
                //GlobalVariables.placement = gameObject.transform.position;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed * 0.7f * Time.deltaTime, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }
        }
        else if (selectedCharacter == 2)
        {

            //grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.2f, groundlayer);

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed*2 * Time.deltaTime, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed*2* Time.deltaTime, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //gameObject.transform.position += new Vector3(0, jumpforce, 0);
                //rigidbody2D.AddForce(transform.up * jumpforce * 100);
            }

        }
        else if (selectedCharacter == 3)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
               // Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
               // GlobalVariables.placement = gameObject.transform.position;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
               // Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
              //  GlobalVariables.placement = gameObject.transform.position;
            }
        }
        else if (selectedCharacter == 4)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
               // Debug.Log("Moving Left");
                gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                // GlobalVariables.placement = gameObject.transform.position;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("Moving Right");
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                //  GlobalVariables.placement = gameObject.transform.position;
            }
        }
    }
}
