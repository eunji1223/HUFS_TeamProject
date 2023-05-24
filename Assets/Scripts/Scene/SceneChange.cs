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
        SceneManager.LoadScene("Astronaut"); // 추후 이름을 MainScene으로 변경해야 함.
    }

    public void MainToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void StartToOption()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
