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
    public bool enableDebug = false;
    public bool disableShifts = false;
    public bool shortenTimers = false;
    [Range(1, 10)]
    public float timeScale = 1;

    // Update is called once per frame
    void Start() {
        gm = GetComponent<gameManager>();
        InvokeRepeating("runTime", 0, 1);
        
    }
    private void Update() {
        //if (enableDebug) { Time.timeScale = timeScale; }
    }
    /// <summary>
    /// This script runs timers for different purposes. It also checks if player's timer ran out.
    /// </summary>
    public void runTime() {
        gameTime++;
        timeSpentPlaying++;
        tempSeconds++;
        secondsText.text = tempSeconds.ToString();
        if(tempSeconds == 60) {
            tempMinutes++;
            minutesText.text = tempMinutes.ToString();
            tempSeconds = 0;
            secondsText.text = tempSeconds.ToString();
        }
        if(gameTime == gameBalancing.shiftDurationInSeconds) {
            if(!disableShifts)
            gm.endShift();
        }
    }
    /// <summary>
    /// This script pauses/unpauses the game.
    /// </summary>
    public void pauseGame() { 
        if(Time.timeScale == 1) {
            Time.timeScale = 0;
        } else { 
            Time.timeScale = 1;
        }
    }
}
