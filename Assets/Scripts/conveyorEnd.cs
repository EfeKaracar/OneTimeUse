using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorEnd : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Item") {
            Destroy(collision.transform.gameObject);
        }
    }

}
