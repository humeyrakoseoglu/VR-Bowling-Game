using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour

{
    GameObject hand;
    GameObject ball;
    
    public bool isHolding;
    public Animator playerAnim;

    public float maxForceHoldDownTime = 2f;
    public float maxForce = 1000f;
    private float holdDownStartTime;
    private float holdDownTime;
    

    Rigidbody ballRb;
    SphereCollider ballCollider;

    bool isGrabbed;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRb= ball.GetComponent<Rigidbody>();
        ballCollider=ball.GetComponent<SphereCollider>();



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
                    isGrabbed = false;
                    isHolding = false;
                    ballRb.isKinematic = false;
                    ball.transform.SetParent(null);
                }
                else
                {
                   
                    playerAnim.SetTrigger("Throwing");
                   // LaunchBall(CalculateForce(holdDownTime));
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
        isGrabbed = false;
        isHolding = false;
        ballRb.isKinematic = false;
        ball.transform.SetParent(null);
        ballRb.velocity = Camera.main.transform.rotation * Vector3.forward * CalculateForce(holdDownTime) *Time.deltaTime;
    }
    private float CalculateForce(float holdTime)
    {
        
        float holdTimeNormalized= Mathf.Clamp01 (holdTime/ maxForceHoldDownTime);
        float force = holdTimeNormalized * maxForce;
        return force;
    }
    
}
