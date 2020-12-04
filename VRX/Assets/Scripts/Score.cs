using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int goal;
    public Text scoreText;

    

    void Start()
    {
        score = 0;
        goal = 10;//change this on actual given goal
        scoreText.text = "Points: " + score.ToString() + "/" + goal.ToString();
    }

    public void DecreaseScore()
    {
        score--;
        scoreText.text = "Points: " + score.ToString() + "/" + goal.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Points: " + score.ToString() + "/" + goal.ToString();
    }

}
