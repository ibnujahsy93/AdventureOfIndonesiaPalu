using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    public int hint;
    public Image[] hints;
    public Sprite logoHint;
    public Sprite emptyHint;
    public HiddenObject hintVar;

    public int timerHint;
    public Image[] timerHints;
    public Sprite timerLogoHint;
    public Sprite timerEmptyHint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hints)
        {
            img.sprite = emptyHint;
        }

        for (int i = 0; i < hint; i++)
        {
            hints[i].sprite = logoHint;
        }


        foreach (Image img in timerHints)
        {
            img.sprite = timerEmptyHint;
        }

        for (int i = 0; i < timerHint; i++)
        {
            timerHints[i].sprite = timerLogoHint;
        }
    }

    public void HintButton()
    {
        if (hint > 0)
        {
            hint--;
            int z = Random.Range(0, hintVar.itemParent.transform.childCount);
            hintVar.uiManager.TransformOut(hintVar.itemParent.transform.GetChild(z));
            
        }
        else
        {
            return;
        }

    }

    public void TimerButton()
    {
        if (timerHint > 0)
        {
            timerHint--;
            hintVar.timeRemaining += 120;
            
        }
        else
        {
            return;
        }
    }
}
