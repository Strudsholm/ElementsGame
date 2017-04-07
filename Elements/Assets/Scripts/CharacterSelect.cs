using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Sprite[] s1, s2, s3, s4;
    private SpriteRenderer spriteRenderer;
    public int selectedCharacter;
    private Animator animator;

    public LayerMask groundlayer;
    private bool grounded, canDoubleJump;
    public GameObject groundchecker;

    private Rigidbody2D rigidbody2;

    public Transform firepoint;
    public GameObject projectile;

    // Use this for initialization
    private void Start()
    {

        s1 = Resources.LoadAll<Sprite>("hud_1");
        s2 = Resources.LoadAll<Sprite>("hud_2");
        s3 = Resources.LoadAll<Sprite>("hud_3");
        s4 = Resources.LoadAll<Sprite>("hud_4");

        animator = GetComponent<Animator>();

        rigidbody2 = gameObject.GetComponent<Rigidbody2D>();

        selectedCharacter = 1;

        groundchecker = GameObject.Find("Playerground");

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // we are accessing the SpriteRenderer that is attached to the Gameobject
        /*if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = (Sprite) s2[0]; // set the sprite to sprite1*/
    }

    // Update is called once per frame
    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundchecker.transform.position, 0.2f, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (selectedCharacter < 4)
            {
                selectedCharacter++;
                //animator.SetInteger("player", selectedCharacter);
            }

            else
            {
                selectedCharacter = 1;
                //animator.SetInteger("player", selectedCharacter);
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
            Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s1[0];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s1[6];
            }
        }
        else if (selectedCharacter == 2)
        {
            Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s2[0];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s2[6];
            }


        }
        else if (selectedCharacter == 3)
        {
            Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s3[0];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite) s3[6];
            }

        }
        else if (selectedCharacter == 4)
        {
            Debug.Log("Change sprite");
            spriteRenderer.sprite = (Sprite)s4[0];
            if (!grounded)
            {
                //spriteRenderer.sprite = (Sprite)s4[6];
            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {

            Instantiate(projectile, firepoint.position, firepoint.rotation);
        }

    }
}

