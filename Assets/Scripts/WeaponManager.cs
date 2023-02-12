using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    GameObject weapon;
    public string asd;
    // Start is called before the first frame update
    void Start()
    {
        asd = DataBetweenScenes.WeaponInHand;
        if (DataBetweenScenes.WeaponInHand != "Uzi")
        {
            weapon = GameObject.Find("InHandUzi");
            weapon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
