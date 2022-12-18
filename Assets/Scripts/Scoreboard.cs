using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public GameController gameController;

    public TextMeshProUGUI p1f1;
    public TextMeshProUGUI p1f2;
    public TextMeshProUGUI p1f3;
    public TextMeshProUGUI p1f4;
    public TextMeshProUGUI p1f5;

    public TextMeshProUGUI p2f1;
    public TextMeshProUGUI p2f2;
    public TextMeshProUGUI p2f3;
    public TextMeshProUGUI p2f4;
    public TextMeshProUGUI p2f5;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;

    void Start()
    {

    }

    void Update()
    {
        p1f1.text = gameController.getFramePoints1(0).ToString();
        p1f2.text = gameController.getFramePoints1(1).ToString();
        p1f3.text = gameController.getFramePoints1(2).ToString();
        p1f4.text = gameController.getFramePoints1(3).ToString();
        p1f5.text = gameController.getFramePoints1(4).ToString();

        p2f1.text = gameController.getFramePoints2(0).ToString();
        p2f2.text = gameController.getFramePoints2(1).ToString();
        p2f3.text = gameController.getFramePoints2(2).ToString();
        p2f4.text = gameController.getFramePoints2(3).ToString();
        p2f5.text = gameController.getFramePoints2(4).ToString();

        score1.text = gameController.getScore(1).ToString();
        score2.text = gameController.getScore(2).ToString();
    }
}
