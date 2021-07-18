using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(itemBehaviours))]
[RequireComponent(typeof(MeshRenderer))]
public class itemData : MonoBehaviour
{
    public string itemName;
    [Range(0, 100)]
    public float itemValue;
    public bool randomizeValue;
    [HideInInspector]
    public bool onRail;
    [HideInInspector]
    public GameObject targetConveyor;
    [HideInInspector]
    public bool beingDragged = false;
    public enum bins { single, recycle, metal, food}
    public bins bin;

    private void Start() {
        if (randomizeValue)
            itemValue = UnityEngine.Random.Range(10, 20);   
    }

}
