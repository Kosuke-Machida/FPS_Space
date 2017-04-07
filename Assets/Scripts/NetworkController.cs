using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour {

	void Start ()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedRoom ()
	{
		PhotonNetwork.isMessageQueueRunning = false;
		Application.LoadLevelAsync ("Main");
	}

	void OnPhotonRandomJoinFailed ()
	{
		RoomOptions roomOptions = new RoomOptions();
		ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();
		roomHash.Add("PositionNumber", 0);
		roomOptions.MaxPlayers = 4;
    	roomOptions.IsOpen = true;
    	roomOptions.IsVisible = true;
		roomOptions.CustomRoomProperties = roomHash;

		PhotonNetwork.CreateRoom(null, roomOptions, null);
	}
}
