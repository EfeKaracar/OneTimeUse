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
    public GameObject GUI_Pause;
    [Header("Notifications")]
    public GameObject NOTE_shift;
    [Header("Feedbacks")]
    public GameObject FEED_itemDroppedOnBin;
    timeManager tm;
    private void Start() {
        tm = GetComponent<timeManager>();
    }
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
    public void reportContinue() {
        NOTE_shift.SetActive(true);
        NOTE_shift.transform.Find("NewShift").gameObject.SetActive(false);
        tm.pauseGame();
    }
    public void openPauseMenu() {
        tm.pauseGame();
        if (!GUI_Pause.activeInHierarchy) { GUI_Pause.SetActive(true); } else { GUI_Pause.SetActive(false); }
    }

    public void quitGame() { Application.Quit(); }
    public void saveGame() { }
    public void loadGame() { }
}
