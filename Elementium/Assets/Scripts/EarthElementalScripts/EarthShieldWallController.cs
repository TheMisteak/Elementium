using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldWallController {

    private ObjectPooler objectPooler;

    public EarthShieldWallController(ObjectPooler op)
    {
        objectPooler = op;
    }

    public void Execute(GameObject spawnPoint)
    {
        objectPooler.SpawnFromPool("EarthShieldWall", spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
