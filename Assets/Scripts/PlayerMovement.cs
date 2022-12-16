using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public Animator playerAnim;
    float inputX;
    float cameraVertical;
    float turnX;
    float turnY;

    public PhotonView view;
   
    void Start()
    {
        //transform.LookAt(look.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // print(ray);
        //transform.localRotation= Quaternion.Euler()
        //transform.rotation = Quaternion.Euler(gvr.mouseY, gvr.mouseX, gvr.mouseZ);
        // transform.position = (transform.rotation * NECK_OFFSET) - (NECK_OFFSET.y * Vector3.up);
        //transform.LookAt(look.transform);
        // inputX = Input.GetAxis("Mouse X");
        //turnX += inputX * 5f;

        //transform.localRotation=Quaternion.Euler(0, turnX+25f, 0);




        //transform.LookAt(look.transform);
        // transform.forward=Camera.main.transform.forward;




        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerAnim.SetBool("Moving", true);
                transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
            }
            else
            {
                playerAnim.SetBool("Moving", false);
            }
        }
       
    }
}
