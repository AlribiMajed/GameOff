using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    [SerializeField] float coolDown = 2f;
    float lastShotTime;
    public Transform bulletPosition;
    public GameObject bullet;
    public bool Shooting = true;

    private void Start()
    {
        Shooting = true;
    }
    void Update()
    {
        fire();
    }
    void fire()
    {
        if (Time.time - lastShotTime < coolDown)
            return;
        if (Shooting)
        {
        lastShotTime = Time.time;
        Instantiate(bullet,bulletPosition.position,bulletPosition.rotation);
        }

        
    }
}
