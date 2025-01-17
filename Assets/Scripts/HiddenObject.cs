using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class HiddenObject : MonoBehaviour
{
    
    public ControlPos controlPos;
    public Scoring scoring;
    public UIManager uiManager;
    public GameObject itemParent;
    public GameObject[] itemTarget;
    public GameObject PanelGameOver;
    public int totalObj;
    public HintScript hintScript;

    public float timeRemaining;
    public bool timeIsRunning = true;
    public Text timeText;
    public int clueComplete = 0;
    public int seed = 0;

    // Start is called before the first frame update
    void Start()
    {
        seed = PlayerPrefs.GetInt("seednumber");
        int a = 1;
        int c = 3;
        int m = 5;
        

        int number = (a * seed + c) % m;
        PlayerPrefs.SetInt("seednumber", number);
        

        totalObj = itemParent.transform.childCount;
        RandomObjectPos(number);
        if (hintScript.hint < 3 && hintScript.timerHint < 3)
        {
            RandomHintPos();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        scoring.highScore = PlayerPrefs.GetInt("highestScore");
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
               timeIsRunning = false;
               timeRemaining = 0;
               
               scoring.SaveRecentScore();
               scoring.RecentScore();
               if (scoring.score > scoring.highScore)
               {
                   scoring.highScore = scoring.score;
                   scoring.SaveHighScore();
               }
                scoring.UpdateHighScore();
                PanelGameOver.SetActive(true);
            }
        }
        if (clueComplete == totalObj)
        {

            scoring.SaveRecentScore();
            scoring.RecentScore();
            if (scoring.score > scoring.highScore)
            {
                scoring.highScore = scoring.score;
                scoring.SaveHighScore();
            }
            scoring.UpdateHighScore();
            PanelGameOver.SetActive(true);
        }


        
        

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format ("{0:00} : {1:00}", minutes, second);
    }

    public void RandomObjectPos(int number)
    {
        int randomSave = Random.Range(0, controlPos.savedPosition.Count);
        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            itemParent.transform.GetChild(i).transform.localPosition = controlPos.savedPosition[number].objectPos[i];
            itemParent.transform.GetChild(i).transform.localScale = controlPos.savedPosition[number].objectScale[i];

            itemParent.transform.GetChild(i).gameObject.SetActive(true);
            
        }
    }

    public void RandomHintPos()
    {
        int randomSave = Random.Range(0, controlPos.savedHintPos.Count);
        for (int i = 0; i < controlPos.hintObject.transform.childCount; i++)
        {
            controlPos.hintObject.transform.GetChild(i).transform.localPosition = controlPos.savedHintPos[randomSave].objectPos[i];
            controlPos.hintObject.transform.GetChild(i).transform.localScale = controlPos.savedHintPos[randomSave].objectScale[i];

            controlPos.hintObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void ButtonObject()
    {
        for (int i = 0;i < itemTarget.Length;i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == itemTarget[i].name)
            {
                Debug.Log("Benar");
                
                uiManager.ObjectOut(EventSystem.current.currentSelectedGameObject);
                StartCoroutine(FalsingGameObject(i, EventSystem.current.currentSelectedGameObject));
                
            }

        }
    }
    public void HintButtonObject()
    {
        GameObject hintObject = EventSystem.current.currentSelectedGameObject;
        uiManager.ObjectOut(hintObject);
        StartCoroutine(DestroyObjectHint(hintObject));
        
    }

    public void TimerButtonObject()
    {
        GameObject timerObject = EventSystem.current.currentSelectedGameObject;
        uiManager.ObjectOut(timerObject);
        StartCoroutine(DestroyObjectTimer(timerObject));

    }
    IEnumerator DestroyObjectTimer(GameObject gameObject)
    {
        yield return new WaitForSeconds(3f);
        hintScript.timerHint += 1;
        Destroy(gameObject);
    }

    IEnumerator DestroyObjectHint(GameObject gameObject)
    {
        yield return new WaitForSeconds(3f);
        hintScript.hint += 1;
        Destroy(gameObject);
    }


    IEnumerator FalsingGameObject(int target, GameObject currObj)
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(3f);


        currObj.SetActive(false);
        itemTarget[target].SetActive(false);
        clueComplete++;
        scoring.UpdateScore();
        Destroy(currObj);
        
        
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay1");
    }

    public void StopTime()
    {
        timeIsRunning = false;
    }
    public void RunTime()
    {
        timeIsRunning = true;
    }
}
