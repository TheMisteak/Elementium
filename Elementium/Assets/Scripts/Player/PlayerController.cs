using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	// Aggregate all components for updating
	//PlayerCombat playerCombat;
	PlayerMovement playerMovement;
    //PlayerVitals playerVitals;
    PlayerElementController playerElement;

	void Start () {
		// Tag the local player to avoid self-collisions
		if(isLocalPlayer) {
			gameObject.tag = "LocalPlayer";
		}

		//playerCombat = GetComponent<PlayerCombat>();
		playerMovement = GetComponent<PlayerMovement>();
        //playerVitals = GetComponent<PlayerVitals>();
        playerElement = GetComponent<PlayerElementController>();

	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer) {
			return;
		}
		//playerCombat.UpdateMe();
		playerMovement.UpdateMe();
        //playerVitals.UpdateMe();
        playerElement.UpdateMe();
	}
}
