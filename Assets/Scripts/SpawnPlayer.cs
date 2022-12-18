using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    GameObject myPlayer;
    

    
    void Start()
    {

        if (GenderSelection.selectWoman)
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
