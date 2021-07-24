using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMemoActivated : MonoBehaviour
{
    // Simple trick to make sure memos stop the game when they are active.
    private void OnEnable() {
        Time.timeScale = 0;
    }
}
