using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCollider : MonoBehaviour
{
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            playerMovement.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("ground"))
        {
            StartCoroutine(coyoteTimer());
        }
    }
    IEnumerator coyoteTimer()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        playerMovement.isGrounded = false;
    }

}
