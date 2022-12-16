using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CamMovement : MonoBehaviour
{
    public PhotonView view;
    float rotationOnX;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //view= GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
     if (view.IsMine)
 {
        float mouseY = Input.GetAxis("Mouse Y") * 2.4f;
        float mouseX = Input.GetAxis("Mouse X")  * 5f;

        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -85f, 85f);
        transform.localEulerAngles=new Vector3(rotationOnX, 0f, 0f);
        player.Rotate(Vector3.up, mouseX);
    }
    }
}
