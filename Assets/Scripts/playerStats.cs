using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script tracks and stores all player statistics such as currency, resources and current shift. 
/// Also stores associated scripts to change these variables easily.
/// "Overall" version of floats are planned to be used for a stat screen, but not implemented.
/// </summary>
public static class playerStats {

    // Money earned from start to end - unused
    public static float overallMoney;
    // Money has no value in this game, still used to show in GUI
    public static float curMoney;
    // Unused
    public static float contributedMoney;

    public static float overallMetal;
    public static float curMetal;

    public static float overallSingle;
    public static float curPlasticsSingle;

    public static float overallRecycle;
    public static float curPlasticsRecycle;

    public static float overallFood;
    public static float curFood;

    public static float curShift = 0;

    public static void changePlayerMoney(float value) {
        curMoney += value;
        overallMoney += value;
    }
    public static float changePlayerMetal() {
        overallMetal++;
        return curMetal++;
    }
    public static float changePlayerPlasticsSingle() {
        overallSingle++;
        return curPlasticsSingle++;
    }
    public static float changePlayerPlasticsRecycle() {
        overallRecycle++;
        return curPlasticsRecycle++;
    }
    public static float changePlayerFood() {
        overallFood++;
        return curFood++;
    }


}
