using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldWallController : MonoBehaviour {

    private GameObject player;
    private ObjectPooler objectPooler;

    public EarthShieldWallController(GameObject p, ObjectPooler op)
    {
        player = p;
        objectPooler = op;
    }

    public void Execute(Transform spawnPoint)
    {
        objectPooler.SpawnFromPool("EarthShieldWall", spawnPoint.position, spawnPoint.rotation);
    }

}
