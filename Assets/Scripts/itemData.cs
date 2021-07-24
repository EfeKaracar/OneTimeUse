using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(itemBehaviours))]
[RequireComponent(typeof(MeshRenderer))]
public class itemData : MonoBehaviour
{
    // Monetary value
    [Range(0, 100)]
    public float itemValue;
    // Toggle if you want monetary to be randomized
    public bool randomizeValue;
    // Determines if item is on the rail. Toggled on/off with rail's collision check with each item and used for dragging mechanics.
    [HideInInspector]
    public bool onRail;
    // Used to support 2 rails.
    [HideInInspector]
    public GameObject targetConveyor;
    // Toggled on/off when an object is being dragged with a mouse. Used as a check to move the object in the rail
    [HideInInspector]
    public bool beingDragged = false;
    public enum bins { single, recycle, metal, food}
    public bins bin;

    // Polishing - Fixes the readability issue with few items that has low thickness. Used to rotate them when they are spawned. (e.g - fork, spoon, knife)
    [Range(-360, 360)]
    public float rotateX;

    private void Start() {

        if(rotateX != 0) { 
        transform.rotation = Quaternion.Euler(rotateX, transform.rotation.y, transform.rotation.z); }
        if (randomizeValue)
            itemValue = UnityEngine.Random.Range(10, 20);   
    }

}
