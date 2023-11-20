using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJump : MonoBehaviour
{

    bool isTouchingFront;
    public Transform frontCheck;
    public bool isWallSliding;
    public float wallSlideSpeed;

    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    PlayerMovement pm;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isTouchingFront && !pm.isGrounded && pm.movementX != 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        if(isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("wall"))
        {
            isTouchingFront = true;

        }
;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("wall"))
        {
        isTouchingFront=false;

        }

    }
}
