using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehaviours : MonoBehaviour
{
    float cameraZdistance;
    itemData _idata;
    GUIManager guim;
    gameManager gm;
    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
        guim = FindObjectOfType<GUIManager>();
        _idata = GetComponent<itemData>();
        cameraZdistance = Camera.main.WorldToScreenPoint(transform.position).z; // z axis of the game object
    }
    /// <summary>
    /// Called everytime mouse begins dragging an Item from conveyor.
    /// </summary>
    private void OnMouseDrag() {
        if(Time.timeScale != 0) { 
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZdistance);
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = newWorldPosition;
            GetComponent<itemData>().beingDragged = true;
        }
    }
    private void OnMouseUp() {
        GetComponent<itemData>().beingDragged = false;
    }

    private void OnCollisionEnter(Collision collision) {
        //Debug.Log(collision.transform.name);
        if(collision.transform.tag == "Bin") {
            if (GetComponent<itemData>().beingDragged == false) {
                float _iValue = GetComponent<itemData>().itemValue;
                bool singleUseThrown = false;
                bool pass = false;
                // Match and pass
                // If the item and bin matches, add by 1 to relevant GUI element
                if (collision.transform.name == "RecyclePlastics") {
                    if (_idata.bin == itemData.bins.recycle) { playerStats.changePlayerPlasticsRecycle(); pass = true; singleUseThrown = false;/*Debug.Log(1);*/ }
                }
                if (collision.transform.name == "SinglePlastics") {
                    if (_idata.bin == itemData.bins.single) { playerStats.changePlayerPlasticsSingle(); pass = true; singleUseThrown = true; /*Debug.Log(1);*/ }
                }
                if (collision.transform.name == "Food") {
                    if (_idata.bin == itemData.bins.food) { playerStats.changePlayerFood(); pass = true; singleUseThrown = false;/*Debug.Log(1);*/ }
                }
                if (collision.transform.name == "Metal") {
                    if (_idata.bin == itemData.bins.metal) { playerStats.changePlayerMetal(); pass = true; singleUseThrown = false;/*Debug.Log(1);*/ }
                }
                // Pass check
                // If an item is put into wrong bin, then player loses money
                if (pass == false) {
                    gm.playClip(gm.wrongMatch, transform.position);
                    float deduction = _iValue * -1;
                    playerStats.changePlayerMoney(deduction);
                    //Debug.Log(2); 
                // If an item is put into correct bin, then player earns money
                } else {
                    // Play sound
                    gm.playClip(gm.correctMatch, transform.position);
                    // Player doesn't earn money from single-use plastic items
                    if (!singleUseThrown) { 
                        playerStats.changePlayerMoney(_iValue); 
                        guim.showFeedback();
                    }
                }
                // Show the money earned on top-right, underneath current earnings
                guim.showMoneyFeedback(pass, _iValue);
                // Destroy - not enough time for object pooling
                Destroy(this.gameObject);
            }
        }
    }
}
