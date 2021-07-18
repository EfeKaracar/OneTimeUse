using System.Collections;
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
    private void Start() {
        tm = GetComponent<timeManager>();
        guim = GetComponent<GUIManager>();
        lib = GetComponent<entityLib>();
        sm = GetComponent<spawnManager>();
    }
    public void endShift() {
        tm.pauseGame();
        guim.reportContinue();
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
            tm.gameTime = 0;
            playerStats.curShift++;
            playerStats.curMoney = 0;
            playerStats.curMetal = 0;
            playerStats.curPlasticsRecycle = 0;
            playerStats.curPlasticsSingle = 0;
            playerStats.curFood = 0;
            setup();
            sm.loadResources();
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
            gameBalancing.shiftDurationInSeconds = 30;
            gameBalancing.itemMoveSpeed = 2f;
            gameBalancing.allowRecycleForSpawn = true;
            gameBalancing.allowSingleForSpawn = true;
            lib.hideBin("Metal");
            lib.hideBin("Food");
        }
        if(playerStats.curShift == 2) {
            gameBalancing.shiftDurationInSeconds = 45;
            gameBalancing.itemMoveSpeed = 2.3f;
            gameBalancing.allowMetalForSpawn = true;
            lib.showBin("Metal");
        }
        if(playerStats.curShift == 3) {
            gameBalancing.shiftDurationInSeconds = 60;
            gameBalancing.activateSecondRail = true;
            lib.secondRail.SetActive(true);
        }
        if(playerStats.curShift == 4) {
            gameBalancing.shiftDurationInSeconds = 90;
            gameBalancing.itemMoveSpeed = 2.6f;
            gameBalancing.allowFoodForSpawn = true;
            lib.showBin("Food");
        }
        if (playerStats.curShift == 5) {
            gameBalancing.shiftDurationInSeconds = 120;
            gameBalancing.itemMoveSpeed = 3f;
        }
    }

    public void contributeMoney() {
        playerStats.contributedMoney += playerStats.curMoney;
    }

    public void showEndCinematic() {
        Camera.main.gameObject.SetActive(false);
        cinematicCam.SetActive(true);
        foreach(GameObject S in sm.singlePlastics) {
            Instantiate(S, cinematicSpawn.transform.position, Quaternion.identity);
        }
    }
}
