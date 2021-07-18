using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityLib : MonoBehaviour
{
    public GameObject[] bins;
    public GameObject secondRail;
    GUIManager guim;
    private void Start() {
        guim = GetComponent<GUIManager>();
    }
    public void hideBin(string value) { 
        if(value == "Metal") { bins[3].SetActive(false); guim.HUD_text_resources[2].gameObject.SetActive(false); }
        else if(value == "Recycle") { bins[0].SetActive(false); guim.HUD_text_resources[0].gameObject.SetActive(false); }
        else if(value == "Single") { bins[1].SetActive(false); guim.HUD_text_resources[1].gameObject.SetActive(false); }
        else { bins[2].SetActive(false); guim.HUD_text_resources[3].gameObject.SetActive(false); }
    }
    public void showBin(string value) {
        if (value == "Metal") { bins[3].SetActive(true); guim.HUD_text_resources[2].gameObject.SetActive(false); }
        else if (value == "Recycle") { bins[0].SetActive(true); guim.HUD_text_resources[0].gameObject.SetActive(false); }
        else if (value == "Single") { bins[1].SetActive(true); guim.HUD_text_resources[1].gameObject.SetActive(false); }
        else { bins[2].SetActive(true); guim.HUD_text_resources[3].gameObject.SetActive(false); }
    }
}
