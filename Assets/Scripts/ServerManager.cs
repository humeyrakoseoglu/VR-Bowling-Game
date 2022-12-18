using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    public bool woman;
    GameObject myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("servera baglandı");
        Debug.Log("Lobiye baglanıyor");
        PhotonNetwork.JoinLobby();

    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Lobiye baglandı");
        Debug.Log("odaya baglanıyor");
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true },TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("odaya girdi.");
        Debug.Log("karakter oluşturuluyor");

         myPlayer.GetComponent<PlayerMovement>().enabled = true;
        myPlayer.GetComponent<PlayerGrab>().enabled = true;
        myPlayer.transform.Find("head").gameObject.SetActive(true);
        
        if (woman)
        {
            myPlayer = (GameObject)PhotonNetwork.Instantiate("woman", Vector3.zero, Quaternion.identity);
        }
        else
        {
            myPlayer = (GameObject)PhotonNetwork.Instantiate("man", Vector3.zero, Quaternion.identity);
        }

        myPlayer.GetComponent<PlayerMovement>().enabled = true;
        myPlayer.GetComponent<PlayerGrab>().enabled = true;
        myPlayer.transform.Find("head").gameObject.SetActive(true);
        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
