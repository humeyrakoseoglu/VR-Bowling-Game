using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] standingPins;
    public GameObject[] allPins;
    public int points;
    public int framePoints;
    public int score;

    float time;
    public Quaternion ballRotation;
    private bool isReset = false;

    Rigidbody ballRb;
    Rigidbody pinRb;

    public int remainingRoll;

    private int[] framePoints1 = new int[5];
    private int[] framePoints2 = new int[5];

    private int i;
    private int j;

    public int score1;
    public int score2;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRb = ball.GetComponent<Rigidbody>();
        ballRotation = ball.transform.rotation;
        allPins = GameObject.FindGameObjectsWithTag("Pin");

        points = 0;
        framePoints = 0;
        score = 0;
        remainingRoll = 2;
        i = 0;
        j = 0;
        score1 = 0;
        score2 = 0;
    }

    private void Update()
    {
        standingPins = GameObject.FindGameObjectsWithTag("Pin");

        if (isReset)
        {
            ball.transform.rotation = Quaternion.Slerp(ballRotation, Quaternion.identity, time);
            time += Time.deltaTime;
        }

    }

    public void CalculatePoints()
    {
        StartCoroutine(WaitForPoints());
    }

    IEnumerator WaitForPoints()
    {
        yield return new WaitForSeconds(5f);

        points = 0;


        if (remainingRoll > 0 & j < framePoints1.Length)
        {
            foreach (GameObject pin in standingPins)
            {
                int x = (int)pin.GetComponent<Transform>().localEulerAngles.x;

                if ((x > 260 && x < 280))
                {
                }
                else
                {

                    points++;
                    framePoints++;

                    pin.tag = "Untagged";
                    pin.SetActive(false);

                }
            }
            remainingRoll--;

            if (remainingRoll == 1 & framePoints == 10)
            {
                framePoints = 15;
                remainingRoll = 2;
                if (i <= j)
                {
                    framePoints1[i] = framePoints;
                    score1 += framePoints1[i];
                    i++;
                }
                else
                {
                    framePoints2[j] = framePoints;
                    score2 += framePoints2[j];
                    j++;
                }

                framePoints = 0;
                resetPins();
            }
            else if (remainingRoll == 0 & framePoints == 10)
            {
                framePoints = 12;
                remainingRoll = 2;
                if (i <= j)
                {
                    framePoints1[i] = framePoints;
                    score1 += framePoints1[i];
                    i++;
                }
                else
                {
                    framePoints2[j] = framePoints;
                    score2 += framePoints2[j];
                    j++;
                }

                framePoints = 0;
                resetPins();
            }
            else if (remainingRoll == 0 & framePoints < 10)
            {
                remainingRoll = 2;
                if (i <= j)
                {
                    framePoints1[i] = framePoints;
                    score1 += framePoints1[i];
                    i++;
                }
                else
                {
                    framePoints2[j] = framePoints;
                    score2 += framePoints2[j];
                    j++;
                }

                framePoints = 0;
                resetPins();
            }
        }

        if (j == framePoints2.Length)
        {
            StartCoroutine(WaitForTenSeconds());
        }


        ball.transform.position = new Vector3(-5f, 0.618f, 10f);
        ballRb.velocity = Vector3.zero;
        ballRb.useGravity = true;
        isReset = true;

        yield return null;
    }

    public void resetPoints()
    {
        i = 0;
        j = 0;

        for (int a = 0; a < framePoints1.Length; a++)
        {
            framePoints1[a] = 0;
            framePoints2[a] = 0;
        }

        score1 = 0;
        score2 = 0;
    }

    public void resetPins()
    {
        foreach (GameObject pin in allPins)
        {
            pin.tag = "Pin";
            pin.SetActive(true);

            pinRb = pin.GetComponent<Rigidbody>();
            pinRb.isKinematic = true;
            pinRb.useGravity = false;

            if (pin.name == "Pin 1")
            {
                pin.transform.position = new Vector3(4.5f, 0.52f, 9.7f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 2")
            {
                pin.transform.position = new Vector3(4.8f, 0.52f, 9.9f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 3")
            {
                pin.transform.position = new Vector3(4.8f, 0.52f, 9.5f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 4")
            {
                pin.transform.position = new Vector3(5.1f, 0.52f, 10.1f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 5")
            {
                pin.transform.position = new Vector3(5.1f, 0.52f, 9.7f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 6")
            {
                pin.transform.position = new Vector3(5.1f, 0.52f, 9.3f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 7")
            {
                pin.transform.position = new Vector3(5.4f, 0.52f, 10.3f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 8")
            {
                pin.transform.position = new Vector3(5.4f, 0.52f, 9.9f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 9")
            {
                pin.transform.position = new Vector3(5.4f, 0.52f, 9.5f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
            if (pin.name == "Pin 10")
            {
                pin.transform.position = new Vector3(5.4f, 0.52f, 9.1f);
                pin.transform.rotation = Quaternion.Euler(270, 0, 90);
                pinRb.isKinematic = false;
                pinRb.useGravity = true;

            }
        }
    }

    public void resetGame()
    {
        resetPoints();
        resetPins();
    }

    IEnumerator WaitForTenSeconds()
    {
        yield return new WaitForSeconds(10f);

        resetGame();
    }

    public int getFramePoints1(int index)
    {
        return framePoints1[index];
    }


    public int getFramePoints2(int index)
    {
        return framePoints2[index];
    }

    public int getScore(int index)
    {
        if (index == 1)
        {
            return score1;
        }
        else if (index == 2)
        {
            return score2;
        }
        return 0;
    }

    
}
