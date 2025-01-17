using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ChangingScene : MonoBehaviour
{
   

    void Start()
    {
        
        


    }

    // Start is called before the first frame update
    public void Stage1Scene()
    {
        SceneManager.LoadScene("Gameplay1");
    }

    public void StageScreen()
    {
        SceneManager.LoadScene("StageScreen");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("MenuScreen");
    }

}


    

