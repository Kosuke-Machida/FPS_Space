using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGUIController : MonoBehaviour {

    [SerializeField] private Text _connectionStateValue;
	[SerializeField] private Button _roomCreateButton;
    [SerializeField] private InputField _roomNameInputField;
    [SerializeField] private Canvas _confirmationBoard;
    [SerializeField] private GameObject _content;
	[SerializeField] private GameObject _roomItem;
    [SerializeField] private Button _joinButton;
    private Canvas _instantiatedConfirmationBoard;
    private ConfirmationGUIManager _confirmationGUIManager;

	void OnJoinedLobby ()
    {
        _connectionStateValue.text = "Lobby";
        _roomCreateButton.onClick.AddListener (() =>
        {
            NetworkController.CreateRoom(_roomNameInputField.text);
            _connectionStateValue.text = "Room";
        });
    }

    void OnJoinedRoom ()
    {
        _instantiatedConfirmationBoard = Instantiate(_confirmationBoard);
        _confirmationGUIManager = _instantiatedConfirmationBoard.GetComponent<ConfirmationGUIManager>();
        _confirmationGUIManager.SetUpGUI();
    }

    void OnReceivedRoomListUpdate ()
    {
        ShowRoomsIndex ();
    }

    void ShowRoomsIndex ()
	{
		GameObject roomObj = null;
        Button joinButton = null;
        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            roomObj = Instantiate(
                _roomItem,
                _content.transform.position,
                Quaternion.identity,
                _content.transform
            );
            joinButton =  Instantiate(
                _joinButton,
                roomObj.transform.position + new Vector3(0, 20, 0),
                Quaternion.identity,
                roomObj.transform
            );
            _roomItem.GetComponent<RoomItemController>().SetRoomItem(room, joinButton);
		}
	}
}
