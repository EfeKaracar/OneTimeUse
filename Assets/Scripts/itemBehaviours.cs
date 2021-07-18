using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehaviours : MonoBehaviour
{
    float cameraZdistance;
    itemData _idata;
    GUIManager guim;

    private void Start() {
        guim = FindObjectOfType<GUIManager>();
        _idata = GetComponent<itemData>();
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
            if (GetComponent<itemData>().beingDragged == false) {
                float _iValue = GetComponent<itemData>().itemValue;
                bool pass = false;
                if (collision.transform.name == "RecyclePlastics") {
                    if (_idata.bin == itemData.bins.recycle) { playerStats.changePlayerPlasticsRecycle(); pass = true; }
                }
                if (collision.transform.name == "SinglePlastics") {
                    if (_idata.bin == itemData.bins.single) { playerStats.changePlayerPlasticsSingle(); pass = true; }
                }
                if (collision.transform.name == "Food") {
                    if (_idata.bin == itemData.bins.food) { playerStats.changePlayerFood(); pass = true; }
                }
                if (collision.transform.name == "Metal") {
                    if (_idata.bin == itemData.bins.metal) { playerStats.changePlayerMetal(); pass = true; }
                }
                if (pass == false) { 
                    float deduction = _iValue * -1;
                    playerStats.changePlayerMoney(deduction); }
                else { playerStats.changePlayerMoney(_iValue); guim.showFeedback(guim.FEED_itemDroppedOnBin); }
                Destroy(this.gameObject);
            }
        }
    }
}
