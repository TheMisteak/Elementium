using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementController : MonoBehaviour {

    private EarthShieldWallController earthShield;

    [SerializeField]
    private Transform playerLowerSpawn;

    [SerializeField]
    private ObjectPooler objectPooler;

    private void Start()
    {
        playerLowerSpawn = gameObject.transform.GetChild(1).transform;  // getting UnderPlayerTransform child's transform

        earthShield = new EarthShieldWallController(gameObject, objectPooler);
    }

    public void UpdateMe()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R can be changed to whatever later
        {
            // Shield Wall
            earthShield.Execute(playerLowerSpawn);
        }


    }

}
