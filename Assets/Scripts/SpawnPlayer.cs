using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    //public GameObject myObject;
    
    // Start is called before the first frame update
    void Start()
    {
       // PhotonNetwork.Instantiate(myObject.name, new Vector3(0,5,0), Quaternion.identity, 0, null);
        GameObject myPlayer= (GameObject)PhotonNetwork.Instantiate("character",Vector3.zero, Quaternion.identity);
        myPlayer.GetComponent<PlayerMovement>().enabled = true;
        myPlayer.GetComponent<PlayerGrab>().enabled = true;
        myPlayer.transform.Find("head").gameObject.SetActive(true);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
