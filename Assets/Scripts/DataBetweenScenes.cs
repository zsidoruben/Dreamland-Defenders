using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBetweenScenes
{
    public static string WeaponInHand { get; set; } = string.Empty;
    public static int DDs { get; set; } = 2000;
    public static List<string> Weapons { get; set; } = new();
    public static int SleepCount { get; set; } = 0;
}
