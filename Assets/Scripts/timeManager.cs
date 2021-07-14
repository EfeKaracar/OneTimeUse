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
    public float timeSpentPlaying;
    gameManager gm;
    [Header("Debug Tools")]
    public bool disableShifts;

    // Update is called once per frame
    void Start() {
        gm = GetComponent<gameManager>();
        InvokeRepeating("runTime", 0, 1);
    }

    public void runTime() {
        gameTime++;
        timeSpentPlaying++;
        tempSeconds++;
        secondsText.text = tempSeconds.ToString();
        if(tempSeconds == 60) {
            tempMinutes++;
            minutesText.text = tempMinutes.ToString();
            tempSeconds = 0;
        }
        if(gameTime == gameBalancing.shiftDurationInSeconds) {
            if(!disableShifts)
            gm.endShift();
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
