using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int countDownStartValue = 5;
    public Text timerText;

    void Start()
    {
        countDownTimer();
    }
    void Update()
    {
       

    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {

            timerText.text = "Timer : " + countDownStartValue;           
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            timerText.text = "GameOver!";
            Time.timeScale = 0;
        }
    }
}