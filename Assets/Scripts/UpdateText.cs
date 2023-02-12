using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public List <TextMeshPro> texts;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            for (int j = 0; j < DataBetweenScenes.Weapons.Count; j++)
            {
                var weapon = DataBetweenScenes.Weapons[i];
                if (DataBetweenScenes.WeaponInHand == weapon)
                {
                    texts[i].text = "Equiped";
                }
                else if (DataBetweenScenes.OwnedWeapons.Contains(weapon))
                {
                    texts[i].text = "Owned";
                }
                else
                {
                    texts[i].text = weapon.price.ToString() + " DD";
                }
            }
        }
    }
}
