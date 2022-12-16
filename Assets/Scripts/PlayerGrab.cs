using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour

{
    public GameObject hand;
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
    }

    // Update is called once per frame
    void Update()
    {
        
        
        distance=Vector3.Distance(this.gameObject.transform.position,ball.transform.position);
        print(distance);
        if (!isHolding&isGrabbed&&distance<4f)
        { 
            ballCollider.isTrigger= true;
            ballRb.isKinematic = true;
            isHolding = true;
            ball.transform.SetParent(hand.transform);
            ball.transform.position= hand.transform.position;

        }
        else if (isHolding)
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
        if (distance < 5f)
        {
            isGrabbed = true;
        }
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
