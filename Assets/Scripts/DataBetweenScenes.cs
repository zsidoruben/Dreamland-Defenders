using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBetweenScenes
{
    public static Weapon WeaponInHand { get; set; }
    public static int DDs { get; set; } = 2000;
    public static List<Weapon> Weapons { get; set; } = new()
    {
        new(){name = "Sword", price = 200, attackSpeed = 10, dmg = 10, range = 10 },
        new(){name = "Pistol", price = 1000, attackSpeed = 10, dmg = 10, range = 10 },
        new(){name = "Uzi", price = 2000, attackSpeed = 10, dmg = 10, range = 10},
    };
    public static List<Weapon> OwnedWeapons { get; set; } = new();
    public static int SleepCount { get; set; } = 0;
}
