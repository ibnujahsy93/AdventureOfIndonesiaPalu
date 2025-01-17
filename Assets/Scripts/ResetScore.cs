using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] GameObject notifSuccess;
    public GameObject notifLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScoreAll()
    {
        PlayerPrefs.SetInt("highestScore", 0);
    }
    public void ResetScoreApply()
    {
        Destroy(Instantiate(notifSuccess, notifLoc.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform), 2f);
    }
}
