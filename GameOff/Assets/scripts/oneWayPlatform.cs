using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayPlatform : MonoBehaviour
{
    Collider2D platformCollider;
    Collider2D playerCollider;
    float down;
    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        playerCollider = GameObject.Find("player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical")<0)
            Physics2D.IgnoreCollision(platformCollider,playerCollider,true);
        else
            Physics2D.IgnoreCollision(platformCollider, playerCollider, false);
    }
}
