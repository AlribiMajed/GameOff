using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    float earthGravity = 9.8f;
    float moonGravity = 4f;
    float sunGravity = 20f;
    public bool isEarth;
    public bool isMoon;
    public bool isSun;
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
        if (Input.GetButtonDown("moon") && pm.moonFound)
            moon();
        else if (Input.GetButtonDown("earth"))
            earth();
        else if (Input.GetButtonDown("sun") && pm.sunFound)
            sun();
    }
    void moon()
    {
        rb.gravityScale = moonGravity;
        isMoon = true;
        isEarth = false;
        isSun = false;
    }
    void sun()
    {
        rb.gravityScale = sunGravity;
        isSun = true;
        isEarth = false;
        isMoon = false;
    }
    void earth()
    {
        rb.gravityScale = earthGravity;
        isEarth = true;
        isSun = false;
        isMoon = false;
    }
}
