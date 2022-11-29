using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject rightHand;

    bool inHands = false;

    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;
    public float handPower;

    // Start is called before the first frame update
    void Start()
    { 
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!inHands && rightHand.GetComponent<Grab>().canGrab)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ballCol.isTrigger = true;
                ball.transform.SetParent(rightHand.transform);
                ball.transform.localPosition = new Vector3(0.773f, -0.657f, 3.08f);
                ballRb.velocity = Vector3.zero;
                ballRb.useGravity = false;
                inHands = true;
            }
        }else if(inHands){
            ballCol.isTrigger = false;
            ballRb.useGravity = true;
            this.GetComponent<playerGrab>().enabled = false;
            ball.transform.SetParent(null);
            ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;

            inHands = false;
        }
    }
}   
