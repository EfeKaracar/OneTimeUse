using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rail : MonoBehaviour
{
    /// <summary>
    /// Updates the collided item's target conveyor reference with itself to be used for moving through the correct rail.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Item") {
            collision.transform.GetComponent<itemData>().targetConveyor = this.gameObject;
        }
    }
    private void OnCollisionStay(Collision collision) {
        if(collision.transform.tag == "Item") {
            collision.transform.GetComponent<itemData>().onRail = true;
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.transform.tag == "Item") {
            collision.transform.GetComponent<itemData>().onRail = false;
        }
    }
}
