using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class ClickListener : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("Duration between 2 clicks in seconds")]
    [Range(0.01f, 5f)] public float repeatedClickDuration = 5.0f;
    public UnityEvent onRepeatedClick;
    public GameObject spawnObject;
    public Camera cam;
    private byte clicks = 0;
    private DateTime firstClickTime;
    public UIManager manager;
    private Button button;



    public HiddenObject hiddenObject;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        double elapsedSeconds = (DateTime.Now - firstClickTime).TotalSeconds;
        if (elapsedSeconds > repeatedClickDuration)
            clicks = 0;

        clicks++;
        
        
        manager.ObjectScale(spawnObject);
        
        if (clicks == 1)
            firstClickTime = DateTime.Now;
        else if (clicks > 4)
        {
            if (elapsedSeconds <= repeatedClickDuration)
            {
                hiddenObject.timeRemaining -= 30;
                if (button.interactable)
                    onRepeatedClick?.Invoke();
            }
            clicks = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
