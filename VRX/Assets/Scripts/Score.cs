using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public int goal;
    public Text scoreText;

    

    // Update is called once per frame
    void Update()
    {
        
        if (FindObjectOfType<Handsink>().AwardPoint())
        {
            score++;
        }
        scoreText.text = "Points: " + score.ToString() + "/" + goal.ToString();
    }
}
