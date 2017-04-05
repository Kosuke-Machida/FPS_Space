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

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
}
