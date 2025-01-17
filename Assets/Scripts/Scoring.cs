using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public HiddenObject hiddenObject;
    public int score, highScore;
    public Text scoreText, highScoreText, lastScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highestScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void UpdateScore()
    {
        if (hiddenObject.timeRemaining > 80)
        {
            score += 100;
        }
        else if (hiddenObject.timeRemaining > 50)
        {
            score += 50;
        }
        else if (hiddenObject.timeRemaining >= 0)
        {
            score += 30;
        }
        scoreText.text = "SCORE : "+score.ToString();
        
        Debug.Log(score);
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "High Score : " + highScore.ToString();
    }

    public void RecentScore()
    {
        lastScoreText.text = "Score : " + score.ToString();
    }

    
    

    public void SaveRecentScore()
    {
        PlayerPrefs.SetInt("recentScore", score);
    }
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("highestScore", highScore);
    }

}
