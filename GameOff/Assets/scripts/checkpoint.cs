using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    PlayerDeath pd;
    void Start()
    {
        pd = GameObject.Find("player").GetComponent<PlayerDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            pd.respawnPoint = gameObject.transform;
    }
}
