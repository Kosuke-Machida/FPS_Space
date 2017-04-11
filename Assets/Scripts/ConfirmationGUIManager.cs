using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationGUIManager : MonoBehaviour {

	[SerializeField] private Text _roomName;
	[SerializeField] private Text _playerCount;
	[SerializeField] private Text _isOpen;
	[SerializeField] private Text _isVisible;
	[SerializeField] private Button _gameStartButton;
	private ConfirmationGUIManager _confirmationGUIManager;

	void Start ()
	{
		_gameStartButton.onClick.AddListener (() => {
			Application.LoadLevelAsync ("Main");
        });
	}

	void OnReceivedRoomListUpdate ()
	{
		_confirmationGUIManager = gameObject.GetComponent<ConfirmationGUIManager>();
	}

	public void SetUpGUI ()
	{
		_roomName.text = "Room Name : " + PhotonNetwork.room.name;
		_playerCount.text = "Player Count : " + PhotonNetwork.room.playerCount.ToString() + " / " + PhotonNetwork.room.maxPlayers;
		_isOpen.text = "Is Open : " + PhotonNetwork.room.IsOpen;
		_isVisible.text = "Is Visible : " + PhotonNetwork.room.IsVisible;
	}

}
