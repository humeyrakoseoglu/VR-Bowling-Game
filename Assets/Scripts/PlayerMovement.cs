using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public Animator playerAnim;
    
    public PhotonView view;
    Rigidbody rb;
    public GameObject head;
    float verticalMovement;
    float horizontalMovement;
    Vector3 moveDirection;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        


        if (view.IsMine)
        {
            //horizontalMovement = Input.GetAxisRaw("Horizontal");
           // verticalMovement = Input.GetAxisRaw("Vertical");
            //moveDirection =transform.forward * verticalMovement+transform.right* horizontalMovement;
            if (Input.GetKey(KeyCode.W))
            {
                playerAnim.SetBool("Moving", true);
                //transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
                rb.AddForce(transform.forward* playerSpeed);
            }
            else
            {
                playerAnim.SetBool("Moving", false);
            }
        }
        else
        {
            head.SetActive(false);            
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().resetGame();

        }


    }
}

