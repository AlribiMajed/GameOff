using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCollider : MonoBehaviour
{
    PlayerMovement playerMovement;
    gravity gravity;
    Animator animator;
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        gravity = GetComponentInParent<gravity>();
        animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ground") || other.CompareTag("platform"))
        {
            playerMovement.isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground") || other.CompareTag("platform"))
        {
            playerMovement.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("ground") || other.CompareTag("platform"))
        {
            StartCoroutine(coyoteTimer());
        }
        if(other.CompareTag("platform") && Input.GetAxisRaw("Vertical")<0)
        {
            if (gravity.isMoon)
                animator.Play("fallMoon");
            else if (gravity.isEarth)
                animator.Play("fallEarth");
            else if (gravity.isSun)
                animator.Play("fallSun");
        }
    }
    IEnumerator coyoteTimer()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        playerMovement.isGrounded = false;
    }

}
