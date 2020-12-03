using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    GameObject scoreText;
    private int score;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText");
        resetScore();
    }

    public void incrementScore()
    {
        score++;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void resetScore()
    {
        score = 0;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
