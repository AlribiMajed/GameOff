using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopShooting : MonoBehaviour
{
    canon canon;
    private void Start()
    {
        canon = GetComponentInParent<canon>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            canon.Shooting = false;
            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        canon.Shooting = true;
    }
}
