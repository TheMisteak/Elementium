using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // ----------- private variables ------------ //
    private const string PLAYER_PREFIX = "P";

    // A Dictionary that holds the player vitals, the idea is that the server will look up a player and call a method on PlayerVitals to update player state
    private static Dictionary<string,PlayerVitals> players = new Dictionary<string,PlayerVitals>();

    public static void RegisterPlayer(string netID, PlayerVitals player) {
        
        string playerid = PLAYER_PREFIX + netID;

        Debug.Log("Registering player: " + playerid);
        player.transform.name = playerid;
        players.Add(playerid, player);
        
    } 

    public static void DeregisterPlayer (string playerID) {
        players.Remove(playerID);
    }

    public static PlayerVitals GetPlayer (string playerID) {
        return players[playerID];
    }
	void OnGUI () {

        // A GUI that shows all players that are spawned
        /*
        GUILayout.BeginArea(new Rect(200,200,200,500));

        GUILayout.BeginVertical();

        foreach (string playerID in players.Keys)
        {
            GUILayout.Label(playerID + "--" + players[playerID].transform.name);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
        */
    }
}
