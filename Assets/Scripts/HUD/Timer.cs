using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timerValue = 0;

    public Text timer;

    public bool counting;

    // Start is called before the first frame update
    void Start()
    {
        counting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            timerValue += Time.deltaTime;
        }

        
        
        DisplayTimer(timerValue);
    }

    void DisplayTimer(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (minutes < 10)
        {
            timer.text = string.Format("{0:0} : {1:00}", minutes, seconds);
        }

        else if (minutes >= 10)
        {
            timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }

    
    }
}
