using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    [SerializeField] float checkDistance = 0.05f;
    Transform targetWaypoint;
    int currentWaypoint;



    void Start()
    {
        targetWaypoint = waypoints[0];

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }



    private Transform GetNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        return waypoints[currentWaypoint];
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (transform.position.y < other.transform.position.y-0.9)
                    other.transform.SetParent(transform);


    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
   
