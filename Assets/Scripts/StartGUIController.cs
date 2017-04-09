using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGUIController : MonoBehaviour {

    [SerializeField] private Text _connectionStateValue;
	[SerializeField] private Button _roomCreateButton;
    [SerializeField] private InputField _roomNameInputField;
    [SerializeField] private Canvas _confirmationBoard;

	void OnJoinedLobby () {
        _connectionStateValue.text = "Lobby";
        _roomCreateButton.onClick.AddListener (() => {
            NetworkController.CreateRoom(_roomNameInputField.text);
            _connectionStateValue.text = "Room";
            Instantiate(_confirmationBoard);
        });
    }
}
