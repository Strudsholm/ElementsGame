﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class GlobalVar
{
    public static bool facingright { get; set; }
    public static int charSelected { get; set; }
    public static float platformSpeed { get; set; }
    public static bool platformFreeze { get; set; }
    public static bool YplatformFreeze { get; set; }
    public static bool isFrozen { get; set; }
    public static bool YisFrozen { get; set; }
    public static float freezetime { get; set; }
    public static bool platformxIsActive { get; set; }
    public static bool platformyIsActive { get; set; }
    public static  float platformXrespawnTimer { get; set; }
    public static  float platformYrespawnTimer { get; set; }
    public static int charShooting { get; set; }

}


public class CharacterSelect : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float punchForce;

    private Sprite[] s1, s2, s3, s4;
    private SpriteRenderer spriteRenderer;
    public int selectedCharacter;
    private Animator animator;

    public LayerMask groundlayer;
    private bool grounded, canDoubleJump;
    public GameObject groundchecker;

    private Rigidbody2D rigidbody2;

    public Transform firepoint;
    public GameObject iceProjectile;
    public GameObject fireProjectile;

    public Text helpText;
    public Text scoreText;
    public Text keyText;

    private int score = 0;
    private int keys = 0;

    private bool gameover, hasKey;

    private Vector3 left, right;
    // Use this for initialization
    private void Start()
    {

        right = new Vector3(1f, 1f, 1f);
        left = new Vector3(-1f, 1f, 1f);

        s1 = Resources.LoadAll<Sprite>("characters");
        s2 = Resources.LoadAll<Sprite>("characters");
        s3 = Resources.LoadAll<Sprite>("characters");
        s4 = Resources.LoadAll<Sprite>("characters");

        animator = GetComponent<Animator>();

        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();

        selectedCharacter = 1;

        groundchecker = GameObject.Find("Playerground");

        gameover = false;
       // Debug.Log("haskeyfalse");
        hasKey = false;

        

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // we are accessing the SpriteRenderer that is attached to the Gameobject
        /*if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = (Sprite) s2[0]; // set the sprite to sprite1*/

    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = "Score: " + score + "/7";
        keyText.text = "Keys: " + keys + "/1";
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GlobalVar.facingright = false;
            transform.localScale = left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GlobalVar.facingright = true;
            transform.localScale = right;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("text");
            helpText.enabled = !helpText.enabled;
            
        }

        grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.2f, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (selectedCharacter < 4)
            {
                selectedCharacter++;

                GlobalVar.charSelected = selectedCharacter;
                //animator.SetInteger("player", selectedCharacter);
            }

            else
            {
                selectedCharacter = 1;
                //animator.SetInteger("player", selectedCharacter);
                GlobalVar.charSelected = selectedCharacter;
            }



        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && selectedCharacter == 2)
        {
            if (grounded)
            {
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 0);
                rigidbody2.AddForce(new Vector3(0, 100 * jumpForce, 0));

                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 0);
                    rigidbody2.AddForce(new Vector3(0, 100 * jumpForce, 0));
                }
            }
            //rigidbody.AddForce(transform.up * jumpforce * 100);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && selectedCharacter != 2)
        {

            //rigidbody.AddForce(transform.up * jumpforce * 100);
            rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 0);
            rigidbody2.AddForce(new Vector3(0, 100 * jumpForce, 0));
        }






        if (selectedCharacter == 1)
        {
            //Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s1[62];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s1[6];
            }
        }
        else if (selectedCharacter == 2)
        {
            //Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s2[60];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s2[6];
            }


        }
        else if (selectedCharacter == 3)
        {
            //Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s3[26];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s3[6];
            }

        }
        else if (selectedCharacter == 4)
        {
            //Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s4[24];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite)s4[6];
            }

        }
       
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectedCharacter == 1 && rigidbody2.velocity.x == 0)
            {
                Debug.Log("punchman");
                rigidbody2.AddForce(new Vector2(punchForce * 100, 0.1f));
            }
            if (selectedCharacter == 3)
            {
                GlobalVar.charShooting = 3;
                Instantiate(iceProjectile, firepoint.position, firepoint.rotation);
            }
            if (selectedCharacter == 4)
            {
                GlobalVar.charShooting = 4;
                Instantiate(fireProjectile, firepoint.position, firepoint.rotation);
            }
        }

        if (transform.position.y < -1)
        {
            SceneManager.LoadScene("Game_over");
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            Destroy(other.gameObject);
            hasKey = true;
            keys ++;
        }

        if (other.tag == "Rock" && rigidbody2.velocity.x > 3)
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Door" && hasKey)
        {
            SceneManager.LoadScene("Game_over");
        }
        if (other.tag == "Lava" && selectedCharacter != 4)
        {
            SceneManager.LoadScene("Game_over");
        }
        if (other.tag == "Spikes")
        {
            SceneManager.LoadScene("Game_over");
        }
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game_over");
        }
        if (other.tag == "Star")
        {
            Destroy(other.gameObject);
            score ++;
        }
    }
}

