using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldWall : MonoBehaviour, IPooledObject {

    private float t = 0.0f;

	// Move the wall
	void Update () {
        if (t < 1)
        {
            OnObjectSpawn();
        }
    }

    public void OnObjectSpawn()
    {
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);

        transform.position = new Vector3(0f, Mathf.Lerp(transform.position.y, endPosition.y, t), 0f);
        t += 0.5f * Time.deltaTime;
    }
}
