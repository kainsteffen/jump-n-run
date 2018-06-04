using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public SpriteRenderer sprite;
    public Rigidbody2D rigidBody;
    public Transform groundCheck;
    public Animator animator;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {


        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(Vector2.right * speed);

            sprite.flipX = false;

            animator.SetInteger("State", 1);
        }
        else if (Input.GetKey("a"))
        {
            rigidBody.AddForce(Vector2.left * speed);

            sprite.flipX = true;
            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }

        if (Input.GetKey("s"))
        {
            animator.SetInteger("State", 3);
        }




        RaycastHit2D grounded = Physics2D.Linecast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));

        animator.SetBool("Grounded", grounded);

        Debug.DrawLine(transform.position, groundCheck.position, Color.red);

        if (grounded)
        {
            if (Input.GetKeyDown("space"))
            {
                rigidBody.AddForce(Vector2.up * jumpForce);
                animator.SetInteger("State", 2);
            }
        }


    }
}
