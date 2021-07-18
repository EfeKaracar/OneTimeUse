using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playerStats {

    public static float money;
    public static float curMetal;
    public static float curPlasticsSingle;
    public static float curPlasticsRecycle;
    public static float curFood;

    public static float curShift = 1;

    public static void changePlayerMoney(float value) {
        money += value;
    }
    public static float changePlayerMetal() {
        return curMetal++;
    }
    public static float changePlayerPlasticsSingle() {
        return curPlasticsSingle++;
    }
    public static float changePlayerPlasticsRecycle() {
        return curPlasticsRecycle++;
    }
    public static float changePlayerFood() {
        return curFood++;
    }


}
