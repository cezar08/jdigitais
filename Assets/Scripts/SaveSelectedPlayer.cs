using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSelectedPlayer {
	
	public static int player = 1;

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/player.gd"); 
		bf.Serialize(file, SaveSelectedPlayer.player);
		file.Close();
	}   
	
	public static int Load() {
		if(File.Exists(Application.persistentDataPath + "/player.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/player.gd", FileMode.Open);
			SaveSelectedPlayer.player = (int)bf.Deserialize(file);
			file.Close();
		}

		return SaveSelectedPlayer.player;
	}
}