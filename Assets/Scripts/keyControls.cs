using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyControls : MonoBehaviour
{
    timeManager tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<timeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            tm.pauseGame();
        }
    }
}
