using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
          
class SpawnPlayer : NetworkManager
{

	public GameObject player;

	public GameObject spawn;

	public GameObject spawn1;

	public GameObject spawn2;

	/*public override void OnServerDisconnect(NetworkConnection conn)
	{
	    NetworkServer.DestroyPlayersForConnection(conn);
	}*/

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{				
		switch (SaveSelectedPlayer.Load()) 
		{
			case 1:
				player = Instantiate(Resources.Load("PlayerPrefab1")) as GameObject;
				player.transform.position = spawn.transform.position;								
				break;
			case 2: 
				player = Instantiate(Resources.Load("PlayerPrefab2")) as GameObject;
				player.transform.position = spawn1.transform.position;								
				break;
			case 3: 
				player = Instantiate(Resources.Load("PlayerPrefab3")) as GameObject;
				player.transform.position = spawn2.transform.position;								
				break;			
		}		
		
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		
	}

	/*public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log ("OnPlayerConnected");
	}*/

}
