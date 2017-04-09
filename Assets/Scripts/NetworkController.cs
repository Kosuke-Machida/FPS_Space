using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour {

	[SerializeField] private GameObject _confirmationGUI;
	private ConfirmationGUIManager _confirmationGUIManager;

	void Start ()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedRoom ()
	{
		PhotonNetwork.isMessageQueueRunning = false;
		_confirmationGUIManager = _confirmationGUI.GetComponent<ConfirmationGUIManager>();
		_confirmationGUIManager.SetUpGUI();
	}

	public static void CreateRoom (string name)
	{
		RoomOptions roomOptions = new RoomOptions();
		ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();
		roomHash.Add("PositionNumber", 0);
		roomOptions.MaxPlayers = 4;
		roomOptions.IsOpen = true;
		roomOptions.IsVisible = true;
		roomOptions.CustomRoomProperties = roomHash;

		PhotonNetwork.CreateRoom(name, roomOptions, null);
	}
}
