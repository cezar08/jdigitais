#if ENABLE_UNET

namespace UnityEngine.Networking
{
	[AddComponentMenu("Network/NetworkManagerHUD")]
	[RequireComponent(typeof(NetworkManager))]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class NetworkManagerHUD : MonoBehaviour
	{
		public NetworkManager manager;
		[SerializeField] public bool showGUI = true;
		[SerializeField] public int offsetX;
		[SerializeField] public int offsetY;

		bool showSelectedPlayer = false;		

		void Awake()
		{
			manager = GetComponent<NetworkManager>();
		}

		void Update()
		{
			if (!showGUI)
				return;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					manager.StartServer();
				}
				if (Input.GetKeyDown(KeyCode.H))
				{
					manager.StartHost();
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					manager.StartClient();
				}
			}
			if (NetworkServer.active && NetworkClient.active)
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					manager.StopHost();
				}
			}
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			int xpos = 10 + offsetX;
			int ypos = 40 + offsetY;
			int spacing = 24;

			if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null && !showSelectedPlayer)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Host(H)"))
				{
					manager.StartHost();					
				}
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 105, 20), "LAN Cliente(C)"))
				{
					manager.StartClient();
				}
				manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), manager.networkAddress);
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Somente Servidor"))
				{
					manager.StartServer();
				}
				ypos += spacing;
			}
			else
			{
				if (NetworkServer.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Servidor: porta=" + manager.networkPort);
					ypos += spacing;
				}
				if (NetworkClient.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Cliente: endereço=" + manager.networkAddress + " porta=" + manager.networkPort);
					ypos += spacing;
				}
			}

			if (NetworkClient.active && !ClientScene.ready)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Cliente Pronto"))
				{
					ClientScene.Ready(manager.client.connection);
				
					if (ClientScene.localPlayers.Count == 0)
					{						
						ClientScene.AddPlayer(0);
					}
				}
				ypos += spacing;
			}

			if (NetworkServer.active || NetworkClient.active)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Parar (X)"))
				{
					manager.StopHost();
				}
				ypos += spacing;
			}
	
				ypos += 10;		
				if (!ClientScene.ready) {		
				if (!showSelectedPlayer)
				{
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Selecione o personagem"))
					{
						showSelectedPlayer = true;
					}
					ypos += spacing;
				}
				else
				{			
					 GUI.color = Color.red;
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Vermelho"))
					{						
						SaveSelectedPlayer.player = 1;
						SaveSelectedPlayer.Save();
						showSelectedPlayer = false;							
					}

					ypos += spacing;
					ypos += 10;

					GUI.color = Color.blue;
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Azul"))
					{						
						SaveSelectedPlayer.player = 2;
						SaveSelectedPlayer.Save();
						showSelectedPlayer = false;
					}

					ypos += spacing;
					ypos += 10;

					GUI.color = Color.yellow;
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Amarelo"))
					{						
						SaveSelectedPlayer.player = 3;
						SaveSelectedPlayer.Save();						
						showSelectedPlayer = false;
					}
					ypos += spacing;				
				}
			}
		}

	}
};
#endif 