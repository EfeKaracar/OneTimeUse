using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUIManager : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI HUD_text_money;
    [Header("GUI")]
    public GameObject GUI_Report;
    public GameObject GUI_Upgrade;
    [Header("Notifications")]
    public GameObject NOTE_DayStart;
    [Header("Feedbacks")]
    public GameObject FEED_itemDroppedOnBin;

    public void showFeedback(GameObject target) {
        FEED_itemDroppedOnBin.transform.position = Input.mousePosition;
        FEED_itemDroppedOnBin.SetActive(true);
        StartCoroutine("closeFeedback");
    }
    IEnumerator closeFeedback() {
        yield return new WaitForSeconds(3);
        FEED_itemDroppedOnBin.SetActive(false);
    }

    private void Update() {
        syncHud();
    }

    void syncHud() {
        HUD_text_money.text = playerStats.money.ToString();
    
    }
    public void reportContinue(GameObject GUI) { 

    }

    public void quitGame() { }

    public void saveGame() { }

    public void loadGame() { }
}
