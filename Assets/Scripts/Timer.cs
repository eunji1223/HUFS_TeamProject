using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text[] timeText;
    [SerializeField]
    private GameObject WinScene;
    [SerializeField]
    private GameObject LossScene; 

    private bool gameCondition = true; 
    private float time = 180;
    private int min, sec;
    //bool spawnerCondition = Spawner.spawnerCondition;

    void Start()
    {
        timeText[0].text = "03";
        timeText[1].text = "00";
        //WinScene.SetActive(false);
        //LossScene.SetActive(false);
    }

    void Update()
    {

        if (gameCondition)
        {
            timeOpperate();
        }
    }

    void timeOpperate()
    {
        time -= Time.deltaTime;
        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
            WinScene.SetActive(true);
            //spawnerCondition = false; 
        }
        else
        {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            gameCondition = false;
            LossScene.SetActive(true);
           // spawnerCondition = false; 
        }
    }
}
