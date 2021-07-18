using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to have all the gameplay parameters in one single place.
/// 2f = 1x conveyor speed.
/// Note: All the variables here are changed at the start of a shift from gameManager.
/// </summary>
public static class gameBalancing
{
    public static bool activateSecondRail = false;
    public static float itemMoveSpeed = 2f;
    public static float shiftDurationInSeconds = 30;

    public static bool allowFoodForSpawn = false;
    public static bool allowSingleForSpawn = false;
    public static bool allowRecycleForSpawn = false;
    public static bool allowMetalForSpawn = false;
}
