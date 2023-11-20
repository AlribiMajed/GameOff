using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float earthMovementSpeed = 1f;
    [SerializeField]float moonMovementSpeed = 1f;
    [SerializeField]float jupiterMovementSpeed = 1f;
    float movementSpeed = 1f;
   public float movementX;
    float movementY;
    bool isFacingRight = true;

    public bool isGrounded = false;
    [SerializeField] private float jumpForce = 10f;
    private bool jumping = false;

    bool doubleJump = false;

    gravity gravity;

    Animator animator;

    Rigidbody2D rb;

    wallJump wallJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<gravity>();
        animator = GetComponent<Animator>();;
       wallJump = GetComponent<wallJump>();
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
            jumping = true;
        fall();
    }
    void FixedUpdate()
    {
        
        movement();
        jump();
    }
    public void movement()
    {
        if (gravity.isMoon)
            movementSpeed = moonMovementSpeed;
        else if(gravity.isSun)
            movementSpeed = jupiterMovementSpeed;
        else if(gravity.isEarth) 
            movementSpeed = earthMovementSpeed;

        rb.AddForce(new Vector2(movementX * movementSpeed, 0f), ForceMode2D.Impulse);    

        //walk animatoin
        if(isGrounded)
        {
            if (gravity.isMoon)
                animator.Play("walkMoon");
            else if (gravity.isEarth)
                animator.Play("walkEarth");
            else if (gravity.isSun)
                animator.Play("walkSun");
        }
        if (movementX < 0 && isFacingRight)
            flip();
        else if(movementX > 0 && !isFacingRight) 
            flip();
    }
    public void jump()
    {
        if (jumping &&!isGrounded && !doubleJump)
            jumping = false;

        if (jumping && isGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x,jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
            jumping = false;
            doubleJump = true;

            // jump animation
            if (gravity.isMoon)
                animator.Play("moonJump");
            else if (gravity.isEarth)
                animator.Play("earthJump");
            else if (gravity.isSun)
                animator.Play("sunJump");
        }
    
        else if(jumping && doubleJump)
        {
            if(!gravity.isEarth)
            {
                doubleJump = false;
                jumping = false;
                return;
            }    
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            doubleJump = false;
            jumping = false;

            // double jump animation
            if (gravity.isMoon)
                animator.Play("moonJump");
            else if (gravity.isEarth)
                animator.Play("earthJump");
            else if (gravity.isSun)
                animator.Play("sunJump");
        }
    }
 
    void fall()
    {
        // fall animation
        if (rb.velocity.y < 0 && !isGrounded)
        {
            if (gravity.isMoon)
                animator.Play("fallMoon");
            else if (gravity.isEarth)
                animator.Play("fallEarth");
            else if (gravity.isSun)
                animator.Play("fallSun");
        }    
    }
    public void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

 
}
