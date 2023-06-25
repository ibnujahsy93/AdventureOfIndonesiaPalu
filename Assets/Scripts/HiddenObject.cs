using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HiddenObject : MonoBehaviour
{
    
    public ControlPos controlPos;
    public GameObject itemParent;
    public GameObject[] itemTarget;

    // Start is called before the first frame update
    void Start()
    {
        RandomObjectPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomObjectPos()
    {
        int randomSave = Random.Range(0, controlPos.savedPosition.Count);
        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            itemParent.transform.GetChild(i).transform.localPosition = controlPos.savedPosition[randomSave].objectPos[i];
            itemParent.transform.GetChild(i).transform.localScale = controlPos.savedPosition[randomSave].objectScale[i];

            itemParent.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void ButtonObject()
    {
        for (int i = 0;i < itemTarget.Length;i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == itemTarget[i].name)
            {
                Debug.Log("Benar");
                Destroy(EventSystem.current.currentSelectedGameObject);
                EventSystem.current.currentSelectedGameObject.SetActive(false);
                itemTarget[i].SetActive(false);
            }

        }
    }
}
