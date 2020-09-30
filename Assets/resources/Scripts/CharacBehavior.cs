using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    public float runSpeed;

    public float maxJump;

    private bool facingRight = true;

    private bool isGrounded = false;


    void FixedUpdate()
    {
        //Player Movement. Check for horizontal movement
        if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) 
        {
            if (Input.GetAxisRaw ("Horizontal") > 0.5f && !facingRight) 
            {
                //If we're moving right but not facing right, flip the sprite and set facingRight to true.
                Flip ();
                facingRight = true;
            } else if (Input.GetAxisRaw("Horizontal") < 0.5f && facingRight) 
            {
                //If we're moving left but not facing left, flip the sprite and set facingRight to false.
                Flip ();
                facingRight = false;
            }
            retrieveInput();
        }

        //Player Movement. Check for jumping
        if(Input.GetKeyDown("space") && isGrounded) {
            Jump();
            isGrounded = false;
        }
    }

    void retrieveInput() {
        float xInput = Input.GetAxis("Horizontal");
        float xForce = xInput * runSpeed * Time.deltaTime;
        Vector2 force = new Vector2(xForce, 0f);
        rb.velocity += force;
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing        
        facingRight = !facingRight;
        // Flip the player's x local scale by multpliying it by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jump() 
    { 
        Vector2 jumpForce = new Vector2(0f, maxJump);
        rb.velocity += jumpForce;
    }

    // Unity native functions that are automatically triggered when the character will collide an object or not
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
      if(col.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }

}
