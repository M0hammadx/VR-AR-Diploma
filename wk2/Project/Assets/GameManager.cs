using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public bool weoponType = true;//1 normal 0 hooming
    public GameObject homingTimerObj;
    public bool canHome = true;
    public Text scoreText;
    public int score;

    // Use this for initialization
    void Start()
    {
        if (!GM) GM = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateScore(int val)
    {
        score += val;
        scoreText.text = "Score : " + score.ToString();
    }
}
