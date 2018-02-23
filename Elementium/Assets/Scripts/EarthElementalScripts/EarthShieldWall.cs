using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldWall : MonoBehaviour, IPooledObject {

    //public float speed;

    //private float t = 0.0f;
    //private Vector3 endPosition;

    public float speed;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime = 0.0f;
    private float totalDistanceToDestination;

    public void OnObjectSpawn()
    {
        startPosition = transform.position;

        startTime = Time.time;
        endPosition = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);
        totalDistanceToDestination = Vector3.Distance(transform.position, endPosition);
    }

    // Move the wall
    void Update () {
        
        if (totalDistanceToDestination != 0)
        {
            Move();
        }
    }

    public void Move()
    {
        float currentDuration = Time.time - startTime;
        float journeyFraction = currentDuration / totalDistanceToDestination;
        transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction * speed);
    }
}
