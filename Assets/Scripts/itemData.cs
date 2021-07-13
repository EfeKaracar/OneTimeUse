using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemData : MonoBehaviour
{
    public string itemName;
    [Range(10, 100)]
    public int itemValue;
    public bool randomizeValue;
    [HideInInspector]
    public bool onRail;
    [HideInInspector]
    public bool beingDragged = false;
    public enum bins { single, recycle, metal, glass, food}
    public bins bin;

    private void Start() {
        if (randomizeValue)
            itemValue = UnityEngine.Random.Range(10, 100);   
    }

}
