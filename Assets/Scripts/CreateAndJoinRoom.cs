using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{

    
    public InputField joinInput;

    // Start is called before the first frame update
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(joinInput.text);
    }

    // Update is called once per frame
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
        
    }

