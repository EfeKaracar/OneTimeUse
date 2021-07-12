using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class timeManager : MonoBehaviour
{
    public TextMeshProUGUI secondsText;
    public TextMeshProUGUI minutesText;
    public float tempSeconds;
    public float tempMinutes;
    public float gameTime;

    // Update is called once per frame
    void Start() {
        InvokeRepeating("runTime", 0, 1);
    }

    public void runTime() {
        gameTime++;
        tempSeconds++;
        secondsText.text = tempSeconds.ToString();
        if(tempSeconds == 60) {
            tempMinutes++;
            minutesText.text = tempMinutes.ToString();
            tempSeconds = 0;
        }
        if(gameTime == gameBalancing.shiftDurationInMinutes * 60) { 
            
        }
    }
    public void pauseGame() { 
        if(Time.timeScale == 1) {
            Time.timeScale = 0;
        } else { 
            Time.timeScale = 1;
        }
    }
}
