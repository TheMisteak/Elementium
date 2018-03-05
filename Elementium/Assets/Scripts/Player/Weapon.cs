using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour {


	private PlayerCombat player_combat;

	void Start() {
		player_combat = GetComponentInParent<PlayerCombat>();
	}


	void OnTriggerEnter(Collider other){
		// layer 8 is the remote players layer
		if(other.gameObject.layer == 8 && other.gameObject.tag != "LocalPlayer") { 
			//all entities must have vitals
			Debug.Log("Triggered: " + player_combat.transform.name);
			other.SendMessage("CmdApplyDamage",-3); // apparently this is expensive? 
		}
	}

    
    // ------------Weapon attack animation and return animation -------- //

    public void ReturnStance(){
		transform.Rotate(-50f,0f,0f);
	}

	public void Attack(){
		transform.Rotate(50f,0f,0f);
	}
	// ---------------------------------------------------------------- //
}
