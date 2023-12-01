using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform respawnPoint;
    PlayerMovement pm;
    void Start()
    {
         pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("death"))
        {
            transform.position = respawnPoint.position;
            pm.moonFound = false;
            pm.sunFound = false;
            GameObject.Find("moon").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("sun").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
