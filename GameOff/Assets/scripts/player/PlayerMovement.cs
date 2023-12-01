using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]float earthMovementSpeed = 1f;
    [SerializeField]float moonMovementSpeed = 1f;
    [SerializeField]float jupiterMovementSpeed = 1f;
    float movementSpeed = 1f;
    float movementX;
    float movementY;
    bool isFacingRight = true;

    public bool isGrounded = false;
    private float jumpForce;
    [SerializeField] private float jumpForceEarth = 10f;
    [SerializeField] private float jumpForceMoon = 10f;
    [SerializeField] private float jumpForceSun = 10f;
    [SerializeField] private float doubleJumpForce;
    bool jumping = false;

    public bool doubleJump = false;

    gravity gravity;

    Animator animator;

    Rigidbody2D rb;

    public bool sunFound = false;
    public bool moonFound = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<gravity>();
        animator = GetComponent<Animator>();;
       
    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
            jumping = true;
        fall(); 
        jump();
    }
    void FixedUpdate()
    {
        
        movement();

    }
    public void movement()
    {
        if (gravity.isMoon)
        {
            movementSpeed = moonMovementSpeed;
            jumpForce = jumpForceMoon;
            
        }

        else if(gravity.isSun)
        {
            movementSpeed = jupiterMovementSpeed;
            jumpForce = jumpForceSun;
        }

        else if (gravity.isEarth)
        {

            movementSpeed = earthMovementSpeed;
            jumpForce = jumpForceEarth;
        }

        rb.AddForce(new Vector2(movementX * movementSpeed, 0f), ForceMode2D.Impulse);    

        //walk animatoin
        if(isGrounded && movementX!=0)
        {
            if (gravity.isMoon)
                animator.Play("walkMoon");
            else if (gravity.isEarth)
                animator.Play("walkEarth");
            else if (gravity.isSun)
                animator.Play("walkSun");
        }
        else if (isGrounded && movementX==0)
        {
            if (gravity.isMoon)
                animator.Play("idleMoon");
            else if (gravity.isEarth)
                animator.Play("idleEarth");
            else if (gravity.isSun)
                animator.Play("idleSun");
        }

        if (movementX < 0 && isFacingRight)
            flip();
        else if(movementX > 0 && !isFacingRight) 
            flip();
    }
    public void jump()
    {
        if (jumping &&!isGrounded)
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
       /* else if(jumping && doubleJump)
        {
            if(!gravity.isEarth)
            {
                doubleJump = false;
                jumping = false;
                return;
            }    
            rb.AddForce(new Vector2(rb.velocity.x, doubleJumpForce), ForceMode2D.Impulse);
            doubleJump = false;
            jumping = false;

            // double jump animation
            if (gravity.isMoon)
                animator.Play("moonJump");
            else if (gravity.isEarth)
                animator.Play("earthJump");
            else if (gravity.isSun)
                animator.Play("sunJump");
        }*/
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
    void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "moon")
        {
            moonFound = true;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;  
        }
        else if (other.name == "sun")
        {
            sunFound = true;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
            return;

    }


}
