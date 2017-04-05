using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGUIController : MonoBehaviour {

	[SerializeField] private Button _submitButton;

	void OnJoinedLobby () {
        _submitButton.onClick.AddListener (() => {
            PhotonNetwork.JoinRandomRoom();
        });
    }
}
