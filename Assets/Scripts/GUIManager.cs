using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour
{
    [Header("HUD")]
    public GameObject HUD;
    public TextMeshProUGUI HUD_text_money;
    public TextMeshProUGUI[] HUD_text_resources;
    public GameObject[] HUD_Image_resources;
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
    public GameObject FEED_missed;
    timeManager tm;
    private void Start() {
        tm = GetComponent<timeManager>();
    }
    /// <summary>
    /// This script shows how much money player earned or lost everytime he puts an item on a bin.
    /// </summary>
    /// <param name="check"></param>
    /// <param name="value"></param>
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
    public void showMemo() {
        GUI_memo.SetActive(true);
        if(playerStats.curShift == 1) { GUI_memo.transform.Find("Memo_Day2").gameObject.SetActive(true); }
        if(playerStats.curShift == 2) { GUI_memo.transform.Find("Memo_Day3").gameObject.SetActive(true); }
        if(playerStats.curShift == 3) { GUI_memo.transform.Find("Memo_Day4").gameObject.SetActive(true); }
        if(playerStats.curShift == 4) { GUI_memo.transform.Find("Memo_Day5").gameObject.SetActive(true); }
        //if(playerStats.curShift == 5) { GUI_memo.transform.Find("Memo_Day5").gameObject.SetActive(true); }
    }
    /// <summary>
    /// This script shows a text on mouse position notifying player put a correct item on a bin. Used for notifying player.
    /// </summary>
    public void showFeedback() {
        FEED_itemDroppedOnBin.transform.position = Input.mousePosition;
        FEED_itemDroppedOnBin.SetActive(true);
        StartCoroutine("closeFeedback");
    }
    /// <summary>
    /// This script shows a text on the screen, notifying the player he just missed an item on the conveyor.
    /// </summary>
    public void showMissedFeedback() {
        FEED_missed.SetActive(true);
        StartCoroutine("closeMissedFeedback");
    }

    IEnumerator closeFeedback() {
        yield return new WaitForSeconds(3);
        FEED_itemDroppedOnBin.SetActive(false);
    }   
    IEnumerator closeMissedFeedback() {
        yield return new WaitForSeconds(3);
        FEED_missed.SetActive(false);
    }
    IEnumerator closeMFeedback() {
        yield return new WaitForSeconds(3);
        FEED_moneyEarned.SetActive(false);
    }
    private void Update() {
        syncHud();
    }
    /// <summary>
    /// This script updates the texts in HUD with player statistics every frame.
    /// </summary>
    void syncHud() {
        HUD_text_money.text = playerStats.curMoney.ToString();
        HUD_text_resources[0].text = playerStats.curPlasticsRecycle.ToString();
        HUD_text_resources[1].text = playerStats.curPlasticsSingle.ToString();
        HUD_text_resources[2].text = playerStats.curMetal.ToString();
        HUD_text_resources[3].text = playerStats.curFood.ToString();
        HUD_shift.text = playerStats.curShift.ToString();
    }
    /// <summary>
    /// This script updates the report with player statistics.
    /// </summary>
    void syncReport() {
        GUI_Report.transform.Find("Money").transform.Find("_floatMoney").GetComponent<TextMeshProUGUI>().text = playerStats.curMoney.ToString();
        if(playerStats.curShift == 1) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Great sorting today, for a first timer. You have the option to take these earnings home, or you can donate it and contribute to the community park like many of your fellow volunteers here.Today we’re planning to raise enough funds and recycle enough material to build some benches.We will not judge you for the choice you make."; }
        if(playerStats.curShift == 2) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Looks like you managed to deal with all the extra items today. You did a great job.You earned. Every day, you’ll have the option to contribute to the community park. Today’s funds will be going towards building a swing set, if there’s enough."; }
        if(playerStats.curShift == 3) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Wow. There was a lot of stuff today. Today’s fundraiser will be going towards building a slide, if there’s enough resources collected by everyone. Would you like to contribute your earnings for the day?"; }
        if(playerStats.curShift == 4) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Thanks for sorting out so much of the food today. There’s a lot we couldn’t get to unfortunately, but we can manage that tomorrow. Today’s fundraiser amount will be put towards installing a community vegetable garden in the park. We will supply it with fresh compost using all the food material we collected today. Would you like to contribute your earnings towards this project?"; }
        if (playerStats.curShift == 5) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Well, I guess that’s it. You’ve made it through the week. Today’s the last day we’ll be accepting donations for the community park. Last I heard, they want to install public drinking fountains if we have enough resources. Would you like to contribute?"; }
        if (playerStats.curShift == 5) { GUI_Report.transform.Find("ReportText").GetComponent<TextMeshProUGUI>().text = "Turns out there were not enough recyclable items sent to our facility this week, and the plans for the park will unfortunately need to be scrapped for the time being.But all is not lost! Instead of putting all our funding towards the park, we will instead be using it to run a campaign all over town to help incentivise people to recycle as much as they can, and not to purchase or use single-use plastics.This goes beyond our little town, but everything we can do will help the environment.Thanks for playing, and remember to Reduce, Reuse, and Recycle wherever and whenever possible."; }
    }
    public void reportContinue() {
        syncReport();
        NOTE_shift.SetActive(true);
        NOTE_shift.transform.Find("EndShift").gameObject.SetActive(true);
        NOTE_shift.transform.Find("NewShift").gameObject.SetActive(false);
        
    }
    /// <summary>
    /// This script opens up the pause menu, while pausing the time.
    /// </summary>
    public void openPauseMenu() {
        tm.pauseGame();
        if (!GUI_Pause.activeInHierarchy) { GUI_Pause.SetActive(true); } else { GUI_Pause.SetActive(false); }
    }
    /// <summary>
    /// This script quits the game.
    /// </summary>
    public void quitGame() { Application.Quit(); }
    public void restartGame() { SceneManager.LoadScene(0); }
}
