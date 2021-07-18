using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorEnd : MonoBehaviour
{
    GUIManager guim;
    gameManager gm;
    private void Start() {
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        gm = guim.GetComponent<gameManager>();
    }
    /// <summary>
    /// This collision check makes sure items player didn't pick from the conveyor is missed and their values deducted from player's money.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Item") {
            float value = collision.transform.GetComponent<itemData>().itemValue;
            value *= -1;
            playerStats.changePlayerMoney(value);
            Destroy(collision.transform.gameObject);
            guim.showMissedFeedback();
            gm.playClip(gm.missedItem, transform.position);
        }
    }

}
