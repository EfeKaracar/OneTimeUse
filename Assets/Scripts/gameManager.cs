﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    GUIManager guim;
    timeManager tm;
    private void Start() {
        tm = GetComponent<timeManager>();
        guim = GetComponent<GUIManager>();
    }
    public void endShift() {
        guim.reportContinue();
    }

    public void startShift() {
        StartCoroutine("hideShiftNote");
        tm.pauseGame();

        tm.tempSeconds = 0;
        tm.tempMinutes = 0;
        tm.gameTime = 0;
        playerStats.curShift++;
    }
    IEnumerator hideShiftNote() {
        yield return new WaitForSeconds(1);
        guim.NOTE_shift.transform.Find("NewShift").gameObject.SetActive(false);
    }
}