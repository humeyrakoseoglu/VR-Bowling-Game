using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerGrab : MonoBehaviour

{
    GameObject hand;
    GameObject ball;
    GameObject myplayer;
    public bool isHolding;
    public Animator playerAnim;

    public float maxForceHoldDownTime = 2f;
    public float maxForce = 1000f;
    private float holdDownStartTime;
    private float holdDownTime;
    
    PhotonView view;
    Rigidbody ballRb;
    SphereCollider ballCollider;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        if(ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody>();
            ballCollider = ball.GetComponent<SphereCollider>();
        }

        hand = ReturnDecendantOfParent(this.gameObject, "Hand");
    }

    public GameObject ReturnDecendantOfParent(GameObject parent, string descendantName)
    {

        foreach (Transform child in parent.transform)
        {
            if (child.name == descendantName)
            {
                hand = child.gameObject;
                break;
            }
            else
            {
                ReturnDecendantOfParent(child.gameObject, descendantName);
            }
        }
        return hand;
    }


    // Update is called once per frame
    void Update()
    {
        
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            Vector3 direction = mousePos - Camera.main.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 3f))
            {
                if (hit.collider.gameObject.tag == "Ball")
                {
                    if (Input.GetButtonDown("Fire2"))
                    {
                        hit.collider.gameObject.GetComponent<PhotonView>().TransferOwnership(view.Owner);
                        Grab();
                    }
                   
                }

            }

        if (isHolding)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                holdDownStartTime= Time.time;
                
                
            }
            if (Input.GetButtonUp("Fire1"))
            {
                holdDownTime = Time.time - holdDownStartTime;
                if (holdDownTime < 0.2f)
                {
                    ballCollider.isTrigger = false;
                    isHolding = false;
                    ballRb.isKinematic = false;
                    ball.transform.SetParent(null);
                }
                else
                {
                   
                    playerAnim.SetBool("Throwing", true);

                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().CalculatePoints();


                }
            }
            
           
            
        }
        
    }

    public void Grab()
    {

        ballCollider.isTrigger = true;
        ballRb.isKinematic = true;
        ball.transform.SetParent(hand.transform);
        ball.transform.position = hand.transform.position;
        isHolding = true;


    }
    public void LaunchBall()
    {
        ballCollider.isTrigger = false;
        isHolding = false;
        ballRb.isKinematic = false;
        ball.transform.SetParent(null);
        ballRb.velocity = Camera.main.transform.rotation * Vector3.forward * CalculateForce(holdDownTime) *Time.deltaTime;
        playerAnim.SetBool("Throwing", false);
    }
    private float CalculateForce(float holdTime)
    {
        
        float holdTimeNormalized= Mathf.Clamp01 (holdTime/ maxForceHoldDownTime);
        float force = holdTimeNormalized * maxForce;
        return force;
    }
    
}
