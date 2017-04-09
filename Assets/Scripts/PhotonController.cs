using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    [SerializeField] private GameObject _player;
    private GameObject _myPlayer;
    private ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();
    private int _copiedPositionNumber;

    private Vector3[] _spawnPoints = {
         new Vector3(0f, 0f, 0f),
         new Vector3(17f, 0f, 85f),
         new Vector3(-3f, 0f, -45f),
         new Vector3(45f, 12f, 12f),
    };

    void Start(){
        PhotonNetwork.isMessageQueueRunning = true;
         _copiedPositionNumber = (int)PhotonNetwork.room.customProperties["PositionNumber"];
        CreateMyPlayer();
        _copiedPositionNumber++;
        if (_copiedPositionNumber == 3)
        {
           _copiedPositionNumber = 0;
        }

        roomHash.Add("PositionNumber", _copiedPositionNumber);
        PhotonNetwork.room.SetCustomProperties(roomHash);
    }

    void CreateMyPlayer()
    {
        _myPlayer = (GameObject)PhotonNetwork.Instantiate(
            _player.name,
            _spawnPoints[_copiedPositionNumber],
            Quaternion.identity,
            0
        );

        _myPlayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        _myPlayer.GetComponent<CharacterController>().enabled = true;
        _myPlayer.GetComponent<AudioListener>().enabled = true;

        GameObject _mainCamera = GameObject.FindWithTag("MainCamera");
        _mainCamera.GetComponent<Camera>().enabled = true;
    }

    public void Respawn()
    {
        Destroy(_myPlayer);
        CreateMyPlayer();
    }
}
