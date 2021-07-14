using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playerStats {

    public static float money;
    public static float curMetal;
    public static float curPlasticsSingle;
    public static float curPlasticsRecycle;
    public static float curFood;
    public static float curGlass;

    public static float curShift = 1;


    public static float changePlayerMoney(float value) {
        money = Mathf.Clamp(money, 0, Mathf.Infinity);
        if(value < 0) { return money--; } else return money++; 
    }
    public static float changePlayerMetal(float value)
    {
        curMetal = Mathf.Clamp(curMetal, 0, Mathf.Infinity);
        if (value < 0) { return curMetal--; } else return curMetal++;
    }
    public static float changePlayerPlasticsSingle(float value)
    {
        curPlasticsSingle = Mathf.Clamp(curPlasticsSingle, 0, Mathf.Infinity);
        if (value < 0) { return curPlasticsSingle--; } else return curPlasticsSingle++;
    }
    public static float changePlayerPlasticsRecycle(float value)
    {
        curPlasticsRecycle = Mathf.Clamp(curPlasticsRecycle, 0, Mathf.Infinity);
        if (value < 0) { return curPlasticsRecycle--; } else return curPlasticsRecycle++;
    }
    public static float changePlayerFood(float value)
    {
        curFood = Mathf.Clamp(curFood, 0, Mathf.Infinity);
        if (value < 0) { return curFood--; } else return curFood++;
    }
    public static float changePlayerGlass(float value)
    {
        curGlass = Mathf.Clamp(curGlass, 0, Mathf.Infinity);
        if (value < 0) { return curGlass--; } else return curGlass++;
    }


}
