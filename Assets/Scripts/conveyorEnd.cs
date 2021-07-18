using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorEnd : MonoBehaviour
{
    GUIManager guim;
    private void Start() {
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Item") {
            float value = collision.transform.GetComponent<itemData>().itemValue;
            value *= -1;
            playerStats.changePlayerMoney(value);
            Destroy(collision.transform.gameObject);
            
        }
    }

}
