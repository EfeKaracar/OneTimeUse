using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehaviours : MonoBehaviour
{
    float cameraZdistance;
    private void Start() {
        cameraZdistance = Camera.main.WorldToScreenPoint(transform.position).z; // z axis of the game object
    }
    private void OnMouseDrag() {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZdistance);
        Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = newWorldPosition;
        GetComponent<itemData>().beingDragged = true;
    }
    private void OnMouseUp() {
        GetComponent<itemData>().beingDragged = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Bin") { 
            if(GetComponent<itemData>().beingDragged == false) {
                Destroy(this.gameObject);
            }
        }
    }
}
