using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;
    [SerializeField] private GameObject confirmationPrompt = null;



    [SerializeField] GameObject notifConfirm;
    public GameObject notifLoc;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        volumeTextValue.text = PlayerPrefs.GetFloat("masterVolume").ToString("0.0");
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        Destroy(Instantiate(notifConfirm, notifLoc.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform), 2f);

    }

    public void DefaultVolumeSet(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }
}
