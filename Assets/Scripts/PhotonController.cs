using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonController : MonoBehaviour {
    [SerializeField] private GameObject _player;
    private GameObject _myPlayer;

    void Start(){
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    void OnJoinedLobby(){
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed(){
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom(){
       CreateMyPlayer();
    }

    void CreateMyPlayer()
    {
         _myPlayer = PhotonNetwork.Instantiate(
                        _player.name,
                        new Vector3(0f, 0f, 0f),
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
