using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class EarthShieldWall : NetworkBehaviour, IPooledObject {

    //public float speed;

    //private float t = 0.0f;
    //private Vector3 endPosition;

    public float speed;
    public GameObject healthSliderGameObject;
    public Slider healthSliderSide1;
    public Slider healthSliderSide2;

    [SyncVar]
    public float wallHealth = 100f;

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

        wallHealth = 100f;
        healthSliderSide1.value = wallHealth;
        healthSliderSide2.value = wallHealth;
    }

    // Move the wall
    void Update () {
        if (totalDistanceToDestination != 0)
        {
            Move();
        }

        if (Time.time - startTime > 5)
        {
            gameObject.SetActive(false);
            wallHealth = 100f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // TODO:
        // check if collision.gameobject is a destructive element attack

        if (wallHealth < 0)
        {
            // recycle wall
            gameObject.SetActive(false);
            wallHealth = 100f;
        }
        else
        {
            // wallHealth -= destructive elements attack value
            wallHealth -= 1f;
        }

        healthSliderSide1.value = wallHealth;
        healthSliderSide2.value = wallHealth;
    }

    public void Move()
    {
        float currentDuration = Time.time - startTime;
        float journeyFraction = currentDuration / totalDistanceToDestination;
        transform.position = Vector3.Lerp(startPosition, endPosition, journeyFraction * speed);
    }
}
