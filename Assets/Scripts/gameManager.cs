﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    GUIManager guim;
    timeManager tm;
    entityLib lib;
    spawnManager sm;
    [Header("Cinematic")]
    public GameObject cinematicSpawn;
    public GameObject cinematicCam;
    public GameObject cinematicOverlay;

    [Header("Audio")]
    public AudioClip correctMatch;
    public AudioClip missedItem;
    public AudioClip wrongMatch;

    [Header("Debug")]
    public bool spawnAll = false;

    private void Start() {
        tm = GetComponent<timeManager>();
        guim = GetComponent<GUIManager>();
        lib = GetComponent<entityLib>();
        sm = GetComponent<spawnManager>();
    }
    /// <summary>
    /// This script is called from every end of a shift.
    /// </summary>
    public void endShift() {
        tm.pauseGame();
        guim.reportContinue();
        guim.pauseBlock.transform.Find("T").gameObject.SetActive(false);
        guim.pauseBlock.transform.Find("T1").gameObject.SetActive(false);
    }
    /// <summary>
    /// This script plays an audio at a position.
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="position"></param>
    public void playClip(AudioClip clip, Vector3 position) {
        AudioSource.PlayClipAtPoint(clip, position);
    }
    /// <summary>
    /// This script is called from answering the question at the end of every shift report. It resets all the player parameters relevant to a shift
    /// and makes sure player starts on a new day.
    /// </summary>
    public void startShift() {
        if(playerStats.curShift < 5) { 
            StartCoroutine("hideShiftNote");
            tm.pauseGame();

            tm.tempSeconds = 0;
            tm.tempMinutes = 0;
            tm.minutesText.text = 0.ToString();
            tm.gameTime = 0;

            playerStats.curShift++;
            playerStats.curMoney = 0;
            playerStats.curMetal = 0;
            playerStats.curPlasticsRecycle = 0;
            playerStats.curPlasticsSingle = 0;
            playerStats.curFood = 0;
            setup();
            sm.loadResources();

            foreach(GameObject S in sm.spawnedItems) {
                if(S != null) { 
                Destroy(S);
                }
            }
            sm.spawnedItems.Clear();
        }
        else {
            showEndCinematic();
        }
    }
    /// <summary>
    /// This script hides the shift notification on new day after a second.
    /// </summary>
    /// <returns></returns>
    IEnumerator hideShiftNote() {
        yield return new WaitForSeconds(1);
        guim.NOTE_shift.transform.Find("NewShift").gameObject.SetActive(false);
    }
    /// <summary>
    /// This script is called at startShift script, which is fired once everytime a new shift begins to prepare the next shift with new challenges and a set.
    /// e.g - first day you only get 2 bins, 30 second and one conveyor. On 3rd day, you get 60 second, 2 conveyor and 4 bins. This script sets it all up. Based on playerStats.shift.
    /// </summary>
    public void setup() {
        if(playerStats.curShift == 1) {
            gameBalancing.shiftDurationInSeconds = 30; // 30
            gameBalancing.itemMoveSpeed = 2f;
            gameBalancing.allowRecycleForSpawn = true;
            gameBalancing.allowSingleForSpawn = true;
            lib.hideBin("Metal");
            lib.hideBin("Food");
        }
        if(playerStats.curShift == 2) {
            gameBalancing.shiftDurationInSeconds = 45; // 45
            gameBalancing.itemMoveSpeed = 2.3f;
            gameBalancing.allowMetalForSpawn = true;
            lib.showBin("Metal");
        }
        if(playerStats.curShift == 3) {
            gameBalancing.shiftDurationInSeconds = 60; // 60
            gameBalancing.activateSecondRail = true;
            lib.secondRail.SetActive(true);
        }
        if(playerStats.curShift == 4) {
            gameBalancing.shiftDurationInSeconds = 90; // 90
            gameBalancing.itemMoveSpeed = 2.6f;
            gameBalancing.allowFoodForSpawn = true;
            lib.showBin("Food");
        }
        if (playerStats.curShift == 5) {
            gameBalancing.shiftDurationInSeconds = 120; // 120
            gameBalancing.itemMoveSpeed = 3f;
        }

        // Debug
        if (tm.shortenTimers) { gameBalancing.shiftDurationInSeconds = 3; }
        if (spawnAll) { 
            gameBalancing.allowFoodForSpawn = true;
            gameBalancing.allowMetalForSpawn = true;
            gameBalancing.allowRecycleForSpawn = true;
            gameBalancing.allowSingleForSpawn = true;
        }
    }
    /// <summary>
    /// This script turns money earned to contributed money.
    /// </summary>
    public void contributeMoney() {
        playerStats.contributedMoney += playerStats.curMoney;
    }
    /// <summary>
    /// This script starts the end cinematic.
    /// </summary>
    public void showEndCinematic() {
        AudioListener.volume = 0;
        guim.HUD_shift.gameObject.SetActive(false);
        guim.NOTE_shift.gameObject.SetActive(false);
        guim.feedback.SetActive(false);
        Time.timeScale = 1;
        guim.HUD.SetActive(false);
        cinematicCam.SetActive(true);
        Camera.main.gameObject.SetActive(false);
        foreach(GameObject S in sm.singlePlastics) {
            S.transform.position = cinematicSpawn.transform.position;
            for(int i = 0; i < 2; i++) { Instantiate(S, cinematicSpawn.transform.position, Quaternion.identity); }
        }
        StartCoroutine("showOverlay");
    }
    /// <summary>
    /// Shows the final overlay after cinematic is shown.
    /// </summary>
    /// <returns></returns>
    IEnumerator showOverlay() { 
        yield return new WaitForSeconds(10);
        cinematicOverlay.SetActive(true);
        //Time.timeScale = 1 / 4;
    }
    /// <summary>
    /// This script mutes/unmutes the game.
    /// </summary>
    public void muteGame() { 
        if(AudioListener.volume == 0) { AudioListener.volume = 1; } else { AudioListener.volume = 0; }
    }


}
