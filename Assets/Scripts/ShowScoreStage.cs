using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScoreStage : MonoBehaviour
{
    public Scoring scoring;
    public TMP_Text stage1Score;
    // Start is called before the first frame update
    void Start()
    {
        scoring.highScore = PlayerPrefs.GetInt("highestScore");
        Stage1Score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stage1Score()
    {
        stage1Score.SetText("Score: " + scoring.highScore);
    }
}
