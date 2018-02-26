using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementController : MonoBehaviour {

    private EarthShieldWallController earthShield;

    [SerializeField]
    private GameObject playerLowerSpawn;

    [SerializeField]
    private GameObject playerUnderSpawn;

    [SerializeField]
    private ObjectPooler objectPooler;

    private void Start()
    {
        //playerLowerSpawn = gameObject.transform.GetChild(1).transform;  // getting UnderPlayerTransform child's transform

        earthShield = new EarthShieldWallController(objectPooler);
    }

    private void FixedUpdate()
    {
        playerLowerSpawn.transform.position = new Vector3(playerLowerSpawn.transform.position.x, -4.5f, playerLowerSpawn.transform.position.z);
        playerUnderSpawn.transform.position = new Vector3(playerUnderSpawn.transform.position.x, -4.5f, playerUnderSpawn.transform.position.z);
    }

    public void UpdateMe()
    {
        if (Input.GetKey(KeyCode.V) && Input.GetKeyDown(KeyCode.R))
        {
            // Shield wall under player
            playerUnderSpawn.transform.Rotate(new Vector3(0f, 90f, 0f));
            earthShield.Execute(playerUnderSpawn);
            playerUnderSpawn.transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.R)) // R can be changed to whatever later
        {
            // Shield Wall
            earthShield.Execute(playerLowerSpawn);
        }


    }

}
