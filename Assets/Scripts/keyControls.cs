using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyControls : MonoBehaviour
{
    timeManager tm;
    GUIManager guim;
    gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        guim = GetComponent<GUIManager>();
        tm = GetComponent<timeManager>();
        gm = GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            tm.pauseGame(); 
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            guim.openPauseMenu();
        }
        if (tm.enableDebug) {
            if (Input.GetKeyDown(KeyCode.A)) {
                gm.showEndCinematic();
            }
        }
    }
}
