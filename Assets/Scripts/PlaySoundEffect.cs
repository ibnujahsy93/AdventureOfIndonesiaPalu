using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioSource correctObjSfx;
    public AudioSource wrongSoundSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySfx()
    {
        correctObjSfx.Play();
    }
    public void PlayWrongSfx()
    {
        wrongSoundSfx.Play();
    }

}
