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
        // Pause the game when space key is pressed.
        if (Input.GetKeyDown(KeyCode.Space)) {
            tm.pauseGame(); 
        }
        // Open the pause menu.
        if (Input.GetKeyDown(KeyCode.Escape)) {
            guim.openPauseMenu();
        }
        // If debug mode is enabled, show the end cinematic for fast testing.
        if (tm.enableDebug) {
            if (Input.GetKeyDown(KeyCode.A)) {
                gm.showEndCinematic();
            }
        }
    }
}
