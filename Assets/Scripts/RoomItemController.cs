using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItemController : MonoBehaviour {

	[SerializeField] private Text _roomName;
	[SerializeField] private Text _members;
	public void SetRoomItem (RoomInfo room, Button joinButton)
	{
		_roomName.text = room.name;
		_members.text = "Player Count : " + room.playerCount.ToString() + " / " + room.maxPlayers;
		joinButton.onClick.AddListener (() =>
        {
			PhotonNetwork.JoinRoom(room.name);
        });
	}

}
