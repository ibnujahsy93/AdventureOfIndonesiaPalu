using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPos : MonoBehaviour
{
    public static ControlPos Instance { get; set; }


    [System.Serializable]
    public class ObjectList
    {
        public List<Vector3> objectPos, objectScale;
       

    }
    public List<ObjectList> savedPosition, savedHintPos; //Berapa Banyak Posisi template posisi object yang diinginkan

    [Header("Objects")]
    public GameObject objectParent;
    public int saveNumber;

    [Header("Hints")]
    public GameObject hintObject;
    public int saveValHint;



    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveObjectPosition()
    {
        for (int i = 0; i < objectParent.transform.childCount; i++)
        {
            if (savedPosition[saveNumber].objectPos.Count < objectParent.transform.childCount) //Menyimpas Save pos baru
            {
                savedPosition[saveNumber].objectPos.Add(objectParent.transform.GetChild(i).transform.localPosition);
                savedPosition[saveNumber].objectScale.Add(objectParent.transform.GetChild(i).transform.localScale);

            }
            else //Menimpa Value yang sudah ada
            {
                savedPosition[saveNumber].objectPos[i] = objectParent.transform.GetChild(i).transform.localPosition;
                savedPosition[saveNumber].objectScale[i] = objectParent.transform.GetChild(i).transform.localScale;
            }
        }

        
    }

    public void SavedHintPosition()
    {
        for (int i = 0; i < hintObject.transform.childCount; i++)
        {
            if (savedHintPos[saveValHint].objectPos.Count < hintObject.transform.childCount) //Menyimpas Save pos baru
            {
                savedHintPos[saveValHint].objectPos.Add(hintObject.transform.GetChild(i).transform.localPosition);
                savedHintPos[saveValHint].objectScale.Add(hintObject.transform.GetChild(i).transform.localScale);

            }
            else //Menimpa Value yang sudah ada
            {
                savedHintPos[saveValHint].objectPos[i] = hintObject.transform.GetChild(i).transform.localPosition;
                savedHintPos[saveValHint].objectScale[i] = hintObject.transform.GetChild(i).transform.localScale;
            }
        }
    }
}
