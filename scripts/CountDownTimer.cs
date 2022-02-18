using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] int minutes;
    [SerializeField] float seconds;
    [SerializeField] bool countDownFinish;
    [SerializeField] Text counterText;

    // Update is called once per frame
    void Update()
    {
        CountDownExecuter();
        CountDownUpdateText();
    }

    void CountDownExecuter()
    {
        int sec;

        if (!countDownFinish)
        {
            seconds -= Time.deltaTime;
            sec = (int)seconds;

            if (sec == 0) //Hemos llegado a 0 segundos 
            {
                if (minutes == 0) countDownFinish = true;
                else
                {
                    minutes--;
                    seconds = 60;
                }
            }

        }
    }

    void CountDownUpdateText()
    {
        int sec;
        sec = (int)seconds;
        if (sec<10) counterText.text = minutes.ToString() + ":0" + sec.ToString();
        else counterText.text = minutes.ToString() + ":" + sec.ToString();
    }
}