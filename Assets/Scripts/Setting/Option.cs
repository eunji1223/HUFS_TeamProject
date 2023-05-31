using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Data.Common;
using UnityEngine.UI;


public class Option : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionPage;
    [SerializeField]
    private GameObject SettingPage;

    public AudioMixer audioMixer;

    public Slider BgmSlider;

    //float volume = audioSlider.value;

    //audioMixer.SetFloat(string parameter, volume);

    private bool isClickOptionButton;

    private void Start()
    {
        OptionPage.SetActive(false);
        SettingPage.SetActive(false);
        isClickOptionButton = false;
    }

    // Pause button
    public void OnClickPauseButton()
    {
        if(isClickOptionButton == false)
        {
            isClickOptionButton = true;
            Time.timeScale = 0.0f;
            OptionPage.SetActive(true);
        }
        else
        {
            isClickOptionButton = false;
            Time.timeScale = 1.0f;
            OptionPage.SetActive(false);
        }
        
    }

    // Option page buttons

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickSettingButton()
    {
        SettingPage.SetActive(true);
        OptionPage.SetActive(false);
    }

    // Setting page buttons

    public void OnClickPreviousButton()
    {
        SettingPage.SetActive(false);
        OptionPage.SetActive(true) ;
    }

    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

}
