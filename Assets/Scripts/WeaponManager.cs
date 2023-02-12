using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var weapon in DataBetweenScenes.Weapons)
        {
            if (DataBetweenScenes.WeaponInHand != weapon)
            {
                GameObject.Find("InHand"+weapon.name).SetActive(false);
            }
        }
    }
}
