using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        //PhotonNetwork.JoinOrCreateRoom("BowlingRoom", new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true}, TypedLobby.Default);
       // PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true },TypedLobby.Default);
        SceneManager.LoadScene("Lobby");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
