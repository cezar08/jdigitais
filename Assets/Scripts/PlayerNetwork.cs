using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {

	void Start () {
		if (isLocalPlayer) {			
			GetComponent<CharacterController>().enabled = true;
			GetComponent<Movimento>();enabled = true;			
		}
	}

}
