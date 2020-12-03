using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    GameObject scoreText;
    private int score;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

    }
}
