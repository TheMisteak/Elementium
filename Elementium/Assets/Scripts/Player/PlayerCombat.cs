using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


//--------- Required Components-------//
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStats))]
//------------------------------------//
public class PlayerCombat : NetworkBehaviour {

	// ------- Private cached components ---------- //
	PlayerMovement playerMovement;
	Weapon weapon;
	PlayerStats playerStats;

	PlayerVitals playerVitals;


	void Start () {
		// Initialize
		playerVitals = GetComponent<PlayerVitals>();
		playerMovement = GetComponent<PlayerMovement>();
		weapon = GetComponentInChildren<Weapon>();
		playerStats = GetComponent<PlayerStats>();

	}
	

	public void UpdateMe () {

		//------------Mouse left click attack action ------------//
		if(Input.GetMouseButtonDown(0)){
			//DoDamage();
			weapon.Attack();// Trigger animation


		} else if (Input.GetMouseButtonUp(0)) {
			weapon.ReturnStance();
		}
		//--------------------------------------------------------//
	}

	// Server commands can only use primitives as parameters therefore we need to use ids rather than game object
	[Command]
	public void CmdApplyDamage(int dmg) {
		// TODO: investigate null cached components if game manager returns Player rather than PlayerVitals ex. player.playerVitals.updateHealth does not work.
		Debug.Log("CMD called");
		PlayerVitals playerVitals = GameManager.GetPlayer(transform.name);
		Debug.Log(playerVitals);		
		playerVitals.UpdateHealth(dmg);
	}


	[Client]
	void DoDamage(){
		GameObject target = playerMovement.GetRayCast(LayerMask.GetMask("Entities")); // layer 8 is all entities
        if (target != null){
			// at this moment ray casting is not needed for combat
        }
	}


	
}
