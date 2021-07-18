using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rail : MonoBehaviour
{
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
