using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    [SerializeField] float coolDown = 2f;
    float lastShotTime;
    public Transform bulletPosition;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        fire();
    }
    void fire()
    {
        if (Time.time - lastShotTime < coolDown)
            return;
        lastShotTime = Time.time;
        Instantiate(bullet,bulletPosition.position,bulletPosition.rotation);
        
    }
}
