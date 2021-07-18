using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GUIManager : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI HUD_text_money;
    public TextMeshProUGUI[] HUD_text_resources;
    public TextMeshProUGUI HUD_shift;
    [Header("GUI")]
    public GameObject GUI_Report;
    public GameObject GUI_Upgrade;
    public GameObject GUI_Pause;    
    public GameObject GUI_memo;
    [Header("Notifications")]
    public GameObject NOTE_shift;
    [Header("Feedbacks")]
    public GameObject FEED_itemDroppedOnBin;
    public GameObject FEED_moneyEarned;
    timeManager tm;
    private void Start() {
        tm = GetComponent<timeManager>();
    }
    public void showMoneyFeedback(bool check, float value) {
        FEED_moneyEarned.SetActive(true);
        if (check) { 
            FEED_moneyEarned.transform.Find("Sign").GetComponent<TextMeshProUGUI>().color = Color.green; 
            FEED_moneyEarned.transform.Find("Sign").GetComponent<TextMeshProUGUI>().text = "+"; 
            FEED_moneyEarned.transform.Find("Number").GetComponent<TextMeshProUGUI>().color = Color.green; 
        } else {
            FEED_moneyEarned.transform.Find("Sign").GetComponent<TextMeshProUGUI>().color = Color.red;
            FEED_moneyEarned.transform.Find("Sign").GetComponent<TextMeshProUGUI>().text = "-";
            FEED_moneyEarned.transform.Find("Number").GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        FEED_moneyEarned.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = value.ToString();
        StartCoroutine("closeMFeedback");
    }
    public void showFeedback() {
        FEED_itemDroppedOnBin.transform.position = Input.mousePosition;
        FEED_itemDroppedOnBin.SetActive(true);
        StartCoroutine("closeFeedback");
    }
    IEnumerator closeFeedback() {
        yield return new WaitForSeconds(3);
        FEED_itemDroppedOnBin.SetActive(false);
    }
    IEnumerator closeMFeedback() {
        yield return new WaitForSeconds(3);
        FEED_moneyEarned.SetActive(false);
    }
    private void Update() {
        syncHud();
    }
    void syncHud() {
        HUD_text_money.text = playerStats.money.ToString();
        HUD_text_resources[0].text = playerStats.curPlasticsRecycle.ToString();
        HUD_text_resources[1].text = playerStats.curPlasticsSingle.ToString();
        HUD_text_resources[2].text = playerStats.curMetal.ToString();
        HUD_text_resources[3].text = playerStats.curFood.ToString();
        HUD_shift.text = playerStats.curShift.ToString();
    }
    void syncReport() {
        GUI_Report.transform.Find("Money").transform.Find("_floatMoney").GetComponent<TextMeshProUGUI>().text = playerStats.money.ToString();
    }
    public void reportContinue() {
        NOTE_shift.SetActive(true);
        NOTE_shift.transform.Find("EndShift").gameObject.SetActive(true);
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
