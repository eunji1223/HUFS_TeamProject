using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public void StartToMain()
    {
        SceneManager.LoadScene("MainScene"); // 추후 이름을 MainScene으로 변경해야 함.
    }


    public void StartToOption()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void OptionToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ToAstronaut()
    {
        SceneManager.LoadScene("AstronautExplainScene");
    }

    public void ToAlien()
    {
        SceneManager.LoadScene("AlienExplainScene");
    }
}
